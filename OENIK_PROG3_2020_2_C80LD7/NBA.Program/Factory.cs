// <copyright file="Factory.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.Program
{
    using System;
    using System.Linq;
    using ConsoleTools;
    using NBA.Data.Model;
    using NBA.Logic;
    using NBA.Repository;

    /// <summary>
    /// Class for implementation.
    /// </summary>
    public class Factory
    {
        private static NBADbContext ctx = new NBADbContext();
        private static PlayerRepository playerRepo = new PlayerRepository(ctx);
        private static TeamsRepository teamRepo = new TeamsRepository(ctx);
        private static PlayerStatsRepository playerStatsRepo = new PlayerStatsRepository(ctx);
        private static TeamsStatsRepository teamStatsRepo = new TeamsStatsRepository(ctx);
        private static SeriesRepository seriesRepo = new SeriesRepository(ctx);

        /// <summary>
        /// Initializes a new instance of the <see cref="Factory"/> class.
        /// </summary>
        public Factory()
        {
            this.PlayerLogic = new PlayerLogic(playerRepo, playerStatsRepo, teamRepo);
            this.TeamLogic = new TeamLogic(teamRepo, teamStatsRepo, seriesRepo);
            this.Menu = new ConsoleMenu();
        }

        /// <summary>
        /// Gets or sets the PlayerLogic object.
        /// </summary>
        public PlayerLogic PlayerLogic { get; set; }

        /// <summary>
        /// Gets or sets the PlayerLogic object.
        /// </summary>
        public TeamLogic TeamLogic { get; set; }

        /// <summary>
        /// Gets or sets the PlayerLogic object.
        /// </summary>
        public ConsoleMenu Menu { get; set; }

        /// <summary>
        /// This method prints out the menu, and called by program.cs.
        /// </summary>
        public void Kiir()
        {
            var sm = new SimpleMenu();
            var menu = new ConsoleMenu();

            menu.Add("LIST METHODS >", m => new ConsoleMenu()
            .Add("List all player [CRUD]", () => SimpleMenu.ListAllPlayer(this.PlayerLogic))
            .Add("List all team [CRUD]", () => SimpleMenu.ListAllTeams(this.TeamLogic))
            .Add("List all team statistics [CRUD]", () => SimpleMenu.ListAllTeamStat(this.TeamLogic))
            .Add("List all series result [CRUD]", () => SimpleMenu.ListAllSeriesResult(this.TeamLogic))
            .Add("List player quantity in each team [NON-CRUD]", () => SimpleMenu.GetPlayerQtyByTeams(this.PlayerLogic))
            .Add("List win series from the past [NON-CRUD]", () => SimpleMenu.GetWinQtyByTeams(this.TeamLogic))
            .Add("List player average points per game [NON-CRUD]", () => SimpleMenu.GetPlayerAveragePointPerGame(this.PlayerLogic))
            .Add("List players by team id [NON-CRUD]", () => SimpleMenu.GetPlayerByTeam(this.PlayerLogic))
            .Add("List average steals by teams per games [NON-CRUD]", () => SimpleMenu.GetTeamAverageStealPerGame(this.TeamLogic))
            .Add("<= Back", ConsoleMenu.Close).Show())
            .Add("GET ONE METHODS >", m => new ConsoleMenu()
            .Add("List one player [CRUD]", () => SimpleMenu.GetOnePlayer(this.PlayerLogic))
            .Add("Player who played the most [NON-CRUD]", () => SimpleMenu.GetPlayerWithTheMostGamesPlayed(this.PlayerLogic))
            .Add("<= Back", ConsoleMenu.Close).Show())
            .Add("INSERT METHODS >", m => new ConsoleMenu()
            .Add("Insert new player [CRUD]", m => SimpleMenu.AddPlayer(this.PlayerLogic))
            .Add("<= Back", ConsoleMenu.Close).Show())
            .Add("UPDATE METHODS >", m => new ConsoleMenu()
            .Add("Update player's salary [CRUD]", () => SimpleMenu.UpdatePlayerSalary(this.PlayerLogic))
            .Add("Update team's name [CRUD]", () => SimpleMenu.ChangeTeamName(this.TeamLogic))
            .Add("Update loser team's id of the series [CRUD]", () => SimpleMenu.ChangeLoserId(this.TeamLogic))
            .Add("Update winner team's id of the series [CRUD]", () => SimpleMenu.ChangeWinnerId(this.TeamLogic))
            .Add("Update final result of the series [CRUD]", () => SimpleMenu.ChangeFinalResult(this.TeamLogic))
            .Add("<= Back", ConsoleMenu.Close).Show())
            .Add("REMOVE METHODS >", m => new ConsoleMenu()
            .Add("Remove player [CRUD]", () => SimpleMenu.DeletePlayer(this.PlayerLogic))
            .Add("Remove team [CRUD]", () => SimpleMenu.DeleteTeam(this.TeamLogic))
            .Add("<= Back", ConsoleMenu.Close).Show())
            .Add("ASYNC TASKS >", m => new ConsoleMenu()
            .Add("Run average steals by teams per games with async task", () => SimpleMenu.GetTeamAverageStealPerGameAsync(this.TeamLogic))
            .Add("Run average points by players per games with async task", () => SimpleMenu.GetPlayerAveragePointPerGameAsync(this.PlayerLogic))
            .Add("Run the player who played the most in previous season method with async task", () => SimpleMenu.GetPlayerWithTheMostGamesPlayedAsync(this.PlayerLogic))
            .Add("Back", ConsoleMenu.Close).Show())
            .Add("EXIT", ConsoleMenu.Close);
            menu.Show();
        }
    }
}
