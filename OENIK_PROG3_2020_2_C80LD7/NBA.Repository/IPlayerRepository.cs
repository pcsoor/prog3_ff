// <copyright file="IPlayerRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
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
        /// <param name="number">player's number.</param>
        void ChangeNumber(int id, int number);
    }
}
