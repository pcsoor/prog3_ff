// <copyright file="PlayerRepository.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.Repository
{
    using System;
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
            Player find = this.GetAll().SingleOrDefault(x => x.PlayerID == id);
            if (find != null)
            {
                return find;
            }
            else
            {
                throw new ArgumentException("Player not exist with this id.");
            }
        }

        /// <summary>
        /// Change the player's number.
        /// </summary>
        /// <param name="id">id of the player.</param>
        /// <param name="newsalary">player's new salary to update.</param>
        public void ChangeSalary(int id, int newsalary)
        {
            var player = this.GetOne(id);
            if (player != null)
            {
                player.Salary = newsalary;
                this.ctx.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Player not exist with this id.");
            }
        }

        /// <summary>
        /// Updates player's properties.
        /// </summary>
        /// <param name="id">Player type entity id.</param>
        /// <param name="newPlayer">new player.</param>
        /// <returns>true or false.</returns>
        public bool UpdatePlayer(int id, Player newPlayer)
        {
            var player = this.GetOne(id);
            if (player == null || newPlayer == null)
            {
                return false;
            }

            player.PlayerID = newPlayer.PlayerID;
            player.Name = newPlayer.Name;
            player.Number = newPlayer.Number;
            player.Weight = newPlayer.Weight;
            player.Height = newPlayer.Height;
            player.Salary = newPlayer.Salary;
            player.Team = newPlayer.Team;
            player.Post = newPlayer.Post;
            player.Birth = newPlayer.Birth;
            this.ctx.SaveChanges();

            return true;
        }
    }
}
