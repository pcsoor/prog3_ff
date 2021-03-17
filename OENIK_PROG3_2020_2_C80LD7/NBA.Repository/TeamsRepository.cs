// <copyright file="TeamsRepository.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.Repository
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using NBA.Data.Model;

    /// <summary>
    /// Colection of team specific operations.
    /// </summary>
    public class TeamsRepository : NBARepository<Teams>, ITeamsRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TeamsRepository"/> class.
        /// </summary>
        /// <param name="ctx">implements the database.</param>
        public TeamsRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// Changes team's name.
        /// </summary>
        /// <param name="id">team's name.</param>
        /// <param name="newname">team's new name.</param>
        public void ChangeTeamName(int id, string newname)
        {
            var team = this.GetOne(id);
            if (team != null)
            {
                team.Name = newname;
                this.ctx.SaveChanges();
            }
            else
            {
                throw new ArgumentException("This team does not exist with this id!");
            }
        }

        /// <summary>
        /// Returns one team.
        /// </summary>
        /// <param name="id">id of the team.</param>
        /// <returns>Team entity.</returns>
        public override Teams GetOne(int id)
        {
            Teams find = this.GetAll().SingleOrDefault(x => x.TeamID == id);
            if (find != null)
            {
                return find;
            }
            else
            {
                throw new ArgumentException("Player not exist with this id.");
            }
        }

        /// <summary>
        /// Updates team properties.
        /// </summary>
        /// <param name="id"></param>
        public void UpdateTeam(int id)
        {
            var team = this.GetOne(id);
            if (team != null)
            {
                team.TeamID = team.TeamID;
                team.Name = team.Name;
                team.Coach = team.Coach;
                team.Region = team.Region;
                team.Series = team.Series;
                team.TeamStats = team.TeamStats;

                this.ctx.SaveChanges();
            }
        }
    }
}
