// <copyright file="TeamLogic.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
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
        private readonly ISeriesRepository seriesRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamLogic"/> class.
        /// </summary>
        /// <param name="teamRepo">This is teamrepository.</param>
        /// <param name="teamStatsRepo">this is team stat repository.</param>
        /// <param name="seriesRepo">this is series repository.</param>
        public TeamLogic(ITeamsRepository teamRepo, ITeamsStatsRepository teamStatsRepo, ISeriesRepository seriesRepo)
        {
            this.teamRepo = teamRepo;
            this.teamStatsRepo = teamStatsRepo;
            this.seriesRepo = seriesRepo;
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
        public Teams GetOneTeamById(int id)
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

        /// <summary>
        /// Number of wins by teams.
        /// </summary>
        /// <returns>IQueryable.</returns>
        public IList<Average> GetWinQtyByTeams()
        {
            List<string> list = new List<string>();
            var q = from team in this.teamRepo.GetAll()
                    orderby team.TeamID
                    join series in this.seriesRepo.GetAll() on team.TeamID equals series.WinnerID
                    group team by team.Name into g
                    select new Average
                    {
                        Name = g.Key,
                        Avg = g.Count(),
                    };

            return q.ToList();
        }

        /// <summary>
        /// Delete one team by the given id.
        /// </summary>
        /// <param name="id">team's id.</param>
        /// <returns>true or false, depends on that the id could be found in the database.</returns>
        public bool DeleteTeam(int id)
        {
            if (this.GetOneTeamById(id) != null)
            {
                this.teamRepo.Remove(this.GetOneTeamById(id));
                return true;
            }

            return false;
        }

        /// <summary>
        /// Changes team's name.
        /// </summary>
        /// <param name="id">team's id.</param>
        /// <param name="newname">team's new name.</param>
        public void ChangeTeamName(int id, string newname)
        {
            this.teamRepo.ChangeTeamName(id, newname);
        }
    }
}
