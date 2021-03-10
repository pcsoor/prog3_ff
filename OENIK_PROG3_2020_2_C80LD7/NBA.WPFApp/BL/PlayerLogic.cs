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

        public void AddPlayer(IList<Player> list)
        {
            Player newPlayer = new Player();
            if (editorService.EditPlayer(newPlayer) == true)
            {
                list.Add(newPlayer);
                this.playerRepo.Insert(newPlayer);
                messengerService.Send("ADD OK", "LogicResult");
            }
        }

        public void DelPlayer(IList<Player> list, Player player)
        {
            throw new NotImplementedException();
        }

        public IList<Player> GetAllPlayers()
        {
            throw new NotImplementedException();
        }

        public void ModPlayer(Player playerToModify)
        {
            throw new NotImplementedException();
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
            }
        }

        public static PlayerUI ConvertToPlayerUiEntity(Player player)
        {
            PlayerUI playerui = new PlayerUI();
            if (player != null)
            {
                playerui.Name
            }
        }
    }
}
