// <copyright file="PlayerLogic.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>
[assembly: System.CLSCompliant(false)]

namespace NBA.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using NBA.Data.Model;
    using NBA.Repository;

    /// <summary>
    /// Implements player specific methods.
    /// </summary>
    public class PlayerLogic : IPlayerLogic
    {
        private readonly IPlayerRepository playerRepo;
        private readonly IPlayerStatsRepository playerStatsRepo;
        private readonly ITeamsRepository teamRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerLogic"/> class.
        /// </summary>
        /// <param name="playerRepo">player entity.</param>
        /// <param name="playerStatsRepo">team entity.</param>
        /// <param name="teamRepo">play statistics.</param>
        public PlayerLogic(IPlayerRepository playerRepo, IPlayerStatsRepository playerStatsRepo, ITeamsRepository teamRepo)
        {
            this.playerRepo = playerRepo;
            this.playerStatsRepo = playerStatsRepo;
            this.teamRepo = teamRepo;
        }

        /// <inheritdoc/>
        public IList<Player> GetAllPlayers()
        {
            return this.playerRepo.GetAll().ToList();
        }

        /// <inheritdoc/>
        public void AddNewPlayer(Player player)
        {
            this.playerRepo.Insert(player);
        }

        /// <summary>
        /// Changes given players properties.
        /// </summary>
        /// <param name="player">player to change.</param>
        /// <returns>bool.</returns>
        public bool ChangePlayer(Player player)
        {
            var team = this.teamRepo.GetAll().SingleOrDefault(x => x.Name == player.Team.Name);
            if (team == null || player == null)
            {
                return false;
            }
            else
            {
                this.playerRepo.UpdatePlayer(player.PlayerID, player);
                return true;
            }
        }

        /// <summary>
        /// Gives you one player.
        /// </summary>
        /// <param name="id">id of the player.</param>
        /// <returns>Player entity.</returns>
        public Player GetOnePlayerById(int id)
        {
            return this.playerRepo.GetOne(id);
        }

        /// <summary>
        /// Return how many players are there in the team.
        /// </summary>
        /// <returns>string.</returns>
        public IList<Average> GetPlayerQtyByTeams()
        {
            var q = from player in this.playerRepo.GetAll()
                    join team in this.teamRepo.GetAll() on player.TeamID equals team.TeamID
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
        /// Return one player in string format, who played the most.
        /// </summary>
        /// <returns>string.</returns>
        public IList<string> GetPlayerWithTheMostGamesPlayed()
        {
            List<string> list = new List<string>();
            var q = from playerStat in this.playerStatsRepo.GetAll()
                    orderby playerStat.GP descending
                    join player in this.playerRepo.GetAll() on playerStat.PlayerID equals player.PlayerID
                    let item = new { StatID = playerStat.PlayerStatID, PlayerName = player.Name }
                    select new
                    {
                        item.PlayerName,
                    };

            foreach (var item in q)
            {
                string output = item.PlayerName;
                list.Add(output);
            }

            return list;
        }

        /// <summary>
        /// Gets player who played the most.
        /// </summary>
        /// <returns>List of Averages.</returns>
        public Task<IList<string>> GetPlayerWithTheMostGamesPlayedAsync()
        {
            Task<IList<string>> task = Task.Run(() => this.GetPlayerWithTheMostGamesPlayed());

            return task;
        }

        /// <summary>
        /// Delete player entity.
        /// </summary>
        /// <param name="id">player's id.</param>
        /// <returns>true or false, depends on that the id could be found in the database.</returns>
        public bool DeletePlayer(int id)
        {
            if (this.playerRepo.GetAll().ToList().Contains(this.GetOnePlayerById(id)))
            {
                this.playerRepo.Remove(id);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Get one players average point per game by series.
        /// </summary>
        /// <returns>IQueryable.</returns>
        public IList<Average> GetPlayerAveragePointPerGame()
        {
            var q = from player in this.playerRepo.GetAll()
                    join stats in this.playerStatsRepo.GetAll() on player.PlayerID equals stats.PlayerID
                    let item = new { PlayerName = player.Name, PPG = stats.PPG }
                    group item by item.PlayerName into g
                    select new Average
                    {
                        Name = g.Key,
                        Avg = g.Average(item => item.PPG),
                    };
            return q.ToList();
        }

        /// <summary>
        /// Gets player's average points per game from the past season.
        /// </summary>
        /// <returns>List of Averages.</returns>
        public Task<IList<Average>> GetPlayerAveragePointPerGameAsync()
        {
            Task<IList<Average>> task = Task.Run(() => this.GetPlayerAveragePointPerGame());

            return task;
        }

        /// <summary>
        /// Change player's salary.
        /// </summary>
        /// <param name="id">player's id.</param>
        /// <param name="newsalary">player's new salary to update.</param>
        public void ChangePlayerSalary(int id, int newsalary)
        {
            this.playerRepo.ChangeSalary(id, newsalary);
        }

        /// <summary>
        /// Updates player entity.
        /// </summary>
        /// <param name="id">Player type entity.</param>
        /// <returns>true or false.</returns>
        public bool UpdatePlayer(int id)
        {
            var player = this.GetOnePlayerById(id);
            if (!this.playerRepo.GetAll().ToList().Contains(this.GetOnePlayerById(id)))
            {
                return false;
            }

            return this.playerRepo.UpdatePlayer(id, player);
        }

        /// <summary>
        /// Return players in one team.
        /// </summary>
        /// <param name="team">team's id.</param>
        /// <returns>List of players.</returns>
        public IList<Player> GetPlayerByTeam(int team)
        {
            return this.playerRepo.GetAll().Where(x => x.TeamID == team).ToList();
        }

        /// <summary>
        /// Delete player statistic if the id exists.
        /// </summary>
        /// <param name="id">player stat id.</param>
        /// <returns>true or false, depends on that the id could be found in the database.</returns>
        public bool DeletePlayerStatistic(int id)
        {
            if (this.playerStatsRepo.GetAll().ToList().Contains(this.GetOnePlayerStatById(id)))
            {
                this.playerStatsRepo.Remove(id);
                return true;
            }

            return false;
        }

        /// <summary>
        /// eturns one player stat if the id exists.
        /// </summary>
        /// <param name="id">player stat id.</param>
        /// <returns>Player stat.</returns>
        public PlayerStats GetOnePlayerStatById(int id)
        {
            return this.playerStatsRepo.GetOne(id);
        }

        /// <summary>
        /// Returns a list of player statistics.
        /// </summary>
        /// <returns>Returns a list.</returns>
        public IList<PlayerStats> GetAllPlayerStat()
        {
            return this.playerStatsRepo.GetAll().ToList();
        }

        /// <summary>
        /// Adds new player statistic into the database.
        /// </summary>
        /// <param name="playerStatistic">player statistic entity that needs to be inserted.</param>
        public void AddNewPlayerStat(PlayerStats playerStatistic)
        {
            this.playerStatsRepo.Insert(playerStatistic);
        }

        /// <summary>
        /// Finds a team by its name.
        /// </summary>
        /// <param name="teamName">team's name.</param>
        /// <returns>found team.</returns>
        public Teams FindTeamByName(string teamName)
        {
            var team = this.teamRepo.GetAll().SingleOrDefault(x => x.Name == teamName);
            if (team == null)
            {
                throw new ArgumentException("INVALID TEAM");
            }
            else
            {
                return team;
            }
        }
    }
}
