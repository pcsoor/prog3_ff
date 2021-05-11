// <copyright file="PlayerVM.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.WpfClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using GalaSoft.MvvmLight;

    /// <summary>
    /// Position types.
    /// </summary>
    public enum PositionType
    {
        /// <summary>
        /// Pointgurad position.
        /// </summary>
        PointGuard,

        /// <summary>
        /// Shooting guard position.
        /// </summary>
        ShootingGuard,

        /// <summary>
        /// Small forward position.
        /// </summary>
        SmallForward,

        /// <summary>
        /// Power Forward position.
        /// </summary>
        PowerForward,

        /// <summary>
        /// Center position.
        /// </summary>
        Center,
    }

    /// <summary>
    /// Player model class.
    /// </summary>
    public class PlayerVM : ObservableObject
    {
        private int playerID;
        private string name;
        private string teamName;
        private int height;
        private int weight;
        private int number;
        private int salary;
        private PositionType post;
        private DateTime birth;

        /// <summary>
        /// Gets list of nba positions.
        /// </summary>
        public static Array Positions
        {
            get { return Enum.GetValues(typeof(PositionType)); }
        }

        /// <summary>
        /// Gets or sets player's id.
        /// </summary>
        public int PlayerID
        {
            get { return this.playerID; }
            set { this.Set(ref this.playerID, value); }
        }

        /// <summary>
        /// Gets or sets player's name.
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.Set(ref this.name, value); }
        }

        /// <summary>
        /// Gets or sets team where the player plays in.
        /// </summary>
        public string TeamName
        {
            get { return this.teamName; }
            set { this.Set(ref this.teamName, value); }
        }

        /// <summary>
        /// Gets or sets player's height.
        /// </summary>
        public int Height
        {
            get { return this.height; }
            set { this.Set(ref this.height, value); }
        }

        /// <summary>
        /// Gets or sets player's weight.
        /// </summary>
        public int Weight
        {
            get { return this.weight; }
            set { this.Set(ref this.weight, value); }
        }

        /// <summary>
        /// Gets or sets player's number.
        /// </summary>
        public int Number
        {
            get { return this.number; }
            set { this.Set(ref this.number, value); }
        }

        /// <summary>
        /// Gets or sets player's salary.
        /// </summary>
        public int Salary
        {
            get { return this.salary; }
            set { this.Set(ref this.salary, value); }
        }

        /// <summary>
        /// Gets or sets player's position.
        /// </summary>
        public PositionType Post
        {
            get { return this.post; }
            set { this.Set(ref this.post, value); }
        }

        /// <summary>
        /// Gets or sets player's date of birth.
        /// </summary>
        public DateTime Birth
        {
            get { return this.birth; }
            set { this.Set(ref this.birth, value); }
        }

        /// <summary>
        /// Copies one player.
        /// </summary>
        /// <param name="other">player to copy.</param>
        public void CopyFrom(PlayerVM other)
        {
            if (other == null)
            {
                return;
            }
            else
            {
                this.PlayerID = other.PlayerID;
                this.Name = other.Name;
                this.TeamName = other.TeamName;
                this.Height = other.Height;
                this.weight = other.Weight;
                this.Salary = other.Salary;
                this.Number = other.Number;
                this.Birth = other.Birth;
                this.Post = other.Post;
            }
        }
    }
}
