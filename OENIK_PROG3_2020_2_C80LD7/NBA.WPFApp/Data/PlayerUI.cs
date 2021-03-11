using GalaSoft.MvvmLight;
using NBA.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA.WPFApp.Data
{
    public class PlayerUI : ObservableObject
    {
        int playerid;
        string name;
        DateTime birth;
        int height;
        int weight;
        string post;
        int salary;
        int number;
        Teams team;

        public int PlayerID
        {
            get { return playerid; }
            set { Set(ref playerid, value); }
        }

        public string Name
        {
            get { return name; }
            set { Set(ref name, value); }
        }

        public DateTime Birth
        {
            get { return birth; }
            set { Set(ref birth, value); }
        }

        public int Height
        {
            get { return height; }
            set { Set(ref height, value); }
        }

        public int Weight
        {
            get { return weight; }
            set { Set(ref weight, value); }
        }

        public string Post
        {
            get { return post; }
            set { Set(ref post, value); }
        }

        public int Salary
        {
            get { return salary; }
            set { Set(ref salary, value); }
        }

        public int Number
        {
            get { return number; }
            set { Set(ref number, value); }
        }

        public Teams Team
        {
            get { return team; }
            set { Set(ref team, value); }
        }

        public void CopyFrom(PlayerUI other)
        {
            this.GetType().GetProperties().ToList().
                ForEach(property => property.SetValue(this, property.GetValue(other)));
        }

        /// <summary>
        /// Converts PlayerUI entity to Player db entity.
        /// </summary>
        /// <param name="playerui">Player ui entity.</param>
        /// <returns>Player db entity.</returns>
        public Player ConvertToPlayerEntity(PlayerUI playerui)
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
                player.Team = playerui.Team;
            }

            return player;
        }

        /// <summary>
        /// Converts one db player entity to player ui entity.
        /// </summary>
        /// <param name="player">player entity.</param>
        /// <returns>PlayerUI entity.</returns>
        public PlayerUI ConvertToPlayerUiEntity(Player player)
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
                playerui.Team = player.Team;
            }

            return playerui;
        }
    }
}
