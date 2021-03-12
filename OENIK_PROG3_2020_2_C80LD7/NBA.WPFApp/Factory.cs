using NBA.Data.Model;
using NBA.Logic;
using NBA.Repository;
using NBA.WPFApp.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA.WPFApp
{
    public class Factory
    {
        NBADbContext ctx;
        PlayerRepository playerRepo;
        PlayerStatsRepository playerStatRepo;
        TeamsRepository teamRepo;
        PlayerLogic playerLogic;

        public Factory()
        {
            this.ctx = new NBADbContext();
            this.playerRepo = new PlayerRepository(this.ctx);
            this.playerLogic = new PlayerLogic(this.playerRepo, this.playerStatRepo, this.teamRepo);
            this.playerStatRepo = new PlayerStatsRepository(this.ctx);
            this.teamRepo = new TeamsRepository(this.ctx);
        }

        public PlayerLogic PlayerLogic
        {
            get { return this.playerLogic; }
        }
    }
}
