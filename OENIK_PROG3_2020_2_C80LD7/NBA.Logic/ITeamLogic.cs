// <copyright file="ITeamLogic.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
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

        /// <summary>
        /// Get one team.
        /// </summary>
        /// <param name="id">team's id.</param>
        /// <returns>team entity.</returns>
        Teams GetOneTeamById(int id);

        /// <summary>
        /// Gets the quantyt of the wins by teams.
        /// </summary>
        /// <returns>IQueryable list.</returns>
        IList<Average> GetWinQtyByTeams();

        /// <summary>
        /// Deletes a team.
        /// </summary>
        /// <param name="id">team's id.</param>
        /// <returns>return true or false, depends on that it can be deleted or not.</returns>
        public bool DeleteTeam(int id);

        /// <summary>
        /// Updates team's name.
        /// </summary>
        /// <param name="id">team's id.</param>
        /// <param name="newname">team's new name.</param>
        public void ChangeTeamName(int id, string newname);
    }
}
