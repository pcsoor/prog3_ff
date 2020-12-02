// <copyright file="TeamsStatsRepository.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.Repository
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using NBA.Data.Model;

    /// <summary>
    /// this class contains Team Statistics.
    /// </summary>
    public class TeamsStatsRepository : NBARepository<TeamStats>, ITeamsStatsRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TeamsStatsRepository"/> class.
        /// </summary>
        /// <param name="ctx">this param represents the database.</param>
        public TeamsStatsRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// Updates one team assist per game statistic.
        /// </summary>
        /// <param name="id">stat id.</param>
        /// <param name="newassist">new assist value.</param>
        public void ChangeTeamAssists(int id, double newassist)
        {
            var stat = this.GetOne(id);
            if (stat != null)
            {
                stat.AST = newassist;
                this.ctx.SaveChanges();
            }
            else
            {
                throw new ArgumentException("This team stat id doesn't exist exist in the database.");
            }
        }

        /// <summary>
        /// Updates one team point per game statistic.
        /// </summary>
        /// <param name="id">stat id.</param>
        /// <param name="newppg">new ppg value.</param>
        public void ChangeTeamPointsPerGame(int id, double newppg)
        {
            var stat = this.GetOne(id);
            if (stat != null)
            {
                stat.PPG = newppg;
                this.ctx.SaveChanges();
            }
            else
            {
                throw new ArgumentException("This team stat id doesn't exist exist in the database.");
            }
        }

        /// <inheritdoc/>
        public override TeamStats GetOne(int id)
        {
            TeamStats find = this.GetAll().SingleOrDefault(x => x.TeamStatID == id);
            if (find != null)
            {
                return find;
            }
            else
            {
                throw new ArgumentException("This team stat id doesn't exist exist in the database.");
            }
        }
    }
}
