// <copyright file="IPlayerLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBA.Logic
{
    using System.Collections.Generic;
    using NBA.Data.Model;

    /// <summary>
    /// Describes player specific methods.
    /// </summary>
    public interface IPlayerLogic
    {
        /// <summary>
        /// Gives all of the players.
        /// </summary>
        /// <returns>list.</returns>
        IList<Player> GetAllPlayers();

        /// <summary>
        /// Inserts new player into database.
        /// </summary>
        /// <param name="player">player entity.</param>
        void AddNewPlayer(Player player);
    }
}
