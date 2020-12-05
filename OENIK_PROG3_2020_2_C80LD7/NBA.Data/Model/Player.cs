// <copyright file="Player.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.Data.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// This class represents the player entity.
    /// </summary>
    [Table("Player")]
    public class Player
    {
        /// <summary>
        /// Gets or sets unique identitication of player.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayerID { get; set; }

        /// <summary>
        /// Gets or sets the team id where the player plays currently.
        /// </summary>
        [ForeignKey(nameof(Teams))]
        public int TeamID { get; set; }

        /// <summary>
        /// Gets or sets the name of the player.
        /// </summary>
        [MaxLength(50)]
        public string Name { get; set; }

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
        /// Gets or sets the position where the player plays.
        /// </summary>
        [MaxLength(10)]
        public string Post { get; set; }

        /// <summary>
        /// Gets or sets the avarage salary.
        /// </summary>
        public int Salary { get; set; }

        /// <summary>
        /// Gets or sets the player's number.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Gets or sets the player's statistics in the current season.
        /// </summary>
        [NotMapped]
        public virtual PlayerStats PlayerStats { get; set; }

        /// <summary>
        /// Gets or sets one team.
        /// </summary>
        [NotMapped]
        public virtual Teams Teams { get; set; }

        /// <summary>
        /// Returns the player's data.
        /// </summary>
        /// <returns>string.</returns>
        public override string ToString()
        {
            string context = $"{this.PlayerID,-4} {this.Name,-20} {this.Birth.ToShortDateString(),-15} {this.Height,-8} {this.Weight,-8} {this.Post,-8} {this.Number,-12} {this.Salary:n0}";
            return context;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is Player)
            {
                Player secondPlayer = obj as Player;
                return this.PlayerID == secondPlayer.PlayerID && this.Name == secondPlayer.Name && this.Birth == secondPlayer.Birth && this.Height == secondPlayer.Height && this.Weight == secondPlayer.Weight && this.TeamID == secondPlayer.TeamID && this.Post == secondPlayer.Post && this.Salary == secondPlayer.Salary && this.Number == secondPlayer.Number;
            }

            return false;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.PlayerID;
        }
    }
}
