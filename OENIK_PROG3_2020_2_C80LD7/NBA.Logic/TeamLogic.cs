// <copyright file="TeamLogic.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
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
                    join series in this.seriesRepo.GetAll() on team.TeamID equals series.WinnerID
                    group team by team.Name into g
                    orderby g.Key
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
                this.teamRepo.Remove(id);
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

        /// <summary>
        /// Update the final result of the series.
        /// </summary>
        /// <param name="year">Year of the sereies.</param>
        /// <param name="newresult">new final result.</param>
        public void ChangeFinalResult(int year, string newresult)
        {
            this.seriesRepo.ChangeResult(year, newresult);
        }

        /// <summary>
        /// Updates winner team.
        /// </summary>
        /// <param name="year">year of the series.</param>
        /// <param name="newid">new winner team's id.</param>
        public void ChangeWinnerId(int year, int newid)
        {
            this.seriesRepo.ChangeWinnerId(year, newid);
        }

        /// <summary>
        /// Update loser team.
        /// </summary>
        /// <param name="year">year of the series.</param>
        /// <param name="newid">new loser team's id.</param>
        public void ChangeLoserId(int year, int newid)
        {
            this.seriesRepo.ChangeLoserId(year, newid);
        }

        /// <summary>
        /// Updates one team point per game statistic.
        /// </summary>
        /// <param name="id">stat id.</param>
        /// <param name="newppg">new ppg value.</param>
        public void ChangeTeamStatPPG(int id, double newppg)
        {
            this.teamStatsRepo.ChangeTeamPointsPerGame(id, newppg);
        }

        /// <summary>
        /// Updates one team assist per game statistic.
        /// </summary>
        /// <param name="id">stat id.</param>
        /// <param name="newassist">new assist value.</param>
        public void ChangeTeamStatAST(int id, double newassist)
        {
            this.teamStatsRepo.ChangeTeamAssists(id, newassist);
        }

        /// <summary>
        /// Returns all series result.
        /// </summary>
        /// <returns>collection.</returns>
        public IList<Series> GetAllSeriesResult()
        {
            return this.seriesRepo.GetAll().ToList();
        }

        /// <summary>
        /// Get average steals by teams.
        /// </summary>
        /// <returns>IQueryable list.</returns>
        public IList<Average> GetTeamAverageStealPerGame()
        {
            var q = from team in this.teamRepo.GetAll()
                    join stats in this.teamStatsRepo.GetAll() on team.TeamID equals stats.TeamID
                    let item = new { PlayerName = team.Name, STL = stats.STL }
                    group item by item.PlayerName into g
                    orderby g.Key
                    select new Average
                    {
                        Name = g.Key,
                        Avg = g.Average(item => item.STL),
                    };
            return q.ToList();
        }

        /// <summary>
        /// Gets average steals per game in one team with async task.
        /// </summary>
        /// <returns>task.</returns>
        public Task<IList<Average>> GetTeamAverageStealPerGameAsync()
        {
            Task<IList<Average>> task = Task.Run(() => this.GetTeamAverageStealPerGame());

            return task;
        }

        /// <summary>
        /// Returns one team statisic by id.
        /// </summary>
        /// <param name="id">team statistic's id.</param>
        /// <returns>one team statistic entity.</returns>
        public TeamStats GetOneTeamStatById(int id)
        {
            return this.teamStatsRepo.GetOne(id);
        }

        /// <summary>
        /// Get one series by id.
        /// </summary>
        /// <param name="id">series's id.</param>
        /// <returns>one series entity.</returns>
        public Series GetOneSeriesId(int id)
        {
            return this.seriesRepo.GetOne(id);
        }

        /// <summary>
        /// Deletes one team statistic if the if exists.
        /// </summary>
        /// <param name="id">team statistic's entity that needs to be deleted.</param>
        /// <returns>true or false, depends on that the id could be fuond in the database.</returns>
        public bool DeleteTeamStat(int id)
        {
            if (this.teamStatsRepo.GetAll().ToList().Contains(this.GetOneTeamStatById(id)))
            {
                this.teamStatsRepo.Remove(id);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Deletes one series if the if exists.
        /// </summary>
        /// <param name="id">series's entity that needs to be deleted.</param>
        /// <returns>true or false, depends on that the id could be fuond in the database.</returns>
        public bool DeleteSeries(int id)
        {
            if (this.seriesRepo.GetAll().ToList().Contains(this.GetOneSeriesId(id)))
            {
                this.seriesRepo.Remove(id);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Inserts new team into the database.
        /// </summary>
        /// <param name="team">team entity that needs to be inserted.</param>
        public void AddNewTeam(Teams team)
        {
            this.teamRepo.Insert(team);
        }

        /// <summary>
        /// Inserts new team statistic into the database.
        /// </summary>
        /// <param name="teamStatistic">team statistic entity that needs to be inserted.</param>
        public void AddNewTeamStat(TeamStats teamStatistic)
        {
            this.teamStatsRepo.Insert(teamStatistic);
        }

        /// <summary>
        /// Inserts new series into the database.
        /// </summary>
        /// <param name="series">series entity that needs to be inserted.</param>
        public void AddNewSeries(Series series)
        {
            this.seriesRepo.Insert(series);
        }
    }
}
