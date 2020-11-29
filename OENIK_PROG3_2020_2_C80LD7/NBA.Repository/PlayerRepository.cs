// <copyright file="PlayerRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBA.Repository
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using NBA.Data.Model;

    /// <summary>
    /// Player specific methods made in this class.
    /// </summary>
    public class PlayerRepository : NBARepository<Player>, IPlayerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerRepository"/> class.
        /// </summary>
        /// <param name="ctx">database.</param>
        public PlayerRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <inheritdoc/>
        public override Player GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.PlayerID == id);
        }

        /// <summary>
        /// Change the player's number.
        /// </summary>
        /// <param name="id">id of the player.</param>
        /// <param name="number">player's number.</param>
        public void ChangeNumber(int id, int number)
        {
            this.GetOne(id);
        }
    }
}
