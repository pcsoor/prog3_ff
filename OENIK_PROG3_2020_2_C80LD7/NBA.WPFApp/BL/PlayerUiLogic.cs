// <copyright file="PlayerUiLogic.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.WPFApp.BL
{
    using System.Collections.Generic;
    using System.Linq;
    using GalaSoft.MvvmLight.Ioc;
    using GalaSoft.MvvmLight.Messaging;
    using NBA.Logic;
    using NBA.WPFApp.Data;

    /// <summary>
    /// Player Business logic.
    /// </summary>
    public class PlayerUiLogic : IPlayerUiLogic
    {
        private readonly IEditorService editorService;
        private readonly IMessenger messengerService;
        private readonly NBA.Logic.IPlayerLogic playerLogic;
        private readonly PlayerUI playeruidata;
        private readonly Factory factory;
        private readonly TeamUI teamuidata;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerUiLogic"/> class.
        /// </summary>
        /// <param name="editorService">Editor service ref.</param>
        /// <param name="messengerService">Messenger service ref.</param>
        /// <param name="playerLogic">old player logic ref.</param>
        /// <param name="playeruidata">playerui data ref.</param>
        /// <param name="factory">factory ref.</param>
        /// <param name="teamui">teamui data ref.</param>
        [PreferredConstructor]
        public PlayerUiLogic(IEditorService editorService, IMessenger messengerService, NBA.Logic.IPlayerLogic playerLogic, PlayerUI playeruidata, Factory factory, TeamUI teamui)
        {
            this.playerLogic = playerLogic;
            this.editorService = editorService;
            this.messengerService = messengerService;
            this.playeruidata = playeruidata;
            this.factory = factory;
            this.teamuidata = teamui;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerUiLogic"/> class.
        /// </summary>
        /// <param name="playerLogic">playerLogic interface reference.</param>
        public PlayerUiLogic(IPlayerLogic playerLogic)
        {
            this.playerLogic = playerLogic;
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
                list?.Add(newPlayer);
                this.playerLogic.AddNewPlayer(new NBA.Data.Model.Player
                {
                    Name = newPlayer.Name,
                    Height = newPlayer.Height,
                    Salary = newPlayer.Salary,
                    Team = TeamUI.ConvertToTeamEntity(newPlayer.TeamUI),
                });

                list.Last().PlayerID = this.playerLogic.GetAllPlayers().Last().PlayerID;
                this.messengerService.Send("ADD OK", "LogicResult");
            }
        }

        /// <summary>
        /// Deletes one player from list and from db as well.
        /// </summary>
        /// <param name="list">list of players in ui.</param>
        /// <param name="player">playerui entity.</param>
        public void DelPlayer(IList<PlayerUI> list, PlayerUI player)
        {
            if (player != null && list != null && list.Remove(player))
            {
                TeamUI.ConvertToTeamEntity(player.TeamUI);
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
                    playerUiEntities.Add(PlayerUI.ConvertToPlayerUiEntity(entity));
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
                this.playerLogic.UpdatePlayer(PlayerUI.ConvertToPlayerEntity(clone));
                this.factory.Ctx.SaveChanges();
                this.messengerService.Send("MODIFY OK", "LogicResult");
            }
            else
            {
                this.messengerService.Send("MODIFY CANCEL", "LogicResult");
            }
        }
    }
}
