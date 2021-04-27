// <copyright file="PlayerListViewModel.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// List of players class.
    /// </summary>
    public class PlayerListViewModel
    {
        /// <summary>
        /// Gets or sets list of players.
        /// </summary>
        public List<Player> ListOfPlayers { get; set; }

        /// <summary>
        /// Gets or sets player to edit.
        /// </summary>
        public Player EditedPlayer { get; set; }
    }
}
