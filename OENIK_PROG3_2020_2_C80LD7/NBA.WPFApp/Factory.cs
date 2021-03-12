using NBA.Data.Model;
using NBA.Logic;
using NBA.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA.WPFApp
{
    public class Factory
    {
        public Factory()
        {
            this.Ctx = new NBADbContext();
            this.PlayerRepo = new PlayerRepository(this.Ctx);
            this.PlayerLogic = new PlayerLogic(this.PlayerRepo, this.PlayerStatRepo, this.TeamRepo);
        }

        public NBADbContext Ctx { get; set; }

        public PlayerRepository PlayerRepo { get; set; }

        public PlayerStatsRepository PlayerStatRepo { get; set; }

        public TeamsRepository TeamRepo { get; set; }

        public PlayerLogic PlayerLogic { get; set; }

    }
}
