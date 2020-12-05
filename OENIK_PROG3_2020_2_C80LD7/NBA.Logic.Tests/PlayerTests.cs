// <copyright file="PlayerTests.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>
[assembly: System.CLSCompliant(false)]

namespace NBA.Logic.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Moq;
    using NBA.Data.Model;
    using NBA.Repository;
    using NUnit.Framework;

    /// <summary>
    /// Player entity tests.
    /// </summary>
    [TestFixture]
    public class PlayerTests
    {
        private List<Player> players;

        private List<Teams> teams;

        private Player testplayer;

        private Mock<IPlayerRepository> MockedPlayerRepo { get; set; }

        private Mock<ITeamsRepository> MockedTeamRepo { get; set; }

        private Mock<IPlayerStatsRepository> MockedPlayerStatRepo { get; set; }

        private PlayerLogic PlayerLogic { get; set; }

        /// <summary>
        /// Sets up the tests.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.MockedPlayerRepo = new Mock<IPlayerRepository>(MockBehavior.Loose);
            this.MockedTeamRepo = new Mock<ITeamsRepository>(MockBehavior.Loose);
            this.MockedPlayerStatRepo = new Mock<IPlayerStatsRepository>(MockBehavior.Loose);
            this.PlayerLogic = new PlayerLogic(this.MockedPlayerRepo.Object, this.MockedPlayerStatRepo.Object, this.MockedTeamRepo.Object);
            this.players = new List<Player>();
            this.teams = new List<Teams>();

            this.teams.Add(new Teams() { TeamID = 1, Name = "Boston Celtics", Coach = "Brad Stevens", Region = "Atlantic" });
            this.teams.Add(new Teams() { TeamID = 2, Name = "Toronto Raptors", Coach = "Nick Nurse", Region = "Atlantic" });
            this.teams.Add(new Teams() { TeamID = 3, Name = "Chicago Bulls", Coach = "Billy Donovan ", Region = "Central" });
            this.teams.Add(new Teams() { TeamID = 4, Name = "Cleveland Cavaliers", Coach = "JB Bickerstaff", Region = "Central" });
            this.teams.Add(new Teams() { TeamID = 5, Name = "Orlando Magic", Coach = "Steve Clifford", Region = "Southeast" });
            this.teams.Add(new Teams() { TeamID = 6, Name = "Miami Heat", Coach = "Erik Spoelstra", Region = "Southeast" });
            this.teams.Add(new Teams() { TeamID = 7, Name = "Portland Trail Blazers", Coach = "Terry Stotts", Region = "Northwest" });
            this.teams.Add(new Teams() { TeamID = 8, Name = "Denver Nuggets", Coach = "Michael Malone", Region = "Northwest" });
            this.teams.Add(new Teams() { TeamID = 9, Name = "LA Clippers", Coach = "Tyronn Lue", Region = "Pacific" });
            this.teams.Add(new Teams() { TeamID = 10, Name = "Los Angeles Lakers", Coach = "Frank Vogel", Region = "Pacific" });
            this.teams.Add(new Teams() { TeamID = 11, Name = "Houston Rockets", Coach = "Mike D'Antoni", Region = "Southwest" });
            this.teams.Add(new Teams() { TeamID = 12, Name = "New Orleans Pelicans", Coach = "Stan Van Gundy", Region = "Southwest" });
            this.teams.Add(new Teams() { TeamID = 13, Name = "Indiana Pacers", Coach = "Nate Bjorkgren", Region = "Central" });
            this.teams.Add(new Teams() { TeamID = 14, Name = "Philadelphia 76ers", Coach = "Doc Rivers", Region = "Atlantic" });
            this.teams.Add(new Teams() { TeamID = 15, Name = "Brooklyn Nets", Coach = "Steve Nash", Region = "Atlantic" });
            this.teams.Add(new Teams() { TeamID = 16, Name = "San Antonio Spurs", Coach = "Gregg Popovich", Region = "Southwest" });
            this.teams.Add(new Teams() { TeamID = 17, Name = "Detroit Pistons", Coach = "Dwane Casey", Region = "Central" });
            this.teams.Add(new Teams() { TeamID = 18, Name = "Dallas Mavericks", Coach = "Rick Carlisle", Region = "Southwest" });
            this.teams.Add(new Teams() { TeamID = 19, Name = "Charlotte Hornets", Coach = "James Borrego", Region = "Southeast" });
            this.teams.Add(new Teams() { TeamID = 20, Name = "Golden State Warriors", Coach = "Steve Kerr", Region = "Pacific" });
            this.teams.Add(new Teams() { TeamID = 21, Name = "Memphis Grizzlies", Coach = "Taylor Jenkins", Region = "Southwest" });
            this.teams.Add(new Teams() { TeamID = 22, Name = "Milwaukee Bucks", Coach = "Mike Budenholzer", Region = "Central" });
            this.teams.Add(new Teams() { TeamID = 23, Name = "Minnesota Timberwolves", Coach = "Ryan Saunders", Region = "Northwest" });
            this.teams.Add(new Teams() { TeamID = 24, Name = "New York Knicks", Coach = "Tom Thibodeau", Region = "Atlantic" });
            this.teams.Add(new Teams() { TeamID = 25, Name = "Oklahoma City Thunder", Coach = "Vacant", Region = "Northwest" });
            this.teams.Add(new Teams() { TeamID = 26, Name = "Phoenix Suns", Coach = "Monty Williams", Region = "Pacific" });
            this.teams.Add(new Teams() { TeamID = 27, Name = "Sacramento Kings", Coach = "Luke Walton", Region = "Pacific" });
            this.teams.Add(new Teams() { TeamID = 28, Name = "Utah Jazz", Coach = "Quin Synder", Region = "Northwest" });

            this.players.Add(new Player() { PlayerID = 1, Name = "Lebron James", Birth = new DateTime(1984, 12, 20), Height = 206, Weight = 113, Number = 23, Post = "SF/PF", Salary = 37436858, TeamID = this.teams[9].TeamID, Team = this.teams[9] });
            this.players.Add(new Player() { PlayerID = 2, Name = "Kevin Durant", Birth = new DateTime(1988, 09, 29), Height = 208, Weight = 109, Number = 35, Post = "SF/PF", Salary = 37199000, TeamID = this.teams[14].TeamID, Team = this.teams[14] });
            this.players.Add(new Player() { PlayerID = 3, Name = "Traeee Young", Birth = new DateTime(1998, 09, 19), Height = 185, Weight = 82, Number = 11, Post = "PG", Salary = 6273000, TeamID = this.teams[11].TeamID, Team = this.teams[11] });
            this.players.Add(new Player() { PlayerID = 4, Name = "Kawhi Leonard", Birth = new DateTime(1991, 06, 29), Height = 201, Weight = 102, Number = 2, Post = "SF", Salary = 32742000, TeamID = this.teams[8].TeamID, Team = this.teams[8] });
            this.players.Add(new Player() { PlayerID = 5, Name = "James Harden", Birth = new DateTime(1989, 08, 26), Height = 196, Weight = 100, Number = 13, Post = "SG", Salary = 38199000, TeamID = this.teams[10].TeamID, Team = this.teams[10] });
            this.players.Add(new Player() { PlayerID = 6, Name = "Zion Williamson", Birth = new DateTime(2000, 07, 06), Height = 198, Weight = 129, Number = 1, Post = "PF", Salary = 9757440, TeamID = this.teams[11].TeamID, Team = this.teams[11] });
            this.players.Add(new Player() { PlayerID = 7, Name = "Khris Middleton", Birth = new DateTime(1984, 12, 20), Height = 206, Weight = 113, Number = 23, Post = "SF/PF", Salary = 30603448, TeamID = this.teams[21].TeamID, Team = this.teams[21] });
            this.players.Add(new Player() { PlayerID = 8, Name = "Ben Simmons", Birth = new DateTime(1991, 08, 12), Height = 201, Weight = 101, Number = 22, Post = "SF", Salary = 8113929, TeamID = this.teams[13].TeamID, Team = this.teams[13] });
            this.players.Add(new Player() { PlayerID = 9, Name = "Russell Westbrook", Birth = new DateTime(1988, 11, 12), Height = 191, Weight = 91, Number = 0, Post = "PG", Salary = 38506482, TeamID = this.teams[10].TeamID, Team = this.teams[10] });
            this.players.Add(new Player() { PlayerID = 10, Name = "Paul George", Birth = new DateTime(1990, 05, 2), Height = 203, Weight = 100, Number = 13, Post = "SF", Salary = 33005556, TeamID = this.teams[12].TeamID, Team = this.teams[12] });
            this.players.Add(new Player() { PlayerID = 11, Name = "Jayson Tatum", Birth = new DateTime(1998, 03, 3), Height = 203, Weight = 95, Number = 0, Post = "SF/PF", Salary = 7830000, TeamID = this.teams[0].TeamID, Team = this.teams[0] });
            this.players.Add(new Player() { PlayerID = 12, Name = "Jimmy Buttler", Birth = new DateTime(1989, 09, 14), Height = 201, Weight = 104, Number = 22, Post = "SG/SF", Salary = 32742000, TeamID = this.teams[5].TeamID, Team = this.teams[5] });
            this.players.Add(new Player() { PlayerID = 13, Name = "Damian Lillard", Birth = new DateTime(1990, 07, 15), Height = 188, Weight = 88, Number = 0, Post = "PG", Salary = 29802321, TeamID = this.teams[6].TeamID, Team = this.teams[6] });
            this.players.Add(new Player() { PlayerID = 14, Name = "Luka Doncic", Birth = new DateTime(1999, 02, 28), Height = 201, Weight = 104, Number = 77, Post = "G/SF", Salary = 7683360, TeamID = this.teams[17].TeamID, Team = this.teams[17] });
            this.players.Add(new Player() { PlayerID = 15, Name = "Nikola Jokic", Birth = new DateTime(1995, 02, 19), Height = 213, Weight = 129, Number = 15, Post = "C", Salary = 27504630, TeamID = this.teams[7].TeamID, Team = this.teams[7] });
            this.players.Add(new Player() { PlayerID = 16, Name = "Robert Covington", Birth = new DateTime(1990, 12, 4), Height = 201, Weight = 95, Number = 23, Post = "SF", Salary = 27504630, TeamID = this.teams[10].TeamID, Team = this.teams[10] });

            this.testplayer = new Player { PlayerID = 33, Name = "Test Player", Birth = new DateTime(1990, 12, 4), Height = 201, Weight = 95, Number = 23, Post = "SF", Salary = 9000009 };
        }

        /// <summary>
        /// Tests get one player by id method.
        /// </summary>
        /// <param name="id">Player's id.</param>
        [TestCase(3)]
        [TestCase(10)]
        public void TestGetPlayerById(int id)
        {
            this.MockedPlayerRepo.Setup(player => player.GetOne(It.Is<int>(id => id >= 0 && id < this.players.Count))).Returns(this.players[id]);

            var result = this.PlayerLogic.GetOnePlayerById(id);

            this.MockedPlayerRepo.Verify(idx => idx.GetOne(id), Times.Exactly(1));
            this.MockedPlayerRepo.Verify(idx => idx.GetOne(100), Times.Never);
        }

        /// <summary>
        /// Testing that new player is added.
        /// </summary>
        [Test]
        public void TestInsertNewCustomer()
        {
            this.MockedPlayerRepo.Setup(repo => repo.Insert(It.IsAny<Player>()));

            this.PlayerLogic.AddNewPlayer(this.testplayer);

            this.MockedPlayerRepo.Verify(repo => repo.Insert(this.testplayer), Times.Once);
        }

        /// <summary>
        /// Testing that GetPlayerByTeam returns players from one team.
        /// </summary>
        [Test]
        public void TestGetPlayerByTeam()
        {
            this.MockedPlayerRepo.Setup(repo => repo.GetAll()).Returns(this.players.AsQueryable());

            List<Player> expectedPlayers = new List<Player>()
            {
                new Player() { PlayerID = 5, Name = "James Harden", Birth = new DateTime(1989, 08, 26), Height = 196, Weight = 100, Number = 13, Post = "SG", Salary = 38199000, TeamID = this.teams[10].TeamID, Team = this.teams[10] },
                new Player() { PlayerID = 9, Name = "Russell Westbrook", Birth = new DateTime(1988, 11, 12), Height = 191, Weight = 91, Number = 0, Post = "PG", Salary = 38506482, TeamID = this.teams[10].TeamID, Team = this.teams[10] },
                new Player() { PlayerID = 16, Name = "Robert Covington", Birth = new DateTime(1990, 12, 4), Height = 201, Weight = 95, Number = 23, Post = "SF", Salary = 27504630, TeamID = this.teams[10].TeamID, Team = this.teams[10] },
            };

            var result = this.PlayerLogic.GetPlayerByTeam(11);

            Assert.That(result.Count, Is.EqualTo(expectedPlayers.Count));
        }

        /// <summary>
        /// Testing non crud method that gets the player who played the most.
        /// </summary>
        [Test]
        public void TestGetPlayerQtyByTeams()
        {
            List<Average> expectedQty = new List<Average>()
            {
                new Average() { Name = "Boston Celtics", Avg = 1 },
                new Average() { Name = "Brooklyn Nets", Avg = 1 },
                new Average() { Name = "Dallas Mavericks", Avg = 1 },
                new Average() { Name = "Denver Nuggets", Avg = 1 },
                new Average() { Name = "Houston Rockets", Avg = 3 },
                new Average() { Name = "Indiana Pacers", Avg = 1 },
                new Average() { Name = "LA Clippers", Avg = 1 },
                new Average() { Name = "Los Angeles Lakers", Avg = 1 },
                new Average() { Name = "Miami Heat", Avg = 1 },
                new Average() { Name = "Milwaukee Bucks", Avg = 1 },
                new Average() { Name = "New Orleans Pelicans", Avg = 2 },
                new Average() { Name = "Philadelphia 76ers", Avg = 1 },
                new Average() { Name = "Portland Trail Blazers", Avg = 1 },
            };

            this.MockedPlayerRepo.Setup(repo => repo.GetAll()).Returns(this.players.AsQueryable());
            this.MockedTeamRepo.Setup(repo => repo.GetAll()).Returns(this.teams.AsQueryable());

            var result = this.PlayerLogic.GetPlayerQtyByTeams();

            Assert.That(result, Is.EqualTo(expectedQty));
        }
    }
}
