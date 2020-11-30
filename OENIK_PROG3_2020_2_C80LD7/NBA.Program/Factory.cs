// <copyright file="Factory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
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
        // repos
        private static NBADbContext ctx = new NBADbContext();
        private static PlayerRepository playerRepo = new PlayerRepository(ctx);
        private static TeamsRepository teamRepo = new TeamsRepository(ctx);

        private static PlayerStatsRepository playerStatsRepo = new PlayerStatsRepository(ctx);
        private static TeamsStatsRepository teamStatsRepo = new TeamsStatsRepository(ctx);

        // private static SeriesRepository seriesRepo = new SeriesRepository(ctx);

        /// <summary>
        /// Initializes a new instance of the <see cref="Factory"/> class.
        /// </summary>
        public Factory()
        {
            this.PlayerLogic = new PlayerLogic(playerRepo, playerStatsRepo, teamRepo);
            this.TeamLogic = new TeamLogic(teamRepo, teamStatsRepo);
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
            .Add("List all player", () => SimpleMenu.ListAllPlayer(this.PlayerLogic))
            .Add("List all team", () => SimpleMenu.ListAllTeams(this.TeamLogic))
            .Add("List all team statistics", () => SimpleMenu.ListAllTeamStat(this.TeamLogic))
            .Add("List player quantity in each team", () => SimpleMenu.GetPlayerQtyByTeams(this.PlayerLogic))
            .Add("Back", ConsoleMenu.Close).Show())
            .Add("GET ONE >", m => new ConsoleMenu()
            .Add("List one player", () => SimpleMenu.GetOnePlayer(this.PlayerLogic))
            .Add("Player who played the most", () => SimpleMenu.GetPlayerWithTheMostGamesPlayed(this.PlayerLogic))
            .Add("Back", ConsoleMenu.Close).Show())
            .Add("INSERT METHODS >", m => new ConsoleMenu()
            .Add("Insert new player", () => this.AddPlayer())
            .Add("Back", ConsoleMenu.Close).Show())
            .Add("UPDATE METHODS >", m => new ConsoleMenu()
            .Add("Back", ConsoleMenu.Close).Show())
            .Add("REMOVE METHODS >", m => new ConsoleMenu()
            .Add("Remove player", () => SimpleMenu.DeletePlayer(this.PlayerLogic))
            .Add("Back", ConsoleMenu.Close).Show())
            .Add("EXIT", ConsoleMenu.Close);
            menu.Show();
        }

        private void AddPlayer()
        {
            this.PlayerLogic?.GetAllPlayers().ToList().ForEach(x => Console.WriteLine(x.Name));
            Console.WriteLine("\nEnter new player's name:");
            string name = Console.ReadLine();
            Console.WriteLine("\nEnter new player's date of birth: (YYYY, MM, DD)");
            DateTime dob = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("\nEnter new player's height (cm)");
            int height = int.Parse(Console.ReadLine());
            Console.WriteLine("\nEnter new player's weight (kg)");
            int weight = int.Parse(Console.ReadLine());
            Console.WriteLine("\nEnter new player's number");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("\nEnter new player's post");
            string post = Console.ReadLine();
            Console.WriteLine("\nEnter new player's salary");
            int salary = int.Parse(Console.ReadLine());
            this.PlayerLogic?.AddNewPlayer(new Player()
            {
                Name = name,
                Birth = dob,
                Height = height,
                Weight = weight,
                Number = number,
                Post = post,
                Salary = salary,
            });
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(">>> Player added to the database!");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
