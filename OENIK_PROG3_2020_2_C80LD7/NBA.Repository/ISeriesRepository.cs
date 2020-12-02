// <copyright file="ISeriesRepository.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.Repository
{
    using NBA.Data.Model;

    /// <summary>
    /// Describes the repository of series.
    /// </summary>
    public interface ISeriesRepository : IRepository<Series>
    {
        /// <summary>
        /// Update winner team.
        /// </summary>
        /// <param name="year">year of the series.</param>
        /// <param name="newid">new winner team's id.</param>
        void ChangeWinnerId(int year, int newid);

        /// <summary>
        /// Update loser team.
        /// </summary>
        /// <param name="year">year of the series.</param>
        /// <param name="newid">new loser team's id.</param>
        void ChangeLoserId(int year, int newid);

        /// <summary>
        /// Update the final result of the series.
        /// </summary>
        /// <param name="year">Year of the sereies.</param>
        /// <param name="newresult">new final result.</param>
        void ChangeResult(int year, string newresult);
    }
}
