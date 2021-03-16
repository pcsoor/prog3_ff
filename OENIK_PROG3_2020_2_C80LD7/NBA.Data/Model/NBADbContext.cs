// <copyright file="NBADbContext.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>
[assembly: System.CLSCompliant(false)]

namespace NBA.Data.Model
{
    using System;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Thic class made for creating database.
    /// </summary>
    public class NBADbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NBADbContext"/> class.
        /// </summary>
        public NBADbContext()
        {
            this.Database.EnsureCreated();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NBADbContext"/> class.
        /// </summary>
        /// <param name="options">instance of dbcontext.</param>
        public NBADbContext(DbContextOptions<NBADbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets each player.
        /// </summary>
        public virtual DbSet<Player> Player { get; set; }

        /// <summary>
        /// Gets or sets nba teams.
        /// </summary>
        public virtual DbSet<Teams> Teams { get; set; }

        /// <summary>
        /// Gets or sets an nba series.
        /// </summary>
        public virtual DbSet<Series> Series { get; set; }

        /// <summary>
        /// Gets or sets team statistics.
        /// </summary>
        public virtual DbSet<TeamStats> TeamStats { get; set; }

        /// <summary>
        /// Gets or sets player statistics.
        /// </summary>
        public virtual DbSet<PlayerStats> PlayerStats { get; set; }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder == null)
            {
                throw new ArgumentNullException(nameof(optionsBuilder));
            }

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.
                    UseLazyLoadingProxies().
                    UseSqlServer(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\NBADatabase.mdf; Integrated Security = True");
            }
        }

        /// <summary>
        /// OnModelCreating.
        /// </summary>
        /// <param name="modelBuilder">modelBuilder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Player p1 = new Player() { PlayerID = 1, Name = "Lebron James", Birth = new DateTime(1984, 12, 20), Height = 206, Weight = 113, Number = 23, Post = Data.Model.Player.PositionType.PowerForward, Salary = 37436858 };
            Player p2 = new Player() { PlayerID = 2, Name = "Kevin Durant", Birth = new DateTime(1988, 09, 29), Height = 208, Weight = 109, Number = 35, Post = Data.Model.Player.PositionType.PowerForward, Salary = 37199000 };
            Player p3 = new Player() { PlayerID = 3, Name = "Traeee Young", Birth = new DateTime(1998, 09, 19), Height = 185, Weight = 82, Number = 11, Post = Data.Model.Player.PositionType.PowerForward, Salary = 6273000 };
            Player p4 = new Player() { PlayerID = 4, Name = "Kawhi Leonard", Birth = new DateTime(1991, 06, 29), Height = 201, Weight = 102, Number = 2, Post = Data.Model.Player.PositionType.PowerForward, Salary = 32742000 };
            Player p5 = new Player() { PlayerID = 5, Name = "James Harden", Birth = new DateTime(1989, 08, 26), Height = 196, Weight = 100, Number = 13, Post = Data.Model.Player.PositionType.PowerForward, Salary = 38199000 };
            Player p6 = new Player() { PlayerID = 6, Name = "Zion Williamson", Birth = new DateTime(2000, 07, 06), Height = 198, Weight = 129, Number = 1, Post = Data.Model.Player.PositionType.PowerForward, Salary = 9757440 };
            Player p7 = new Player() { PlayerID = 7, Name = "Khris Middleton", Birth = new DateTime(1984, 12, 20), Height = 206, Weight = 113, Number = 23, Post = Data.Model.Player.PositionType.PowerForward, Salary = 30603448 };
            Player p8 = new Player() { PlayerID = 8, Name = "Ben Simmons", Birth = new DateTime(1991, 08, 12), Height = 201, Weight = 101, Number = 22, Post = Data.Model.Player.PositionType.PowerForward, Salary = 8113929 };
            Player p9 = new Player() { PlayerID = 9, Name = "Russell Westbrook", Birth = new DateTime(1988, 11, 12), Height = 191, Weight = 91, Number = 0, Post = Data.Model.Player.PositionType.PowerForward, Salary = 38506482 };
            Player p10 = new Player() { PlayerID = 10, Name = "Paul George", Birth = new DateTime(1990, 05, 2), Height = 203, Weight = 100, Number = 13, Post = Data.Model.Player.PositionType.PowerForward, Salary = 33005556 };
            Player p11 = new Player() { PlayerID = 11, Name = "Jayson Tatum", Birth = new DateTime(1998, 03, 3), Height = 203, Weight = 95, Number = 0, Post = Data.Model.Player.PositionType.PowerForward, Salary = 7830000 };
            Player p12 = new Player() { PlayerID = 12, Name = "Jimmy Buttler", Birth = new DateTime(1989, 09, 14), Height = 201, Weight = 104, Number = 22, Post = Data.Model.Player.PositionType.PowerForward, Salary = 32742000 };
            Player p13 = new Player() { PlayerID = 13, Name = "Damian Lillard", Birth = new DateTime(1990, 07, 15), Height = 188, Weight = 88, Number = 0, Post = Data.Model.Player.PositionType.PowerForward, Salary = 29802321 };
            Player p14 = new Player() { PlayerID = 14, Name = "Luka Doncic", Birth = new DateTime(1999, 02, 28), Height = 201, Weight = 104, Number = 77, Post = Data.Model.Player.PositionType.PowerForward, Salary = 7683360 };
            Player p15 = new Player() { PlayerID = 15, Name = "Nikola Jokic", Birth = new DateTime(1995, 02, 19), Height = 213, Weight = 129, Number = 15, Post = Data.Model.Player.PositionType.PowerForward, Salary = 27504630 };
            Player p16 = new Player() { PlayerID = 16, Name = "Robert Covington", Birth = new DateTime(1990, 12, 4), Height = 201, Weight = 95, Number = 23, Post = Data.Model.Player.PositionType.PowerForward, Salary = 27504630 };

            Teams t1 = new Teams() { TeamID = 1, Name = "Boston Celtics", Coach = "Brad Stevens", Region = "Atlantic" };
            Teams t2 = new Teams() { TeamID = 2, Name = "Toronto Raptors", Coach = "Nick Nurse", Region = "Atlantic" };
            Teams t3 = new Teams() { TeamID = 3, Name = "Chicago Bulls", Coach = "Billy Donovan ", Region = "Central" };
            Teams t4 = new Teams() { TeamID = 4, Name = "Cleveland Cavaliers", Coach = "JB Bickerstaff", Region = "Central" };
            Teams t5 = new Teams() { TeamID = 5, Name = "Orlando Magic", Coach = "Steve Clifford", Region = "Southeast" };
            Teams t6 = new Teams() { TeamID = 6, Name = "Miami Heat", Coach = "Erik Spoelstra", Region = "Southeast" };
            Teams t7 = new Teams() { TeamID = 7, Name = "Portland Trail Blazers", Coach = "Terry Stotts", Region = "Northwest" };
            Teams t8 = new Teams() { TeamID = 8, Name = "Denver Nuggets", Coach = "Michael Malone", Region = "Northwest" };
            Teams t9 = new Teams() { TeamID = 9, Name = "LA Clippers", Coach = "Tyronn Lue", Region = "Pacific" };
            Teams t10 = new Teams() { TeamID = 10, Name = "Los Angeles Lakers", Coach = "Frank Vogel", Region = "Pacific" };
            Teams t11 = new Teams() { TeamID = 11, Name = "Houston Rockets", Coach = "Mike D'Antoni", Region = "Southwest" };
            Teams t12 = new Teams() { TeamID = 12, Name = "New Orleans Pelicans", Coach = "Stan Van Gundy", Region = "Southwest" };
            Teams t13 = new Teams() { TeamID = 13, Name = "Indiana Pacers", Coach = "Nate Bjorkgren", Region = "Central" };
            Teams t14 = new Teams() { TeamID = 14, Name = "Philadelphia 76ers", Coach = "Doc Rivers", Region = "Atlantic" };
            Teams t15 = new Teams() { TeamID = 15, Name = "Brooklyn Nets", Coach = "Steve Nash", Region = "Atlantic" };
            Teams t16 = new Teams() { TeamID = 16, Name = "San Antonio Spurs", Coach = "Gregg Popovich", Region = "Southwest" };
            Teams t17 = new Teams() { TeamID = 17, Name = "Detroit Pistons", Coach = "Dwane Casey", Region = "Central" };
            Teams t18 = new Teams() { TeamID = 18, Name = "Dallas Mavericks", Coach = "Rick Carlisle", Region = "Southwest" };
            Teams t19 = new Teams() { TeamID = 19, Name = "Charlotte Hornets", Coach = "James Borrego", Region = "Southeast" };
            Teams t20 = new Teams() { TeamID = 20, Name = "Golden State Warriors", Coach = "Steve Kerr", Region = "Pacific" };
            Teams t21 = new Teams() { TeamID = 21, Name = "Memphis Grizzlies", Coach = "Taylor Jenkins", Region = "Southwest" };
            Teams t22 = new Teams() { TeamID = 22, Name = "Milwaukee Bucks", Coach = "Mike Budenholzer", Region = "Central" };
            Teams t23 = new Teams() { TeamID = 23, Name = "Minnesota Timberwolves", Coach = "Ryan Saunders", Region = "Northwest" };
            Teams t24 = new Teams() { TeamID = 24, Name = "New York Knicks", Coach = "Tom Thibodeau", Region = "Atlantic" };
            Teams t25 = new Teams() { TeamID = 25, Name = "Oklahoma City Thunder", Coach = "Vacant", Region = "Northwest" };
            Teams t26 = new Teams() { TeamID = 26, Name = "Phoenix Suns", Coach = "Monty Williams", Region = "Pacific" };
            Teams t27 = new Teams() { TeamID = 27, Name = "Sacramento Kings", Coach = "Luke Walton", Region = "Pacific" };
            Teams t28 = new Teams() { TeamID = 28, Name = "Utah Jazz", Coach = "Quin Synder", Region = "Northwest" };

            Series s1 = new Series() { Year = 2000, Result = "4-2" };
            Series s2 = new Series() { Year = 2001, Result = "4-1" };
            Series s3 = new Series() { Year = 2002, Result = "4-0" };
            Series s4 = new Series() { Year = 2003, Result = "4-2" };
            Series s5 = new Series() { Year = 2004, Result = "4-1" };
            Series s6 = new Series() { Year = 2005, Result = "4-3" };
            Series s7 = new Series() { Year = 2006, Result = "4-2" };
            Series s8 = new Series() { Year = 2007, Result = "4-0" };
            Series s9 = new Series() { Year = 2008, Result = "4-2" };
            Series s10 = new Series() { Year = 2009, Result = "4-1" };
            Series s11 = new Series() { Year = 2010, Result = "4-3" };
            Series s12 = new Series() { Year = 2011, Result = "4-2" };

            TeamStats ts1 = new TeamStats() { TeamStatID = 1, AST = 23.0, BLK = 5.1, FGM = 40.6, GP = 72, PPG = 113.7, REB = 43.3, STL = 7.8 };
            TeamStats ts2 = new TeamStats() { TeamStatID = 2, AST = 24.5, BLK = 4.5, FGM = 40.4, GP = 72, PPG = 111.8, REB = 47.9, STL = 6.4 };
            TeamStats ts3 = new TeamStats() { TeamStatID = 3, AST = 23.8, BLK = 4.1, FGM = 37.3, GP = 65, PPG = 102.9, REB = 42.8, STL = 6.6 };
            TeamStats ts4 = new TeamStats() { TeamStatID = 4, AST = 23.2, BLK = 4.1, FGM = 39.6, GP = 65, PPG = 106.8, REB = 41.9, STL = 10.0 };
            TeamStats ts5 = new TeamStats() { TeamStatID = 5, AST = 23.1, BLK = 3.2, FGM = 40.3, GP = 65, PPG = 106.9, REB = 44.2, STL = 6.9 };
            TeamStats ts6 = new TeamStats() { TeamStatID = 6, AST = 24.7, BLK = 4.8, FGM = 41.7, GP = 75, PPG = 117.0, REB = 46.9, STL = 6.1 };
            TeamStats ts7 = new TeamStats() { TeamStatID = 7, AST = 26.7, BLK = 4.6, FGM = 42.0, GP = 73, PPG = 111.3, REB = 44.1, STL = 8.0 };
            TeamStats ts8 = new TeamStats() { TeamStatID = 8, AST = 24.1, BLK = 4.5, FGM = 39.3, GP = 66, PPG = 107.2, REB = 41.7, STL = 7.4 };
            TeamStats ts9 = new TeamStats() { TeamStatID = 9, AST = 25.6, BLK = 4.6, FGM = 38.6, GP = 65, PPG = 106.3, REB = 42.8, STL = 8.2 };
            TeamStats ts10 = new TeamStats() { TeamStatID = 10, AST = 21.6, BLK = 5.2, FGM = 40.8, GP = 72, PPG = 117.8, REB = 44.3, STL = 8.7 };

            PlayerStats ps1 = new PlayerStats() { PlayerStatID = 1, AST = 10.2, BLK = 0.5, FGM = 9.6, GP = 67, PPG = 25.3, REB = 7.8, STL = 1.2 };
            PlayerStats ps2 = new PlayerStats() { PlayerStatID = 2, AST = 4.9, BLK = 0.6, FGM = 9.3, GP = 57, PPG = 27.1, REB = 7.1, STL = 1.8 };
            PlayerStats ps3 = new PlayerStats() { PlayerStatID = 3, AST = 9.3, BLK = 0.1, FGM = 9.1, GP = 60, PPG = 29.6, REB = 4.3, STL = 1.1 };
            PlayerStats ps4 = new PlayerStats() { PlayerStatID = 4, AST = 8.8, BLK = 0.2, FGM = 9.5, GP = 61, PPG = 28.8, REB = 9.4, STL = 1.0 };
            PlayerStats ps5 = new PlayerStats() { PlayerStatID = 5, AST = 7.5, BLK = 0.9, FGM = 9.9, GP = 68, PPG = 34.3, REB = 6.6, STL = 1.8 };
            PlayerStats ps6 = new PlayerStats() { PlayerStatID = 6, AST = 6.5, BLK = 1.1, FGM = 9.9, GP = 68, PPG = 26.3, REB = 6.6, STL = 1.8 };

            s1.WinnerID = t10.TeamID;
            s2.WinnerID = t10.TeamID;
            s3.WinnerID = t10.TeamID;
            s4.WinnerID = t16.TeamID;
            s5.WinnerID = t17.TeamID;
            s6.WinnerID = t16.TeamID;
            s7.WinnerID = t6.TeamID;
            s8.WinnerID = t16.TeamID;
            s9.WinnerID = t1.TeamID;
            s10.WinnerID = t10.TeamID;
            s11.WinnerID = t10.TeamID;
            s12.WinnerID = t10.TeamID;

            s1.LoserID = t13.TeamID;
            s2.LoserID = t14.TeamID;
            s3.LoserID = t15.TeamID;
            s4.LoserID = t15.TeamID;
            s5.LoserID = t10.TeamID;
            s6.LoserID = t17.TeamID;
            s7.LoserID = t18.TeamID;
            s8.LoserID = t4.TeamID;
            s9.LoserID = t10.TeamID;
            s10.LoserID = t5.TeamID;
            s11.LoserID = t1.TeamID;
            s12.LoserID = t13.TeamID;

            ts1.TeamID = t1.TeamID;
            ts2.TeamID = t15.TeamID;
            ts3.TeamID = t19.TeamID;
            ts4.TeamID = t3.TeamID;
            ts5.TeamID = t4.TeamID;
            ts6.TeamID = t18.TeamID;
            ts7.TeamID = t8.TeamID;
            ts8.TeamID = t17.TeamID;
            ts9.TeamID = t20.TeamID;
            ts10.TeamID = t11.TeamID;

            ps1.PlayerID = p1.PlayerID;
            ps2.PlayerID = p4.PlayerID;
            ps3.PlayerID = p3.PlayerID;
            ps4.PlayerID = p14.PlayerID;
            ps5.PlayerID = p5.PlayerID;
            ps6.PlayerID = p5.PlayerID;

            p1.TeamID = t10.TeamID;
            p2.TeamID = t15.TeamID;
            p3.TeamID = t12.TeamID;
            p4.TeamID = t9.TeamID;
            p5.TeamID = t11.TeamID;
            p6.TeamID = t12.TeamID;
            p7.TeamID = t22.TeamID;
            p8.TeamID = t14.TeamID;
            p9.TeamID = t11.TeamID;
            p10.TeamID = t13.TeamID;
            p11.TeamID = t1.TeamID;
            p12.TeamID = t6.TeamID;
            p13.TeamID = t7.TeamID;
            p14.TeamID = t18.TeamID;
            p15.TeamID = t8.TeamID;
            p16.TeamID = t11.TeamID;

            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasOne(p => p.PlayerStats)
                .WithOne(ps => ps.Player)
                .HasForeignKey<PlayerStats>(p => p.PlayerID);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasOne(player => player.Team)
                .WithMany(teams => teams.Players)
                .HasForeignKey(player => player.TeamID)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Teams>(entity =>
            {
                entity.HasOne(t => t.TeamStats)
                .WithOne(ts => ts.Teams)
                .HasForeignKey<TeamStats>(t => t.TeamID);
            });

            modelBuilder.Entity<Teams>(entity =>
            {
                entity.HasMany(t => t.Series)
                .WithOne(s => s.Teams)
                .HasForeignKey(t => t.WinnerID)
                .HasForeignKey(t => t.LoserID)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Player>().HasData(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16);
            modelBuilder.Entity<Teams>().HasData(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28);
            modelBuilder.Entity<Series>().HasData(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12);
            modelBuilder.Entity<TeamStats>().HasData(ts1, ts2, ts3, ts4, ts5, ts6, ts7, ts8, ts9, ts10);
            modelBuilder.Entity<PlayerStats>().HasData(ps1, ps2, ps3, ps4, ps5, ps6);
        }
    }
}
