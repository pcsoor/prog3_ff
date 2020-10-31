using Microsoft.EntityFrameworkCore;
using NBA.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NBA.Repository
{
    class TeamsStatsRepository : Repository<TeamStats>, ITeamsStatsRepository
    {
        public TeamsStatsRepository(DbContext ctx) : base(ctx) { }
    }
}
