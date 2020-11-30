// <copyright file="PlayerLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
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
        public Player GetOnePlayerByID(int id)
        {
            return this.playerRepo.GetOne(id);
        }

        /// <summary>
        /// Return how many players are there in the team.
        /// </summary>
        /// <returns>string.</returns>
        public IList<Average> GetPlayerQtyByTeams()
        {
            List<string> list = new List<string>();
            var q = from team in this.teamRepo.GetAll()
                    orderby team.TeamID
                    join player in this.playerRepo.GetAll() on team.TeamID equals player.TeamID
                    group team by team.Name into teams
                    select new Average
                    {
                        Name = teams.Key,
                        Avg = teams.Count(),
                    };

            return q.ToList();
        }

        /// <summary>
        /// Return one player in string format, who played the most.
        /// </summary>
        /// <returns>string.</returns>
        public string GetPlayerWithTheMostGamesPlayed()
        {
            List<string> list = new List<string>();
            var q = from playerStat in this.playerStatsRepo.GetAll()
                    orderby playerStat.GP descending
                    join player in this.playerRepo.GetAll() on playerStat.PlayerID equals player.PlayerID
                    select new
                    {
                        _PLAYER = player.Name,
                        _STAT = playerStat.GP,
                    };

            foreach (var item in q)
            {
                string output = $"{item._PLAYER} - {item._STAT}";
                list.Add(output);
            }

            return list.FirstOrDefault();
        }

        /// <summary>
        /// Delete player entity.
        /// </summary>
        /// <param name="id">player's id.</param>
        /// <returns>true or false, depends on that the id could be found in the database.</returns>
        public bool DeletePlayer(int id)
        {
            if (this.GetOnePlayerByID(id) != null)
            {
                this.playerRepo.Remove(this.GetOnePlayerByID(id));
                return true;
            }

            return false;
        }
    }
}
