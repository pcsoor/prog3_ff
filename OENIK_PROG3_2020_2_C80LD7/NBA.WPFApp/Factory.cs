// <copyright file="Factory.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.WPFApp
{
    using NBA.Data.Model;
    using NBA.Logic;
    using NBA.Repository;

    /// <summary>
    /// Factory class.
    /// </summary>
    public class Factory
    {
        private NBADbContext ctx;
        private PlayerRepository playerRepo;
        private PlayerStatsRepository playerStatRepo;
        private TeamsRepository teamRepo;
        private PlayerLogic playerLogic;

        /// <summary>
        /// Initializes a new instance of the <see cref="Factory"/> class.
        /// </summary>
        public Factory()
        {
            this.ctx = new NBADbContext();
            this.playerRepo = new PlayerRepository(this.ctx);
            this.playerLogic = new PlayerLogic(this.playerRepo, this.playerStatRepo, this.teamRepo);
            this.playerStatRepo = new PlayerStatsRepository(this.ctx);
            this.teamRepo = new TeamsRepository(this.ctx);
        }

        /// <summary>
        /// Gets player logic.
        /// </summary>
        public PlayerLogic PlayerLogic
        {
            get { return this.playerLogic; }
        }

        /// <summary>
        /// Gets db context.
        /// </summary>
        public NBADbContext Ctx
        {
            get { return this.ctx; }
        }
    }
}
