// <copyright file="PlayerLogic.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>
[assembly: System.CLSCompliant(false)]

namespace NBA.Logic
{
    using System.Collections.Generic;
    using System.Linq;
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
                    let item = new { TeamName = team.Name, PlayerID = player.PlayerID }
                    group item by item.TeamName into g
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
        /// Delete player entity.
        /// </summary>
        /// <param name="id">player's id.</param>
        /// <returns>true or false, depends on that the id could be found in the database.</returns>
        public bool DeletePlayer(int id)
        {
            if (this.GetOnePlayerById(id) != null)
            {
                this.playerRepo.Remove(this.GetOnePlayerById(id));
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
        /// Change player's salary.
        /// </summary>
        /// <param name="id">player's id.</param>
        /// <param name="newsalary">player's new salary to update.</param>
        public void ChangePlayerSalary(int id, int newsalary)
        {
            this.playerRepo.ChangeSalary(id, newsalary);
        }

        public IList<Player> GetPlayerByTeam(int team)
        {
            return this.playerRepo.GetAll().Where(x => x.TeamID == team).ToList();
        }
    }
}
