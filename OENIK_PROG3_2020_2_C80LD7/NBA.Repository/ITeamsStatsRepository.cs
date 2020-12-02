// <copyright file="ITeamsStatsRepository.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.Repository
{
    using NBA.Data.Model;

    /// <summary>
    /// Describe team stat methods.
    /// </summary>
    public interface ITeamsStatsRepository : IRepository<TeamStats>
    {
        /// <summary>
        /// Updates one team point per game statistic.
        /// </summary>
        /// <param name="id">stat id.</param>
        /// <param name="newppg">new ppg value.</param>
        void ChangeTeamPointsPerGame(int id, double newppg);

        /// <summary>
        /// Updates one team assist per game statistic.
        /// </summary>
        /// <param name="id">stat id.</param>
        /// <param name="newassist">new assist value.</param>
        void ChangeTeamAssists(int id, double newassist);
    }
}
