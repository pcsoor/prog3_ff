// <copyright file="Team.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Team model.
    /// </summary>
    public class Team
    {
        /// <summary>
        /// Gets or sets the id of the team.
        /// </summary>
        [Display(Name = "Team Id")]
        [Required]
        public int TeamID { get; set; }

        /// <summary>
        /// Gets or sets the name of the team.
        /// </summary>
        [Display(Name = "Team Name")]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string TeamName { get; set; }

        /// <summary>
        /// Gets or sets the team's coach.
        /// </summary>
        [Display(Name = "Team Coach")]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Coach { get; set; }

        /// <summary>
        /// Gets or sets the team's region.
        /// </summary>
        [Display(Name = "Team Region")]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Region { get; set; }
    }
}
