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

        /// <summary>
        /// Gets or sets each player.
        /// </summary>
        public virtual DbSet<Player> Player { get; set; }

        /// <summary>
        /// Gets or sets nba teams.
        /// </summary>
        public virtual DbSet<Teams> Teams{ get; set; }

        /// <summary>
        /// Gets or sets an nba series.
        /// </summary>
        public virtual DbSet<Series> Series{ get; set; }

        /// <summary>
        /// Gets or sets team statistics.
        /// </summary>
        public virtual DbSet<TeamStats> TeamStats{ get; set; }

        /// <summary>
        /// Gets or sets player statistics.
        /// </summary>
        public virtual DbSet<PlayerStats> PlayerStats{ get; set; }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\NBADatabase.mdf; Integrated Security = True");
            }
        }

        /// <summary>
        /// OnModelCreating.
        /// </summary>
        /// <param name="modelBuilder">modelBuilder</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Player p0 = new Player() { PlayerID = 0, Name = "Lebron James", Birth = new DateTime(1984, 12, 20), Height = 206, Weight = 113, Number = 23, Post = "SF/PF", Salary = 37436858 };
            Player p1 = new Player() { PlayerID = 1, Name = "Kevin Durant", Birth = new DateTime(1988, 09, 29), Height = 208, Weight = 109, Number = 35, Post = "SF/PF", Salary = 37199000 };
            Player p2 = new Player() { PlayerID = 2, Name = "Traeee Young", Birth = new DateTime(1998, 09, 19), Height = 185, Weight = 82, Number = 11, Post = "PG", Salary = 6273000 };
            Player p3 = new Player() { PlayerID = 3, Name = "Kawhi Leonard", Birth = new DateTime(1991, 06, 29), Height = 201, Weight = 102, Number = 2, Post = "SF", Salary = 32742000 };
            Player p4 = new Player() { PlayerID = 4, Name = "James Harden", Birth = new DateTime(1989, 08, 26), Height = 196, Weight = 100, Number = 13, Post = "SG", Salary = 38199000 };
            Player p5 = new Player() { PlayerID = 5, Name = "Zion Williamson", Birth = new DateTime(2000, 07, 06), Height = 198, Weight = 129, Number = 1, Post = "PF", Salary = 9757440 };
            Player p6 = new Player() { PlayerID = 6, Name = "Khris Middleton", Birth = new DateTime(1984, 12, 20), Height = 206, Weight = 113, Number = 23, Post = "SF/PF", Salary = 30603448 };
            Player p7 = new Player() { PlayerID = 7, Name = "Ben Simmons", Birth = new DateTime(1991, 08, 12), Height = 201, Weight = 101, Number = 22, Post = "SF", Salary = 8113929 };
            Player p8 = new Player() { PlayerID = 8, Name = "Russell Westbrook", Birth = new DateTime(1988, 11, 12), Height = 191, Weight = 91, Number = 0, Post = "PG", Salary = 38506482 };
            Player p9 = new Player() { PlayerID = 9, Name = "Paul George", Birth = new DateTime(1990, 05, 2), Height = 203, Weight = 100, Number = 13, Post = "SF", Salary = 33005556 };
            Player p10 = new Player() { PlayerID = 10, Name = "Jayson Tatum", Birth = new DateTime(1998, 03, 3), Height = 203, Weight = 95, Number = 0, Post = "SF/PF", Salary = 7830000 };
            Player p11 = new Player() { PlayerID = 11, Name = "Jimmy Buttler", Birth = new DateTime(1989, 09, 14), Height = 201, Weight = 104, Number = 22, Post = "SG/SF", Salary = 32742000 };
            Player p12 = new Player() { PlayerID = 12, Name = "Damian Lillard", Birth = new DateTime(1990, 07, 15), Height = 188, Weight = 88, Number = 0, Post = "PG", Salary = 29802321 };
            Player p13 = new Player() { PlayerID = 13, Name = "Luka Doncic", Birth = new DateTime(1999, 02, 28), Height = 201, Weight = 104, Number = 77, Post = "G/SF", Salary = 7683360 };
            Player p14 = new Player() { PlayerID = 14, Name = "Nikola Jokic", Birth = new DateTime(1995, 02, 19), Height = 213, Weight = 129, Number = 15, Post = "C", Salary = 27504630 };

            Teams t0 = new Teams() { TeamID = 0, Name = "Boston Celtics", Coach = "Brad Stevens", Region = "Atlantic" };
            Teams t1 = new Teams() { TeamID = 1, Name = "Toronto Raptors", Coach = "Nick Nurse", Region = "Atlantic" };
            Teams t2 = new Teams() { TeamID = 2, Name = "Chicago Bulls", Coach = "Billy Donovan ", Region = "Central" };
            Teams t3 = new Teams() { TeamID = 3, Name = "Cleveland Cavaliers", Coach = "JB Bickerstaff", Region = "Central" };
            Teams t4 = new Teams() { TeamID = 4, Name = "Orlando Magic", Coach = "Steve Clifford", Region = "Southeast" };
            Teams t5 = new Teams() { TeamID = 5, Name = "Miami Heat", Coach = "Erik Spoelstra", Region = "Southeast" };
            Teams t6 = new Teams() { TeamID = 6, Name = "Portland Trail Blazers", Coach = "Terry Stotts", Region = "Northwest" };
            Teams t7 = new Teams() { TeamID = 7, Name = "Denver Nuggets", Coach = "Michael Malone", Region = "Northwest" };
            Teams t8 = new Teams() { TeamID = 8, Name = "LA Clippers", Coach = "Tyronn Lue", Region = "Pacific" };
            Teams t9 = new Teams() { TeamID = 9, Name = "Los Angeles Lakers", Coach = "Frank Vogel", Region = "Pacific" };
            Teams t10 = new Teams() { TeamID = 10, Name = "Houston Rockets", Coach = "Mike D'Antoni", Region = "Southwest" };
            Teams t11 = new Teams() { TeamID = 11, Name = "New Orleans Pelicans", Coach = "Stan Van Gundy", Region = "Southwest" };
        }
    }
}
