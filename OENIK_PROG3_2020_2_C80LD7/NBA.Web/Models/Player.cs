// <copyright file="Player.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using NBA.Data.Model;

    /// <summary>
    /// Player model class.
    /// </summary>
    public class Player
    {
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
        /// Gets or sets unique identitication of player.
        /// </summary>
        [Display(Name = "Player Id")]
        [Required]
        public int PlayerID { get; set; }

        /// <summary>
        /// Gets or sets the team id where the player plays currently.
        /// </summary>
        [Display(Name = "Player Team Id")]
        [Required]
        public int TeamID { get; set; }

        /// <summary>
        /// Gets or sets the name of the player.
        /// </summary>
        [Display(Name = "Player Name")]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the player's date of birth.
        /// </summary>
        [Display(Name = "Player Brand")]
        [Required]
        public DateTime Birth { get; set; }

        /// <summary>
        /// Gets or sets the height of the player.
        /// </summary>
        [Display(Name = "Player Height")]
        [Required]
        public int Height { get; set; }

        /// <summary>
        /// Gets or sets the weight of the player.
        /// </summary>
        [Display(Name = "Player Weight")]
        [Required]
        public int Weight { get; set; }

        /// <summary>
        /// Gets or sets the position where the player plays.
        /// </summary>
        [Display(Name = "Player Post")]
        [Required]
        public PositionType Post { get; set; }

        /// <summary>
        /// Gets or sets the avarage salary.
        /// </summary>
        [Display(Name = "Player Salary")]
        [Required]
        public int Salary { get; set; }

        /// <summary>
        /// Gets or sets the player's number.
        /// </summary>
        [Display(Name = "Player Number")]
        [Required]
        public int Number { get; set; }

        /// <summary>
        /// Gets or sets one team.
        /// </summary>
        [Display(Name = "Player Team")]
        public string TeamName { get; set; }

        /// <summary>
        /// Gets or sets team model.
        /// </summary>
        public Team TeamWeb { get; set; }
    }
}
