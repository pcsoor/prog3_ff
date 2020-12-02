// <copyright file="TeamStats.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.Data.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Creates team statistics table.
    /// </summary>
    [Table("TeamStats")]
    public class TeamStats
    {
        /// <summary>
        /// Gets or sets player id.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamStatID { get; set; }

        /// <summary>
        /// Gets or sets teams id.
        /// </summary>
        [ForeignKey(nameof(Teams))]
        public int TeamID { get; set; }

        /// <summary>
        /// Gets or sets games played.
        /// </summary>
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
        /// Gets or sets one team.
        /// </summary>
        [NotMapped]
        public virtual Teams Teams { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            string context = $"{this.TeamStatID,-6} {this.GP,-6} {this.PPG,-6} {this.REB,-6} {this.STL,-6} {this.AST,-6} {this.BLK,-6} {this.FGM,-6}";
            return context;
        }
    }
}
