// <copyright file="PlayerLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBA.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using NBA.Data.Model;
    using NBA.Repository;

    /// <summary>
    /// Implements player specific methods.
    /// </summary>
    public class PlayerLogic : IPlayerLogic
    {
        private readonly IPlayerRepository playerRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerLogic"/> class.
        /// </summary>
        /// <param name="repo">player specific methods.</param>
        public PlayerLogic(IPlayerRepository repo)
        {
            this.playerRepo = repo;
        }

        /// <inheritdoc/>
        public IList<Player> GetAllPlayers()
        {
            return this.playerRepo.GetAll().ToList();
        }

        /// <inheritdoc/>
        public void AddNewPlayer(Player player)
        {
            this.playerRepo.Insert(player);
        }

        /// <summary>
        /// Gives you one player.
        /// </summary>
        /// <param name="id">id of the player.</param>
        /// <returns>Player entity.</returns>
        public Player GetOnePlayerByID(int id)
        {
            return this.playerRepo.GetOne(id);
        }
    }
}
