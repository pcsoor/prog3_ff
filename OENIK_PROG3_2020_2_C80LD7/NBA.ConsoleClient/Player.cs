// <copyright file="Player.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Text;

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
    /// Player entity.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Gets or sets unique identitication of player.
        /// </summary>
        public int PlayerID { get; set; }

        /// <summary>
        /// Gets or sets the name of the player.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the position where the player plays.
        /// </summary>
        public PositionType Post { get; set; }

        /// <summary>
        /// Gets or sets the team, where the player plays at.
        /// </summary>
        public string TeamName { get; set; }

        /// <summary>
        /// Gets or sets the player's date of birth.
        /// </summary>
        public DateTime Birth { get; set; }

        /// <summary>
        /// Gets or sets the height of the player.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Gets or sets the weight of the player.
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// Gets or sets the avarage salary.
        /// </summary>
        public int Salary { get; set; }

        /// <summary>
        /// Gets or sets the player's number.
        /// </summary>
        public int Number { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"ID={this.PlayerID}\tName={this.Name}\tTeam={this.TeamName}\tPost={this.Post}\tBirth={this.Birth.ToShortDateString()}\tHeight={this.Height}\tWeight={this.Weight}\tSalary={this.Salary}\tNumber={this.Number}";
        }
    }
}
