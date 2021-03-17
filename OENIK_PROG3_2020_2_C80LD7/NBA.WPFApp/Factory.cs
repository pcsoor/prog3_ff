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
        private readonly NBADbContext ctx;
        private readonly PlayerRepository playerRepo;
        private readonly PlayerStatsRepository playerStatRepo;
        private readonly TeamsRepository teamRepo;
        private readonly TeamsStatsRepository teamStatsRepo;
        private readonly SeriesRepository seriesRepo;
        private readonly PlayerLogic playerLogic;
        private readonly TeamLogic teamLogic;

        /// <summary>
        /// Initializes a new instance of the <see cref="Factory"/> class.
        /// </summary>
        public Factory()
        {
            this.ctx = new NBADbContext();
            this.playerRepo = new PlayerRepository(this.ctx);
            this.teamStatsRepo = new TeamsStatsRepository(this.ctx);
            this.seriesRepo = new SeriesRepository(this.ctx);
            this.playerLogic = new PlayerLogic(this.playerRepo, this.playerStatRepo, this.teamRepo);
            this.playerStatRepo = new PlayerStatsRepository(this.ctx);
            this.teamRepo = new TeamsRepository(this.ctx);
            this.teamLogic = new TeamLogic(this.teamRepo, this.teamStatsRepo, this.seriesRepo);
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
