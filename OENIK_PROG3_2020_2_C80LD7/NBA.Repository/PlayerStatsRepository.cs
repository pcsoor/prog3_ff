// <copyright file="PlayerStatsRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBA.Repository
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using NBA.Data.Model;

    /// <summary>
    /// Implements player stat specific operations.
    /// </summary>
    public class PlayerStatsRepository : Repository<PlayerStats>, IPlayerStatsRepository
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
        /// Gets one player.
        /// </summary>
        /// <param name="id">id of player's stat.</param>
        /// <returns>PlayerStat.</returns>
        public override PlayerStats GetOne(int id)
        {
            throw new NotImplementedException();
        }
    }
}
