// <copyright file="IPlayerLogic.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using NBA.Data.Model;

    /// <summary>
    /// Describes player specific methods.
    /// </summary>
    public interface IPlayerLogic
    {
        /// <summary>
        /// Return one player entity.
        /// </summary>
        /// <param name="id">player's id.</param>
        /// <returns>player entity.</returns>
        Player GetOnePlayerById(int id);

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
        IList<string> GetPlayerWithTheMostGamesPlayed();

        /// <summary>
        /// How many points a player earned in the series.
        /// </summary>
        /// <returns>average number.</returns>
        IList<Average> GetPlayerAveragePointPerGame();

        /// <summary>
        /// Delete player with the given id.
        /// </summary>
        /// <param name="id">player's id.</param>
        /// <returns>return true or false, depends on that it can be deleted or not.</returns>
        bool DeletePlayer(int id);

        /// <summary>
        /// Changes player's salary.
        /// </summary>
        /// <param name="id">player's id.</param>
        /// <param name="newsalary">player's new salary.</param>
        void ChangePlayerSalary(int id, int newsalary);
    }
}
