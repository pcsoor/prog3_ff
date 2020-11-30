// <copyright file="Teams.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBA.Data.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Creates ant sets the team table.
    /// </summary>
    [Table("Teams")]
    public class Teams
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Teams"/> class.
        /// </summary>
        public Teams()
        {
            this.Series = new HashSet<Series>();
        }

        /// <summary>
        /// Gets or sets the id of the team.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamID { get; set; }

        /// <summary>
        /// Gets or sets the name of the team.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the team's coach.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Coach { get; set; }

        /// <summary>
        /// Gets or sets the team's region.
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Region { get; set; }

        /// <summary>
        /// Gets or sets the team's stats.
        /// </summary>
        [NotMapped]
        public virtual TeamStats TeamStats { get; set; }

        /// <summary>
        /// Gets or sets the collection of series.
        /// Navigation property.
        /// </summary>
        [NotMapped]
        public virtual IReadOnlyCollection<Series> Series { get; set; }

        /// <summary>
        /// Gets the player entity.
        /// </summary>
        [NotMapped]
        public virtual ICollection<Player> Players { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            string tartalom = $"{this.TeamID,-4} {this.Name,-25} {this.Coach,-20} {this.Region,-1}";
            return tartalom;
        }
    }
}
