// <copyright file="SeriesRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBA.Repository
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using NBA.Data.Model;

    /// <summary>
    /// This class includes series specific methods.
    /// </summary>
    public class SeriesRepository : Repository<Series>, ISeriesRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SeriesRepository"/> class.
        /// </summary>
        /// <param name="ctx">database.</param>
        public SeriesRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// Returns ine series's data.
        /// </summary>
        /// <param name="id">year of series.</param>
        /// <returns>series.</returns>
        public override Series GetOne(int id)
        {
            throw new NotImplementedException();
        }
    }
}
