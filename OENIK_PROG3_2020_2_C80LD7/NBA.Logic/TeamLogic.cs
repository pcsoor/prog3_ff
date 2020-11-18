// <copyright file="TeamLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBA.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using NBA.Data.Model;
    using NBA.Repository;

    /// <summary>
    /// This class implements team specific methods.
    /// </summary>
    public class TeamLogic : ITeamLogic
    {
        private readonly ITeamsRepository teamRepo;
        private readonly ITeamsStatsRepository teamStatsRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamLogic"/> class.
        /// </summary>
        /// <param name="teamRepo">This is teamrepository.</param>
        /// <param name="teamStatsRepo">this is team stat repository.</param>
        public TeamLogic(ITeamsRepository teamRepo, ITeamsStatsRepository teamStatsRepo)
        {
            this.teamRepo = teamRepo;
            this.teamStatsRepo = teamStatsRepo;
        }

        /// <inheritdoc/>
        public IList<Teams> GetAllTeams()
        {
            return this.teamRepo.GetAll().ToList();
        }

        /// <summary>
        /// Returns one team.
        /// </summary>
        /// <param name="id">id of the team.</param>
        /// <returns>reeturn one team.</returns>
        public Teams GetOneTeam(int id)
        {
            return this.teamRepo.GetOne(id);
        }

        /// <summary>
        /// Returns all of the team statistics.
        /// </summary>
        /// <returns>collection.</returns>
        public IList<TeamStats> GetAllTeamStat()
        {
            return this.teamStatsRepo.GetAll().ToList();
        }

        // NON-CRUD methods
    }
}
