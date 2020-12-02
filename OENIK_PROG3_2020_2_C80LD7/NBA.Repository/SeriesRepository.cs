// <copyright file="SeriesRepository.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.Repository
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using NBA.Data.Model;

    /// <summary>
    /// This class includes series specific methods.
    /// </summary>
    public class SeriesRepository : NBARepository<Series>, ISeriesRepository
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
        /// Update loser team.
        /// </summary>
        /// <param name="year">year of the series.</param>
        /// <param name="newid">new loser team's id.</param>
        public void ChangeLoserId(int year, int newid)
        {
            var series = this.GetOne(year);
            if (series != null)
            {
                series.LoserID = newid;
                this.ctx.SaveChanges();
            }
            else
            {
                throw new ArgumentException("This year doesn't exist exist in the database.");
            }
        }

        /// <summary>
        /// Update the final result of the series.
        /// </summary>
        /// <param name="year">Year of the sereies.</param>
        /// <param name="newresult">new final result.</param>
        public void ChangeResult(int year, string newresult)
        {
            var series = this.GetOne(year);
            if (series != null)
            {
                series.Result = newresult;
                this.ctx.SaveChanges();
            }
            else
            {
                throw new ArgumentException("This year doesn't exist exist in the database.");
            }
        }

        /// <summary>
        /// Update winner team.
        /// </summary>
        /// <param name="year">year of the series.</param>
        /// <param name="newid">new winner team's id.</param>
        public void ChangeWinnerId(int year, int newid)
        {
            var series = this.GetOne(year);
            if (series != null)
            {
                series.WinnerID = newid;
                this.ctx.SaveChanges();
            }
            else
            {
                throw new ArgumentException("This year doesn't exist exist in the database.");
            }
        }

        /// <summary>
        /// Returns ine series's data.
        /// </summary>
        /// <param name="id">year of series.</param>
        /// <returns>series.</returns>
        public override Series GetOne(int id)
        {
            Series find = this.GetAll().SingleOrDefault(x => x.Year == id);
            if (find != null)
            {
                return find;
            }
            else
            {
                throw new ArgumentException("This year doesn't exist exist in the database.");
            }
        }
    }
}
