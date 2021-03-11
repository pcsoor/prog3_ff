// <copyright file="PlayerLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBA.WPFApp.BL
{
    using System;
    using System.Collections.Generic;
    using GalaSoft.MvvmLight.Messaging;
    using NBA.WPFApp.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NBA.Repository;
    using Amazon.DirectoryService.Model;
    using NBA.Data.Model;

    /// <summary>
    /// Player business logic implemented in this class.
    /// </summary>
    public class PlayerLogic : IPlayerLogic
    {
        IEditorService editorService;
        IMessenger messengerService;
        private readonly IPlayerRepository playerRepo;

        public PlayerLogic(IEditorService editorService, IMessenger messengerService, IPlayerRepository playerRepo)
        {
            this.playerRepo = playerRepo;
            this.editorService = editorService;
            this.messengerService = messengerService;
        }

        public void AddPlayer(IList<PlayerUI> list)
        {
            Player newPlayer = new Player();
            PlayerUI newUiPlayer = ConvertToPlayerUiEntity(newPlayer);
            if (editorService.EditPlayer(newUiPlayer) == true)
            {
                list.Add(newUiPlayer);
                this.playerRepo.Insert(newPlayer);
                messengerService.Send("ADD OK", "LogicResult");
            }
        }

        public void DelPlayer(IList<Player> list, Player player)
        {
            
        }

        public IList<Player> GetAllPlayers()
        {
            throw new NotImplementedException();
        }

        public void ModPlayer(PlayerUI playerToModify)
        {
            if (playerToModify == null)
            {
                messengerService.Send("EDIT FAILED", "LogicResult");
                return;
            }

            PlayerUI clone = new PlayerUI();
            clone.CopyFrom(playerToModify);
            if (editorService.EditPlayer(clone) == true)
            {
                playerToModify.CopyFrom(clone);
                // db
                messengerService.Send("MODIFY OK", "LogicResult");
            }
            else
            {
                messengerService.Send("MODIFY CANCEL", "LogicResult");
            }
        }

        public static Player ConvertToPlayerEntity(PlayerUI playerui)
        {
            Player player = new Player();
            if (playerui != null)
            {
                player.Name = playerui.Name;
                player.Height = playerui.Height;
                player.Weight = playerui.Weight;
                player.Salary = playerui.Salary;
                player.Number = playerui.Number;
                player.Post = playerui.Post;
                player.Team = playerui.Team;
            }

            return player;
        }

        public static PlayerUI ConvertToPlayerUiEntity(Player player)
        {
            PlayerUI playerui = new PlayerUI();
            if (player != null)
            {
                playerui.Name = player.Name;
                playerui.Height = player.Height;
                playerui.Weight = player.Weight;
                playerui.Salary = player.Salary;
                playerui.Number = player.Number;
                playerui.Post = player.Post;
                playerui.Team = player.Team;
            }

            return playerui;
        }

        //public void DelPlayer(IList<PlayerUI> list, PlayerUI player)
        //{
        //    Player playerToDel = ConvertToPlayerEntity(player);
        //    if (player != null && list.Remove(player))
        //    {
        //        if (this.playerRepo.GetAll().ToList().Contains(PlayerLogic.GetOnePlayerById(id)))
        //        {
        //            this.playerRepo.Remove(id);
        //            return true;
        //        }
        //        messengerService.Send("DELETE OK", "LogicResult");
        //    }
        //    else
        //    {
        //        messengerService.Send("DELETE FAILED", "LogicResult");
        //    }
        //}

        IList<PlayerUI> IPlayerLogic.GetAllPlayers()
        {
            throw new NotImplementedException();
        }

        
    }
}
