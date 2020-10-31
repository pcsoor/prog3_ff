using Microsoft.EntityFrameworkCore;
using NBA.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NBA.Repository
{
    class TeamsRepository : Repository<Teams>, ITeamsRepository
    {
        public TeamsRepository(DbContext ctx) : base(ctx) { }
    }
}
