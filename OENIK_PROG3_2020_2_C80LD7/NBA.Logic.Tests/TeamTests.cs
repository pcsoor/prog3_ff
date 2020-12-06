// <copyright file="TeamTests.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.Logic.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Moq;
    using NBA.Data.Model;
    using NBA.Repository;
    using NUnit.Framework;

    /// <summary>
    /// Team entity specific tests.
    /// </summary>
    public class TeamTests
    {
        private List<Teams> teams;
        private List<Series> series;
        private List<TeamStats> teamStats;

        private Mock<ITeamsRepository> MockedTeamRepo { get; set; }

        private Mock<ITeamsStatsRepository> MockedTeamStatsRepo { get; set; }

        private Mock<ISeriesRepository> MockedSeriesRepo { get; set; }

        private TeamLogic TeamLogic { get; set; }

        /// <summary>
        /// Sets up mocks.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.MockedTeamRepo = new Mock<ITeamsRepository>(MockBehavior.Loose);
            this.MockedTeamStatsRepo = new Mock<ITeamsStatsRepository>(MockBehavior.Loose);
            this.MockedSeriesRepo = new Mock<ISeriesRepository>(MockBehavior.Loose);
            this.TeamLogic = new TeamLogic(this.MockedTeamRepo.Object, this.MockedTeamStatsRepo.Object, this.MockedSeriesRepo.Object);
            this.teams = new List<Teams>();
            this.series = new List<Series>();
            this.teamStats = new List<TeamStats>();

            this.teams.Add(new Teams() { TeamID = 1, Name = "Boston Celtics", Coach = "Brad Stevens", Region = "Atlantic", Series = this.series });
            this.teams.Add(new Teams() { TeamID = 2, Name = "Toronto Raptors", Coach = "Nick Nurse", Region = "Atlantic", Series = this.series });
            this.teams.Add(new Teams() { TeamID = 3, Name = "Chicago Bulls", Coach = "Billy Donovan ", Region = "Central", Series = this.series });
            this.teams.Add(new Teams() { TeamID = 4, Name = "Cleveland Cavaliers", Coach = "JB Bickerstaff", Region = "Central", Series = this.series });
            this.teams.Add(new Teams() { TeamID = 5, Name = "Orlando Magic", Coach = "Steve Clifford", Region = "Southeast", Series = this.series });
            this.teams.Add(new Teams() { TeamID = 6, Name = "Miami Heat", Coach = "Erik Spoelstra", Region = "Southeast", Series = this.series });
            this.teams.Add(new Teams() { TeamID = 7, Name = "Portland Trail Blazers", Coach = "Terry Stotts", Region = "Northwest", Series = this.series });
            this.teams.Add(new Teams() { TeamID = 8, Name = "Denver Nuggets", Coach = "Michael Malone", Region = "Northwest", Series = this.series });
            this.teams.Add(new Teams() { TeamID = 9, Name = "LA Clippers", Coach = "Tyronn Lue", Region = "Pacific", Series = this.series });
            this.teams.Add(new Teams() { TeamID = 10, Name = "Los Angeles Lakers", Coach = "Frank Vogel", Region = "Pacific", Series = this.series });
            this.teams.Add(new Teams() { TeamID = 11, Name = "Houston Rockets", Coach = "Mike D'Antoni", Region = "Southwest", Series = this.series });
            this.teams.Add(new Teams() { TeamID = 12, Name = "New Orleans Pelicans", Coach = "Stan Van Gundy", Region = "Southwest", Series = this.series });
            this.teams.Add(new Teams() { TeamID = 13, Name = "Indiana Pacers", Coach = "Nate Bjorkgren", Region = "Central", Series = this.series });
            this.teams.Add(new Teams() { TeamID = 14, Name = "Philadelphia 76ers", Coach = "Doc Rivers", Region = "Atlantic", Series = this.series });
            this.teams.Add(new Teams() { TeamID = 15, Name = "Brooklyn Nets", Coach = "Steve Nash", Region = "Atlantic", Series = this.series });
            this.teams.Add(new Teams() { TeamID = 16, Name = "San Antonio Spurs", Coach = "Gregg Popovich", Region = "Southwest", Series = this.series });
            this.teams.Add(new Teams() { TeamID = 17, Name = "Detroit Pistons", Coach = "Dwane Casey", Region = "Central", Series = this.series });
            this.teams.Add(new Teams() { TeamID = 18, Name = "Dallas Mavericks", Coach = "Rick Carlisle", Region = "Southwest", Series = this.series });
            this.teams.Add(new Teams() { TeamID = 19, Name = "Charlotte Hornets", Coach = "James Borrego", Region = "Southeast", Series = this.series });
            this.teams.Add(new Teams() { TeamID = 20, Name = "Golden State Warriors", Coach = "Steve Kerr", Region = "Pacific", Series = this.series });
            this.teams.Add(new Teams() { TeamID = 21, Name = "Memphis Grizzlies", Coach = "Taylor Jenkins", Region = "Southwest", Series = this.series });
            this.teams.Add(new Teams() { TeamID = 22, Name = "Milwaukee Bucks", Coach = "Mike Budenholzer", Region = "Central", Series = this.series });
            this.teams.Add(new Teams() { TeamID = 23, Name = "Minnesota Timberwolves", Coach = "Ryan Saunders", Region = "Northwest", Series = this.series });
            this.teams.Add(new Teams() { TeamID = 24, Name = "New York Knicks", Coach = "Tom Thibodeau", Region = "Atlantic", Series = this.series });
            this.teams.Add(new Teams() { TeamID = 25, Name = "Oklahoma City Thunder", Coach = "Vacant", Region = "Northwest", Series = this.series });
            this.teams.Add(new Teams() { TeamID = 26, Name = "Phoenix Suns", Coach = "Monty Williams", Region = "Pacific", Series = this.series });
            this.teams.Add(new Teams() { TeamID = 27, Name = "Sacramento Kings", Coach = "Luke Walton", Region = "Pacific", Series = this.series });
            this.teams.Add(new Teams() { TeamID = 28, Name = "Utah Jazz", Coach = "Quin Synder", Region = "Northwest", Series = this.series });

            this.series.Add(new Series() { Year = 2000, Result = "4-2", WinnerID = this.teams[9].TeamID, LoserID = this.teams[12].TeamID });
            this.series.Add(new Series() { Year = 2001, Result = "4-1", WinnerID = this.teams[9].TeamID, LoserID = this.teams[13].TeamID });
            this.series.Add(new Series() { Year = 2002, Result = "4-0", WinnerID = this.teams[9].TeamID, LoserID = this.teams[14].TeamID });
            this.series.Add(new Series() { Year = 2003, Result = "4-2", WinnerID = this.teams[15].TeamID, LoserID = this.teams[14].TeamID });
            this.series.Add(new Series() { Year = 2004, Result = "4-1", WinnerID = this.teams[16].TeamID, LoserID = this.teams[9].TeamID });
            this.series.Add(new Series() { Year = 2005, Result = "4-3", WinnerID = this.teams[15].TeamID, LoserID = this.teams[16].TeamID });
            this.series.Add(new Series() { Year = 2006, Result = "4-2", WinnerID = this.teams[5].TeamID, LoserID = this.teams[17].TeamID });
            this.series.Add(new Series() { Year = 2007, Result = "4-0", WinnerID = this.teams[15].TeamID, LoserID = this.teams[3].TeamID });
            this.series.Add(new Series() { Year = 2008, Result = "4-2", WinnerID = this.teams[0].TeamID, LoserID = this.teams[9].TeamID });
            this.series.Add(new Series() { Year = 2009, Result = "4-1", WinnerID = this.teams[9].TeamID, LoserID = this.teams[4].TeamID });
            this.series.Add(new Series() { Year = 2010, Result = "4-3", WinnerID = this.teams[9].TeamID, LoserID = this.teams[0].TeamID });
            this.series.Add(new Series() { Year = 2011, Result = "4-2", WinnerID = this.teams[9].TeamID, LoserID = this.teams[12].TeamID });

            this.teamStats.Add(new TeamStats() { TeamStatID = 1, AST = 23.0, BLK = 5.1, FGM = 40.6, GP = 72, PPG = 113.7, REB = 43.3, STL = 7.8, TeamID = this.teams[0].TeamID, Teams = this.teams[0] });
            this.teamStats.Add(new TeamStats() { TeamStatID = 2, AST = 24.5, BLK = 4.5, FGM = 40.4, GP = 72, PPG = 111.8, REB = 47.9, STL = 6.4, TeamID = this.teams[14].TeamID, Teams = this.teams[14] });
            this.teamStats.Add(new TeamStats() { TeamStatID = 3, AST = 23.8, BLK = 4.1, FGM = 37.3, GP = 65, PPG = 102.9, REB = 42.8, STL = 6.6, TeamID = this.teams[18].TeamID, Teams = this.teams[18] });
            this.teamStats.Add(new TeamStats() { TeamStatID = 4, AST = 23.2, BLK = 4.1, FGM = 39.6, GP = 65, PPG = 106.8, REB = 41.9, STL = 10.0, TeamID = this.teams[2].TeamID, Teams = this.teams[2] });
            this.teamStats.Add(new TeamStats() { TeamStatID = 5, AST = 23.1, BLK = 3.2, FGM = 40.3, GP = 65, PPG = 106.9, REB = 44.2, STL = 6.9, TeamID = this.teams[3].TeamID, Teams = this.teams[3] });
            this.teamStats.Add(new TeamStats() { TeamStatID = 6, AST = 24.7, BLK = 4.8, FGM = 41.7, GP = 75, PPG = 117.0, REB = 46.9, STL = 6.1, TeamID = this.teams[17].TeamID, Teams = this.teams[17] });
            this.teamStats.Add(new TeamStats() { TeamStatID = 7, AST = 26.7, BLK = 4.6, FGM = 42.0, GP = 73, PPG = 111.3, REB = 44.1, STL = 8.0, TeamID = this.teams[7].TeamID, Teams = this.teams[7] });
            this.teamStats.Add(new TeamStats() { TeamStatID = 8, AST = 24.1, BLK = 4.5, FGM = 39.3, GP = 66, PPG = 107.2, REB = 41.7, STL = 7.4, TeamID = this.teams[16].TeamID, Teams = this.teams[16] });
            this.teamStats.Add(new TeamStats() { TeamStatID = 9, AST = 25.6, BLK = 4.6, FGM = 38.6, GP = 65, PPG = 106.3, REB = 42.8, STL = 8.2, TeamID = this.teams[19].TeamID, Teams = this.teams[19] });
            this.teamStats.Add(new TeamStats() { TeamStatID = 10, AST = 21.6, BLK = 5.2, FGM = 40.8, GP = 72, PPG = 117.8, REB = 44.3, STL = 8.7, TeamID = this.teams[10].TeamID, Teams = this.teams[10] });
        }

        /// <summary>
        /// Tests GetWinQtyByTeams method. NON-CRUD Test.
        /// </summary>
        [Test]
        public void TestGetWinQtyByTeams()
        {
            List<Average> expectedRes = new List<Average>()
            {
                new Average() { Name = "Boston Celtics", Avg = 1 },
                new Average() { Name = "Detroit Pistons", Avg = 1 },
                new Average() { Name = "Los Angeles Lakers", Avg = 6 },
                new Average() { Name = "Miami Heat", Avg = 1 },
                new Average() { Name = "San Antonio Spurs", Avg = 3 },
            };

            this.MockedSeriesRepo.Setup(r => r.GetAll()).Returns(this.series.AsQueryable());
            this.MockedTeamRepo.Setup(r => r.GetAll()).Returns(this.teams.AsQueryable());

            var res = this.TeamLogic.GetWinQtyByTeams();

            Assert.That(res, Is.Not.Empty);
            Assert.That(res.First(), Is.EqualTo(expectedRes.First()));
            Assert.That(res.Last(), Is.EqualTo(expectedRes.Last()));
            Assert.That(res, Is.EquivalentTo(expectedRes));
        }

        /// <summary>
        /// Test GetOneTeamById method. CRUD Test.
        /// </summary>
        /// <param name="id">team's id.</param>
        [TestCase(3)]
        [TestCase(10)]
        public void GetOneTeamById(int id)
        {
            this.MockedTeamRepo.Setup(r => r.GetOne(It.Is<int>(id => id >= 0 && id < this.teams.Count))).Returns(this.teams[id]);

            var result = this.TeamLogic.GetOneTeamById(id);

            this.MockedTeamRepo.Verify(idx => idx.GetOne(id), Times.Exactly(1));
            this.MockedTeamRepo.Verify(idx => idx.GetOne(100), Times.Never);
        }

        /// <summary>
        /// Tests GetTeamAverageStealPerGame method. NON-CRUD Test.
        /// </summary>
        [Test]
        public void TestGetTeamAverageStealPerGame()
        {
            List<Average> expected = new List<Average>()
            {
                new Average() { Name = "Boston Celtics", Avg = 7.8 },
                new Average() { Name = "Brooklyn Nets", Avg = 6.4 },
                new Average() { Name = "Charlotte Hornets", Avg = 6.6 },
                new Average() { Name = "Chicago Bulls", Avg = 10 },
                new Average() { Name = "Cleveland Cavaliers", Avg = 6.9 },
                new Average() { Name = "Dallas Mavericks", Avg = 6.1 },
                new Average() { Name = "Denver Nuggets", Avg = 8 },
                new Average() { Name = "Detroit Pistons", Avg = 7.4 },
                new Average() { Name = "Golden State Warriors", Avg = 8.2 },
                new Average() { Name = "Houston Rockets", Avg = 8.7 },
            };

            this.MockedTeamStatsRepo.Setup(r => r.GetAll()).Returns(this.teamStats.AsQueryable());
            this.MockedTeamRepo.Setup(r => r.GetAll()).Returns(this.teams.AsQueryable());

            var res = this.TeamLogic.GetTeamAverageStealPerGame();

            Assert.That(res, Is.Not.Empty);
            Assert.That(res.First(), Is.EqualTo(expected.First()));
            Assert.That(res.Last(), Is.EqualTo(expected.Last()));
            Assert.That(res, Is.EquivalentTo(expected));
            this.MockedTeamStatsRepo.Verify(repo => repo.GetAll(), Times.Once);
            this.MockedTeamRepo.Verify(repo => repo.GetAll(), Times.Once);
            this.MockedSeriesRepo.Verify(repo => repo.GetAll(), Times.Never);
        }
    }
}
