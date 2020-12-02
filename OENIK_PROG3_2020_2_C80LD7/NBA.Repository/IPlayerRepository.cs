// <copyright file="IPlayerRepository.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.Repository
{
    using NBA.Data.Model;

    /// <summary>
    /// Player specific methods.
    /// </summary>
    public interface IPlayerRepository : IRepository<Player>
    {
        /// <summary>
        /// Change the player's number.
        /// </summary>
        /// <param name="id">player's id.</param>
        /// <param name="newsalary">player's new salary to update.</param>
        void ChangeSalary(int id, int newsalary);
    }
}
