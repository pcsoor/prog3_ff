// <copyright file="ITeamLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBA.Logic
{
    using System.Collections.Generic;
    using NBA.Data.Model;

    /// <summary>
    /// Implements Team specific methods.
    /// </summary>
    public interface ITeamLogic
    {
        /// <summary>
        /// Returns list of teams.
        /// </summary>
        /// <returns>Collection.</returns>
        IList<Teams> GetAllTeams();
    }
}
