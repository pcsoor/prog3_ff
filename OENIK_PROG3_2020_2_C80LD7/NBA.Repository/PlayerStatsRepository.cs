using Microsoft.EntityFrameworkCore;
using NBA.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NBA.Repository
{
    public class PlayerStatsRepository : Repository<PlayerStats>, IPlayerStatsRepository
    {
        public PlayerStatsRepository(DbContext ctx) : base(ctx) { }

       

        public override PlayerStats GetOne(int id)
        {
            throw new NotImplementedException();
        }
    }
}
