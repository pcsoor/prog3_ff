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
    }
}
