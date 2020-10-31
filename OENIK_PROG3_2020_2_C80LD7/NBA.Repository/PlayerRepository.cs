using Microsoft.EntityFrameworkCore;
using NBA.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NBA.Repository
{
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        public PlayerRepository(DbContext ctx) : base(ctx) { }

        public override Player GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.PlayerID == id);
        }
    }
}
