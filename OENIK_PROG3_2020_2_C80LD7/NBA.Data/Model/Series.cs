// <copyright file="Series.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.Data.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Creates and sets the series table.
    /// </summary>
    [Table("Series")]
    public class Series
    {
        /// <summary>
        /// Gets or sets the year of the series.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets the winner team's id.
        /// </summary>
        [ForeignKey(nameof(Teams))]
        public int WinnerID { get; set; }

        /// <summary>
        /// Gets or sets the loser team's id.
        /// </summary>
        [ForeignKey(nameof(Teams))]
        public int LoserID { get; set; }

        /// <summary>
        /// Gets or sets the final result.
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// Gets or sets the team entity.
        /// </summary>
        [NotMapped]
        public virtual Teams Teams { get; set; }

        /// <summary>
        /// Overrides ToString method.
        /// </summary>
        /// <returns>string.</returns>
        public override string ToString()
        {
            string tartalom = $"{this.Year,-4} {this.WinnerID,-4} {this.LoserID,-4} {this.Result,-4}";
            return tartalom;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is Series)
            {
                Series item = obj as Series;
                return this.Year == item.Year && this.WinnerID == item.WinnerID && this.LoserID == item.LoserID && this.Result == item.Result;
            }

            return false;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.Year;
        }
    }
}
