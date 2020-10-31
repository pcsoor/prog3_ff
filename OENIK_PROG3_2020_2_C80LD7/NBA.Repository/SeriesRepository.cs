using Microsoft.EntityFrameworkCore;
using NBA.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NBA.Repository
{
    class SeriesRepository : Repository<Series>, ISeriesRepository
    {
        public SeriesRepository(DbContext ctx) : base(ctx) { }
    }
}
