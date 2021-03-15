// <copyright file="PlayerUI.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.WPFApp.Data
{
    using System;
    using System.Linq;
    using GalaSoft.MvvmLight;
    using NBA.Data.Model;

    /// <summary>
    /// Player entity to display in ui.
    /// </summary>
    public class PlayerUI : ObservableObject
    {
        private int playerid;
        private string name;
        private DateTime birth;
        private int height;
        private int weight;
        private string post;
        private int salary;
        private int number;
        private TeamUI teamui;

        /// <summary>
        /// Gets or sets iD of the player.
        /// </summary>
        public int PlayerID
        {
            get { return this.playerid; }
            set { this.Set(ref this.playerid, value); }
        }

        /// <summary>
        /// Gets or sets the name of the player.
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.Set(ref this.name, value); }
        }

        /// <summary>
        /// Gets or sets the date of birth of the player.
        /// </summary>
        public DateTime Birth
        {
            get { return this.birth; }
            set { this.Set(ref this.birth, value); }
        }

        /// <summary>
        /// Gets or sets the height of the player.
        /// </summary>
        public int Height
        {
            get { return this.height; }
            set { this.Set(ref this.height, value); }
        }

        /// <summary>
        /// Gets or sets the weight of the player.
        /// </summary>
        public int Weight
        {
            get { return this.weight; }
            set { this.Set(ref this.weight, value); }
        }

        /// <summary>
        /// Gets or sets the post of the player where he plays at.
        /// </summary>
        public string Post
        {
            get { return this.post; }
            set { this.Set(ref this.post, value); }
        }

        /// <summary>
        /// Gets or sets the salary of the player.
        /// </summary>
        public int Salary
        {
            get { return this.salary; }
            set { this.Set(ref this.salary, value); }
        }

        /// <summary>
        /// Gets or sets the number of the player.
        /// </summary>
        public int Number
        {
            get { return this.number; }
            set { this.Set(ref this.number, value); }
        }

        /// <summary>
        /// Gets or sets the Team of the player where he plays at.
        /// </summary>
        public TeamUI TeamUI
        {
            get { return this.teamui; }
            set { this.Set(ref this.teamui, value); }
        }

        /// <summary>
        /// Converts PlayerUI entity to Player db entity.
        /// </summary>
        /// <param name="playerui">Player ui entity.</param>
        /// <returns>Player db entity.</returns>
        public static Player ConvertToPlayerEntity(PlayerUI playerui)
        {
            Player player = new Player();
            if (playerui != null)
            {
                player.PlayerID = playerui.PlayerID;
                player.Name = playerui.Name;
                player.Height = playerui.Height;
                player.Weight = playerui.Weight;
                player.Salary = playerui.Salary;
                player.Number = playerui.Number;
                player.Post = playerui.Post;
                player.Team = TeamUI.ConvertToTeamEntity(playerui.TeamUI);
            }

            return player;
        }

        /// <summary>
        /// Converts one db player entity to player ui entity.
        /// </summary>
        /// <param name="player">player entity.</param>
        /// <returns>PlayerUI entity.</returns>
        public static PlayerUI ConvertToPlayerUiEntity(Player player)
        {
            PlayerUI playerui = new PlayerUI();
            if (player != null)
            {
                playerui.PlayerID = player.PlayerID;
                playerui.Name = player.Name;
                playerui.Height = player.Height;
                playerui.Weight = player.Weight;
                playerui.Salary = player.Salary;
                playerui.Number = player.Number;
                playerui.Post = player.Post;
                playerui.TeamUI = TeamUI.ConvertToTeamUiEntity(player.Team);
                playerui.TeamUI.TeamID = player.Team.TeamID;
            }

            return playerui;
        }

        /// <summary>
        /// Copies a player entity.
        /// </summary>
        /// <param name="other">player to copy.</param>
        public void CopyFrom(PlayerUI other)
        {
            this.GetType().GetProperties().ToList().
                ForEach(property => property.SetValue(this, property.GetValue(other)));
        }

        // public override bool Equals(object obj)
        // {
        //    if (obj is PlayerUI)
        //    {
        //        PlayerUI secondPlayer = obj as PlayerUI;
        //        return this.PlayerID == secondPlayer.PlayerID && this.Name == secondPlayer.Name && this.Height == secondPlayer.Height && this.TeamUI == secondPlayer.TeamUI && this.Salary == secondPlayer.Salary && this.Weight == secondPlayer.Weight && this.Number == secondPlayer.Number;
        //    }

        // return false;
        // }
    }
}
