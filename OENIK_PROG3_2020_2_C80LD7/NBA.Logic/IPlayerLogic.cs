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

        /// <summary>
        /// Returns how many player plays in each team.
        /// </summary>
        /// <returns>list.</returns>
        IList<Average> GetPlayerQtyByTeams();

        /// <summary>
        /// Return one player, who played the most game in the current series.
        /// </summary>
        /// <returns>player.</returns>
        string GetPlayerWithTheMostGamesPlayed();

        /// <summary>
        /// Delete player with the given id.
        /// </summary>
        /// <param name="id">player's id.</param>
        /// <returns>return true or false, depends on that it can be deleted or not.</returns>
        bool DeletePlayer(int id);
    }
}
