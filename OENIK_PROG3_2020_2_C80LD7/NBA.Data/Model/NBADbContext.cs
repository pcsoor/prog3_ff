using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace NBA.Data.Model
{
    class NBADbContext : DbContext
    {
        public NBADbContext()
        {
            this.Database.EnsureCreated();
        }

        public NBADbContext(DbContextOptions<NBADbContext> options) : base(options) {}

        public virtual DbSet<Player> Player { get; set; }
        
        public virtual DbSet<Teams> Teams{ get; set; }

        public virtual DbSet<Series> Series{ get; set; }

        public virtual DbSet<TeamStats> TeamStats{ get; set; }

        public virtual DbSet<PlayerStats> PlayerStats{ get; set; }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\NBADatabase.mdf; Integrated Security = True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Player p0 = new Player() { PlayerID=0, Name="Lebron James", Birth='1984.12.30'}
        }

    }
}
