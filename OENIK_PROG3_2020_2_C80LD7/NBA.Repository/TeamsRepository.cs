// <copyright file="TeamsRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBA.Repository
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using NBA.Data.Model;

    /// <summary>
    /// Colection of team specific operations.
    /// </summary>
    public class TeamsRepository : Repository<Teams>, ITeamsRepository
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
        /// Returns one team.
        /// </summary>
        /// <param name="id">id of the team.</param>
        /// <returns>Team entity.</returns>
        public override Teams GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.TeamID == id);
        }
    }
}
