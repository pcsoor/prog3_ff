// <copyright file="PlayerStatsRepository.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.Repository
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using NBA.Data.Model;

    /// <summary>
    /// Implements player stat specific operations.
    /// </summary>
    public class PlayerStatsRepository : NBARepository<PlayerStats>, IPlayerStatsRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerStatsRepository"/> class.
        /// </summary>
        /// <param name="ctx">database.</param>
        public PlayerStatsRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// Updates players average point per game.
        /// </summary>
        /// <param name="id">stat id.</param>
        /// <param name="newppg">new ppg value.</param>
        public void ChangePlayerPointsPerGame(int id, double newppg)
        {
            var stat = this.GetOne(id);
            if (stat != null)
            {
                stat.PPG = newppg;
                this.ctx.SaveChanges();
            }
            else
            {
                throw new ArgumentException("This player stat id doesn't exist exist in the database.");
            }
        }

        /// <summary>
        /// Gets one player's statistics.
        /// </summary>
        /// <param name="id">id of player's stat.</param>
        /// <returns>PlayerStat.</returns>
        public override PlayerStats GetOne(int id)
        {
            PlayerStats find = this.GetAll().SingleOrDefault(x => x.PlayerStatID == id);
            if (find != null)
            {
                return find;
            }
            else
            {
                throw new ArgumentException("This player statistic not exist with this id.");
            }
        }
    }
}
