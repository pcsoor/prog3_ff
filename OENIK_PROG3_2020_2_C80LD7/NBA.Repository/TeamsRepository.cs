using Microsoft.EntityFrameworkCore;
using NBA.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NBA.Repository
{
    public class TeamsRepository : Repository<Teams>, ITeamsRepository
    {
        public TeamsRepository(DbContext ctx) : base(ctx) { }


        public override Teams GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.TeamID == id);
        }
    }
}
