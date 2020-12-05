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
        /// Returns all of the team statistics.
        /// </summary>
        /// <returns>collection.</returns>
        IList<TeamStats> GetAllTeamStat();

        /// <summary>
        /// Returns all series result.
        /// </summary>
        /// <returns>collection.</returns>
        IList<Series> GetAllSeriesResult();

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
        bool DeleteTeam(int id);

        /// <summary>
        /// Updates team's name.
        /// </summary>
        /// <param name="id">team's id.</param>
        /// <param name="newname">team's new name.</param>
        void ChangeTeamName(int id, string newname);

        /// <summary>
        /// Update the final result of the series.
        /// </summary>
        /// <param name="year">Year of the sereies.</param>
        /// <param name="newresult">new final result.</param>
        void ChangeFinalResult(int year, string newresult);

        /// <summary>
        /// Update winner team.
        /// </summary>
        /// <param name="year">year of the series.</param>
        /// <param name="newid">new winner team's id.</param>
        void ChangeWinnerId(int year, int newid);

        /// <summary>
        /// Update loser team.
        /// </summary>
        /// <param name="year">year of the series.</param>
        /// <param name="newid">new loser team's id.</param>
        void ChangeLoserId(int year, int newid);

        /// <summary>
        /// Updates one team point per game statistic.
        /// </summary>
        /// <param name="id">stat id.</param>
        /// <param name="newppg">new ppg value.</param>
        void ChangeTeamStatPPG(int id, double newppg);

        /// <summary>
        /// Updates one team assist per game statistic.
        /// </summary>
        /// <param name="id">stat id.</param>
        /// <param name="newassist">new assist value.</param>
        void ChangeTeamStatAST(int id, double newassist);
    }
}
