﻿// <copyright file="PlayerStats.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBA.Data.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Creates and set player statistics table.
    /// </summary>
    [Table("PlayerStats")]
    public class PlayerStats
    {
        /// <summary>
        /// Gets or sets the player stat id.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayerStatID { get; set; }

        /// <summary>
        /// Gets or sets the player id.
        /// </summary>
        [ForeignKey(nameof(Player))]
        public int PlayerID { get; set; }

        /// <summary>
        /// Gets or sets games played.
        /// </summary>
        [Required]
        public double GP { get; set; }

        /// <summary>
        /// Gets or sets points per game.
        /// </summary>
        public double PPG { get; set; }

        /// <summary>
        /// Gets or sets field goals made.
        /// </summary>
        public double FGM { get; set; }

        /// <summary>
        /// Gets or sets assist.
        /// </summary>
        public double AST { get; set; }

        /// <summary>
        /// Gets or sets rebound.
        /// </summary>
        public double REB { get; set; }

        /// <summary>
        /// Gets or sets block.
        /// </summary>
        public double BLK { get; set; }

        /// <summary>
        /// Gets or sets steal.
        /// </summary>
        public double STL { get; set; }

        /// <summary>
        /// Gets the player entity.
        /// </summary>
        [NotMapped]
        public virtual Player Player { get; }
    }
}
