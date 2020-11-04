using Microsoft.EntityFrameworkCore;
using NBA.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NBA.Repository
{
    public class SeriesRepository : Repository<Series>, ISeriesRepository
    {
        public SeriesRepository(DbContext ctx) : base(ctx) { }

        
        public override Series GetOne(int id)
        {
            throw new NotImplementedException();
        }
    }
}
