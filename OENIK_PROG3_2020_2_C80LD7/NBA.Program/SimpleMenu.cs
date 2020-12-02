// <copyright file="SimpleMenu.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.Program
{
    using System;
    using System.Linq;
    using NBA.Logic;

    /// <summary>
    /// class of console menu where operation methods are called.
    /// </summary>
    internal class SimpleMenu
    {
        /// <summary>
        /// Returns a list of all teams.
        /// </summary>
        /// <param name="teamsLogic">teamlogic.</param>
        public static void ListAllTeams(TeamLogic teamsLogic)
        {
            Console.WriteLine("List of teams");
            string fejlec = $"{"ID",-4} {"NAME",-25} {"COACH",-20} {"REGION",-1}";
            Console.WriteLine(fejlec);
            teamsLogic.GetAllTeams()
                .ToList().ForEach(x => Console.WriteLine(x.ToString()));
            Console.ReadLine();
        }

        /// <summary>
        /// Returns a list of all players.
        /// </summary>
        /// <param name="playerLogic">playerlogic.</param>
        public static void ListAllPlayer(PlayerLogic playerLogic)
        {
            Console.WriteLine("List of players");
            string header = $"{"ID",-4} {"NAME",-20} {"BIRTH",-15} {"HEIGHT",-8} {"WEIGHT",-8} {"POST",-8} {"NUMBER",-12} {"SALARY",0}";
            Console.WriteLine(header);
            playerLogic.GetAllPlayers()
                .ToList().ForEach(x => Console.WriteLine(x.ToString()));
            Console.ReadLine();
        }

        /// <summary>
        /// Return a list of all team statistics.
        /// </summary>
        /// <param name="teamLogic">teamlogic.</param>
        public static void ListAllTeamStat(TeamLogic teamLogic)
        {
            Console.WriteLine("List of team stats:");
            string header = $"{"ID",-6} {"GP",-6} {"PPG",-6} {"REB",-6} {"STL",-6} {"AST",-6} {"BLK",-6} {"FGM",-6}";
            Console.WriteLine(header);
            teamLogic.GetAllTeamStat()
                .ToList().ForEach(x => Console.WriteLine(x.ToString()));
            Console.ReadLine();
        }

        /// <summary>
        /// Returns one player's data.
        /// </summary>
        /// <param name="playerLogic">playerlogic.</param>
        public static void GetOnePlayer(PlayerLogic playerLogic)
        {
            Console.WriteLine("Enter player's ID");

            int id = int.Parse(Console.ReadLine());
            bool exist = false;
            try
            {
                playerLogic?.GetOnePlayerById(id);
                exist = true;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Wrong player ID! Try another one..");
                GetOnePlayer(playerLogic);
            }

            if (exist)
            {
                string header = $"{"ID",-4} {"NAME",-20} {"BIRTH",-15} {"HEIGHT",-8} {"WEIGHT",-8} {"POST",-8} {"SALARY",-12} {"NUMBER",-2}";
                Console.WriteLine(header);
                Console.WriteLine(playerLogic.GetOnePlayerById(id).ToString());
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Deletes one team by id given.
        /// </summary>
        /// <param name="teamLogic">teamLogic reference.</param>
        public static void DeleteTeam(TeamLogic teamLogic)
        {
            Console.WriteLine("Give me the team's id:");

            int num = int.Parse(Console.ReadLine());
            bool exist = false;
            try
            {
                teamLogic?.DeleteTeam(num);
                exist = true;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("This team does not exist!");
                DeleteTeam(teamLogic);
            }

            if (exist)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($">>> Team with id {num} deleted");
                Console.ResetColor();
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Returns how many players are there in each team.
        /// </summary>
        /// <param name="playerLogic">playerLogic.</param>
        public static void GetPlayerQtyByTeams(PlayerLogic playerLogic)
        {
            foreach (var item in playerLogic.GetPlayerQtyByTeams())
            {
                Console.WriteLine($"{item.Name} - {item.Avg}");
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Calls the method in logic.
        /// </summary>
        /// <param name="playerLogic">playerLogic reference.</param>
        public static void GetPlayerWithTheMostGamesPlayed(PlayerLogic playerLogic)
        {
            Console.WriteLine(playerLogic.GetPlayerWithTheMostGamesPlayed().FirstOrDefault());
            Console.ReadLine();
        }

        /// <summary>
        /// Calls tge deleteplayer method in logic.
        /// </summary>
        /// <param name="playerLogic">playerLogic reference.</param>
        public static void DeletePlayer(PlayerLogic playerLogic)
        {
            Console.WriteLine("Give me the player's ID:");
            int playerID = int.Parse(Console.ReadLine());
            playerLogic.DeletePlayer(playerID);
            Console.WriteLine("Player deleted");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(">>> Player deleted!");
            Console.ResetColor();
            Console.ReadKey();
        }

        /// <summary>
        /// Gets the number of won series by team.
        /// </summary>
        /// <param name="teamLogic">teamlogic reference.</param>
        public static void GetWinQtyByTeams(TeamLogic teamLogic)
        {
            foreach (var item in teamLogic.GetWinQtyByTeams())
            {
                Console.WriteLine($"{item.Name} - {item.Avg}");
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Gets one player's average point per game.
        /// </summary>
        /// <param name="playerLogic">playerLogic reference.</param>
        public static void GetPlayerAveragePointPerGame(PlayerLogic playerLogic)
        {
            foreach (var item in playerLogic.GetPlayerAveragePointPerGame())
            {
                Console.WriteLine($"{item.Name} - {item.Avg}");
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Updates player's salary.
        /// </summary>
        /// <param name="playerLogic">playerLogic reference.</param>
        public static void UpdatePlayerSalary(PlayerLogic playerLogic)
        {
            Console.WriteLine("Give me the player's id:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Give me the value:");
            int newsalary = int.Parse(Console.ReadLine());
            bool exist = false;
            try
            {
                playerLogic?.ChangePlayerSalary(id, newsalary);
                exist = true;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Player don't exist with this id.");
                UpdatePlayerSalary(playerLogic);
            }

            if (exist)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(">>> Player's salary changed..");
                Console.ResetColor();
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Updates team's name.
        /// </summary>
        /// <param name="teamLogic">teamLogic reference.</param>
        public static void ChangeTeamName(TeamLogic teamLogic)
        {
            Console.WriteLine("Give me the team's id:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Type the team's new name:");
            string newname = Console.ReadLine();

            bool exist = false;

            try
            {
                teamLogic?.ChangeTeamName(id, newname);
                exist = true;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("This team does not exist with this id!");
                ChangeTeamName(teamLogic);
            }

            if (exist)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(">>> Team's name changed..");
                Console.ResetColor();
            }

            Console.ReadLine();
        }
    }
}
