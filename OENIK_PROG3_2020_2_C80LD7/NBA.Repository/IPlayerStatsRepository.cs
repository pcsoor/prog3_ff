// <copyright file="IPlayerStatsRepository.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.Repository
{
    using NBA.Data.Model;

    /// <summary>
    /// Describes the player stats repository.
    /// </summary>
    public interface IPlayerStatsRepository : IRepository<PlayerStats>
    {
        /// <summary>
        /// Updates players average point per game.
        /// </summary>
        /// <param name="id">stat id.</param>
        /// <param name="newppg">new ppg value.</param>
        void ChangePlayerPointsPerGame(int id, double newppg);
    }
}
