﻿// <copyright file="TeamsStatsRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBA.Repository
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using NBA.Data.Model;

    /// <summary>
    /// this class contains Team Statistics.
    /// </summary>
    public class TeamsStatsRepository : Repository<TeamStats>, ITeamsStatsRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TeamsStatsRepository"/> class.
        /// </summary>
        /// <param name="ctx">this param represents the database.</param>
        public TeamsStatsRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <inheritdoc/>
        public override TeamStats GetOne(int id)
        {
            throw new NotImplementedException();
        }
    }
}
