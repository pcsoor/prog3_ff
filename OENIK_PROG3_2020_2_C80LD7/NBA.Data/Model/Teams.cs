// <copyright file="Teams.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
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
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the team's coach.
        /// </summary>
        [MaxLength(50)]
        public string Coach { get; set; }

        /// <summary>
        /// Gets or sets the team's region.
        /// </summary>
        [MaxLength(20)]
        public string Region { get; set; }

        /// <summary>
        /// Gets or sets the team's stats.
        /// </summary>
        [NotMapped]
        public virtual TeamStats TeamStats { get; set; }

        /// <summary>
        /// Gets or sets series entity.
        /// </summary>
        [NotMapped]
        public virtual ICollection<Series> Series { get; set; }

        /// <summary>
        /// Gets the player entity.
        /// </summary>
        [NotMapped]
        public virtual ICollection<Player> Players { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return this.Name;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is Teams)
            {
                Teams item = obj as Teams;
                return this.TeamID == item.TeamID && this.Name == item.Name && this.Coach == item.Coach && this.Region == item.Region;
            }

            return false;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.TeamID;
        }
    }
}
