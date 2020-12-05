// <copyright file="PlayerTests.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>
[assembly: System.CLSCompliant(false)]

namespace NBA.Logic.Tests
{
    using System;
    using System.Collections.Generic;
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

            this.players.Add(new Player() { PlayerID = 1, Name = "Lebron James", Birth = new DateTime(1984, 12, 20), Height = 206, Weight = 113, Number = 23, Post = "SF/PF", Salary = 37436858 });
            this.players.Add(new Player() { PlayerID = 2, Name = "Kevin Durant", Birth = new DateTime(1988, 09, 29), Height = 208, Weight = 109, Number = 35, Post = "SF/PF", Salary = 37199000 });
            this.players.Add(new Player() { PlayerID = 3, Name = "Traeee Young", Birth = new DateTime(1998, 09, 19), Height = 185, Weight = 82, Number = 11, Post = "PG", Salary = 6273000 });
            this.players.Add(new Player() { PlayerID = 4, Name = "Kawhi Leonard", Birth = new DateTime(1991, 06, 29), Height = 201, Weight = 102, Number = 2, Post = "SF", Salary = 32742000 });
            this.players.Add(new Player() { PlayerID = 5, Name = "James Harden", Birth = new DateTime(1989, 08, 26), Height = 196, Weight = 100, Number = 13, Post = "SG", Salary = 38199000 });
            this.players.Add(new Player() { PlayerID = 6, Name = "Zion Williamson", Birth = new DateTime(2000, 07, 06), Height = 198, Weight = 129, Number = 1, Post = "PF", Salary = 9757440 });
            this.players.Add(new Player() { PlayerID = 7, Name = "Khris Middleton", Birth = new DateTime(1984, 12, 20), Height = 206, Weight = 113, Number = 23, Post = "SF/PF", Salary = 30603448 });
            this.players.Add(new Player() { PlayerID = 8, Name = "Ben Simmons", Birth = new DateTime(1991, 08, 12), Height = 201, Weight = 101, Number = 22, Post = "SF", Salary = 8113929 });
            this.players.Add(new Player() { PlayerID = 9, Name = "Russell Westbrook", Birth = new DateTime(1988, 11, 12), Height = 191, Weight = 91, Number = 0, Post = "PG", Salary = 38506482 });
            this.players.Add(new Player() { PlayerID = 10, Name = "Paul George", Birth = new DateTime(1990, 05, 2), Height = 203, Weight = 100, Number = 13, Post = "SF", Salary = 33005556 });
            this.players.Add(new Player() { PlayerID = 11, Name = "Jayson Tatum", Birth = new DateTime(1998, 03, 3), Height = 203, Weight = 95, Number = 0, Post = "SF/PF", Salary = 7830000 });
            this.players.Add(new Player() { PlayerID = 12, Name = "Jimmy Buttler", Birth = new DateTime(1989, 09, 14), Height = 201, Weight = 104, Number = 22, Post = "SG/SF", Salary = 32742000 });
            this.players.Add(new Player() { PlayerID = 13, Name = "Damian Lillard", Birth = new DateTime(1990, 07, 15), Height = 188, Weight = 88, Number = 0, Post = "PG", Salary = 29802321 });
            this.players.Add(new Player() { PlayerID = 14, Name = "Luka Doncic", Birth = new DateTime(1999, 02, 28), Height = 201, Weight = 104, Number = 77, Post = "G/SF", Salary = 7683360 });
            this.players.Add(new Player() { PlayerID = 15, Name = "Nikola Jokic", Birth = new DateTime(1995, 02, 19), Height = 213, Weight = 129, Number = 15, Post = "C", Salary = 27504630 });
            this.players.Add(new Player() { PlayerID = 16, Name = "Robert Covington", Birth = new DateTime(1990, 12, 4), Height = 201, Weight = 95, Number = 23, Post = "SF", Salary = 27504630 });
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
    }
}
