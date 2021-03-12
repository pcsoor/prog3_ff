// <copyright file="PlayerLogic.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.WPFApp.BL
{
    using System;
    using System.Collections.Generic;
    using Amazon.DirectoryService.Model;
    using GalaSoft.MvvmLight.Messaging;
    using NBA.Data.Model;
    using NBA.WPFApp.Data;

    /// <summary>
    /// Player business logic implemented in this class.
    /// </summary>
    public class PlayerLogic : IPlayerLogic
    {
        private readonly IEditorService editorService;
        private readonly IMessenger messengerService;
        private readonly NBA.Logic.IPlayerLogic playerLogic;
        private readonly PlayerUI playeruidata;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerLogic"/> class.
        /// </summary>
        /// <param name="editorService">editor service ref.</param>
        /// <param name="messengerService">messengerService ref.</param>
        /// <param name="playerLogic">playerLogic ref in Logic layer.</param>
        public PlayerLogic(IEditorService editorService, IMessenger messengerService, NBA.Logic.IPlayerLogic playerLogic)
        {
            this.playerLogic = playerLogic;
            this.editorService = editorService;
            this.messengerService = messengerService;
        }

        /// <summary>
        /// Adds one player to list.
        /// </summary>
        /// <param name="list">list of players in ui.</param>
        public void AddPlayer(IList<PlayerUI> list)
        {
            PlayerUI newPlayer = new PlayerUI();
            if (this.editorService.EditPlayer(newPlayer) == true)
            {
                list.Add(newPlayer);
                this.playerLogic.AddNewPlayer(this.playeruidata.ConvertToPlayerEntity(newPlayer));
                this.messengerService.Send("ADD OK", "LogicResult");
            }
        }

        /// <summary>
        /// Deletes one player from list and db as well.
        /// </summary>
        /// <param name="list">list of players in ui.</param>
        /// <param name="player">playerui entity.</param>
        public void DelPlayer(IList<PlayerUI> list, PlayerUI player)
        {
            if (player != null && list.Remove(player))
            {
                this.playerLogic.DeletePlayer(player.PlayerID);
                this.messengerService.Send("DELETE OK", "LogicResult");
            }
            else
            {
                this.messengerService.Send("DELETE FAILED", "LogicResult");
            }
        }

        /// <summary>
        /// Returns a list of players in ui.
        /// </summary>
        /// <returns>IList collection.</returns>
        public IList<PlayerUI> GetAllPlayers()
        {
            List<PlayerUI> playerUiEntities = new List<PlayerUI>();
            if (this.playerLogic.GetAllPlayers() != null)
            {
                foreach (var entity in this.playerLogic.GetAllPlayers())
                {
                    playerUiEntities.Add(this.playeruidata.ConvertToPlayerUiEntity(entity));
                }

                this.messengerService.Send("QUERY OK", "LogicResult");
                return playerUiEntities;
            }
            else
            {
                this.messengerService.Send("QUERY FAILED", "LogicResult");
                return null;
            }
        }

        /// <summary>
        /// Change given player's properties.
        /// </summary>
        /// <param name="playerToModify">player to modify.</param>
        public void ModPlayer(PlayerUI playerToModify)
        {
            if (playerToModify == null)
            {
                this.messengerService.Send("EDIT FAILED", "LogicResult");
                return;
            }

            PlayerUI clone = new PlayerUI();
            clone.CopyFrom(playerToModify);
            if (this.editorService.EditPlayer(clone) == true)
            {
                playerToModify.CopyFrom(clone);
                this.playerLogic.UpdatePlayer(this.playeruidata.ConvertToPlayerEntity(clone));
                this.messengerService.Send("MODIFY OK", "LogicResult");
            }
            else
            {
                this.messengerService.Send("MODIFY CANCEL", "LogicResult");
            }
        }
    }
}
