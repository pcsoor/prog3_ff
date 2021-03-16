// <copyright file="SimpleMenu.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.Program
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using NBA.Data.Model;
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
            MyCw("List of teams");
            string fejlec = $"{"ID",-4} {"NAME",-25} {"COACH",-20} {"REGION",-1}";
            MyCw(fejlec);
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
            MyCw("List of players");
            string header = $"{"ID",-4} {"NAME",-20} {"BIRTH",-15} {"HEIGHT",-8} {"WEIGHT",-8} {"POST",-8} {"NUMBER",-12} {"SALARY",0}";
            MyCw(header);
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
            MyCw("List of team stats:");
            string header = $"{"ID",-6} {"GP",-6} {"PPG",-6} {"REB",-6} {"STL",-6} {"AST",-6} {"BLK",-6} {"FGM",-6}";
            MyCw(header);
            teamLogic.GetAllTeamStat()
                .ToList().ForEach(x => Console.WriteLine(x.ToString()));
            Console.ReadLine();
        }

        /// <summary>
        /// List all series.
        /// </summary>
        /// <param name="teamLogic">TeamLogic reference.</param>
        public static void ListAllSeriesResult(TeamLogic teamLogic)
        {
            MyCw("List of all series result:");
            string header = $"{"YEAR",-4} {"WINNER ID",-4} {"LOSER ID",-4} {"RESULT",-4}";
            MyCw(header);
            teamLogic.GetAllSeriesResult().ToList().ForEach(x => Console.WriteLine(x.ToString()));
            Console.ReadLine();
        }

        /// <summary>
        /// Returns one player's data.
        /// </summary>
        /// <param name="playerLogic">playerlogic.</param>
        public static void GetOnePlayer(PlayerLogic playerLogic)
        {
            MyCw("Enter player's ID");

            int id = int.Parse(Console.ReadLine(), CultureInfo.CurrentCulture);
            bool exist = false;
            try
            {
                playerLogic?.GetOnePlayerById(id);
                exist = true;
            }
            catch (ArgumentException)
            {
                MyCw("Wrong player ID! Try another one..");
                GetOnePlayer(playerLogic);
            }

            if (exist)
            {
                string header = $"{"ID",-4} {"NAME",-20} {"BIRTH",-15} {"HEIGHT",-8} {"WEIGHT",-8} {"POST",-8} {"SALARY",-12} {"NUMBER",-2}";
                MyCw(header);
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
            MyCw("Give me the team's id:");

            int num = int.Parse(Console.ReadLine(), CultureInfo.CurrentCulture);
            bool exist = false;
            try
            {
                teamLogic?.DeleteTeam(num);
                exist = true;
            }
            catch (ArgumentException)
            {
                MyCw("This team does not exist!");
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
            MyCw("Give me the player's ID:");
            int playerID = int.Parse(Console.ReadLine(), CultureInfo.CurrentCulture);
            playerLogic.DeletePlayer(playerID);
            MyCw("Player deleted");
            Console.ForegroundColor = ConsoleColor.Red;
            MyCw(">>> Player deleted!");
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
            MyCw("Give me the player's id:");
            int id = int.Parse(Console.ReadLine(), CultureInfo.CurrentCulture);
            MyCw("Give me the value:");
            int newsalary = int.Parse(Console.ReadLine(), CultureInfo.CurrentCulture);
            bool exist = false;
            try
            {
                playerLogic?.ChangePlayerSalary(id, newsalary);
                exist = true;
            }
            catch (ArgumentException)
            {
                MyCw("Player don't exist with this id.");
                UpdatePlayerSalary(playerLogic);
            }

            if (exist)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                MyCw(">>> Player's salary changed..");
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
            MyCw("Give me the team's id:");
            int id = int.Parse(Console.ReadLine(), CultureInfo.CurrentCulture);
            MyCw("Type the team's new name:");
            string newname = Console.ReadLine();

            bool exist = false;

            try
            {
                teamLogic?.ChangeTeamName(id, newname);
                exist = true;
            }
            catch (ArgumentException)
            {
                MyCw("This team does not exist with this id!");
                ChangeTeamName(teamLogic);
            }

            if (exist)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                MyCw(">>> Team's name changed..");
                Console.ResetColor();
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Updates final result of the series.
        /// </summary>
        /// <param name="teamLogic">TeamLogic reference.</param>
        public static void ChangeFinalResult(TeamLogic teamLogic)
        {
            MyCw("Type the year of the series:");
            int year = int.Parse(Console.ReadLine(), CultureInfo.CurrentCulture);
            MyCw("Type the new result: (separate with '-'! (eg: 3-4))");
            string res = Console.ReadLine();
            bool exist = false;
            try
            {
                teamLogic.ChangeFinalResult(year, res);
                exist = true;
            }
            catch (ArgumentException)
            {
                MyCw("This series doesn't exist in the database!");
                ChangeFinalResult(teamLogic);
            }

            if (exist)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                MyCw("Final result updated successfully!");
                Console.ResetColor();
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Updates winner team's id.
        /// </summary>
        /// <param name="teamLogic">TeamLogic reference.</param>
        public static void ChangeWinnerId(TeamLogic teamLogic)
        {
            MyCw("Type the year of the series:");
            int year = int.Parse(Console.ReadLine(), CultureInfo.CurrentCulture);
            MyCw("Type winner team's id:");
            int winid = int.Parse(Console.ReadLine(), CultureInfo.CurrentCulture);
            bool exist = false;
            try
            {
                teamLogic.ChangeWinnerId(year, winid);
                exist = true;
            }
            catch (ArgumentException)
            {
                MyCw("This series doesn't exist in the database!");
                ChangeFinalResult(teamLogic);
            }

            if (exist)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                MyCw("Winner team's id updated successfully!");
                Console.ResetColor();
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Updates loser team's id.
        /// </summary>
        /// <param name="teamLogic">TeamLogic reference.</param>
        public static void ChangeLoserId(TeamLogic teamLogic)
        {
            MyCw("Type loser team's id:");
            int year = int.Parse(Console.ReadLine(), CultureInfo.CurrentCulture);
            MyCw("Type loser team's id:");
            int loserid = int.Parse(Console.ReadLine(), CultureInfo.CurrentCulture);
            bool exist = false;
            try
            {
                teamLogic.ChangeLoserId(year, loserid);
                exist = true;
            }
            catch (ArgumentException)
            {
                MyCw("This series doesn't exist in the database!");
                ChangeFinalResult(teamLogic);
            }

            if (exist)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                MyCw("Loser team's id updated successfully!");
                Console.ResetColor();
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Get players in one team.
        /// </summary>
        /// <param name="playerLogic">PlayerLogic ref.</param>
        public static void GetPlayerByTeam(PlayerLogic playerLogic)
        {
            MyCw("Type the team's id:");
            int team = int.Parse(MyCr(), CultureInfo.CurrentCulture);
            foreach (var item in playerLogic.GetPlayerByTeam(team))
            {
                Console.WriteLine($"{item.Name} - {item.TeamID}");
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Add new player to the database.
        /// </summary>
        /// <param name="playerLogic">PlayerLogic reference.</param>
        public static void AddPlayer(PlayerLogic playerLogic)
        {
            MyCw("\nEnter new player's name:");
            string name = Console.ReadLine();
            MyCw("\nEnter new player's date of birth: (YYYY, MM, DD)");
            DateTime dob = DateTime.Parse(MyCr(), CultureInfo.CurrentCulture);
            MyCw("\nEnter new player's height (cm)");
            int height = int.Parse(MyCr(), CultureInfo.CurrentCulture);
            MyCw("\nEnter new player's weight (kg)");
            int weight = int.Parse(MyCr(), CultureInfo.CurrentCulture);
            MyCw("\nEnter new player's number");
            int number = int.Parse(MyCr(), CultureInfo.CurrentCulture);
            MyCw("\nEnter new player's post");
            string post = Console.ReadLine();
            MyCw("\nEnter new player's salary");
            int salary = int.Parse(MyCr(), CultureInfo.CurrentCulture);
            MyCw("\nEnter new player's team");
            int team = int.Parse(MyCr(), CultureInfo.CurrentCulture);

            var list = new List<dynamic>();
            if (post == "PG")
            {
                list.Add(Player.PositionType.PointGuard);
            }
            else if (post == "SF")
            {
                list.Add(Player.PositionType.SmallForward);
            }
            else if (post == "SG")
            {
                list.Add(Player.PositionType.ShootingGuard);
            }
            else if (post == "C")
            {
                list.Add(Player.PositionType.Center);
            }
            else
            {
                list.Add(Player.PositionType.PowerForward);
            }

            playerLogic?.AddNewPlayer(new Player()
            {
                Name = name,
                Birth = dob,
                Height = height,
                Weight = weight,
                Number = number,
                Post = list.Last(),
                Salary = salary,
                TeamID = team,
            });

            Console.ForegroundColor = ConsoleColor.Green;
            MyCw(">>> Player added to the database!");
            Console.ResetColor();
            Console.ReadKey();
        }

        /// <summary>
        /// Returns how many steals a team made in one series.
        /// </summary>
        /// <param name="teamLogic">TeamLogic reference.</param>
        public static void GetTeamAverageStealPerGame(TeamLogic teamLogic)
        {
            foreach (var item in teamLogic.GetTeamAverageStealPerGame())
            {
                MyCw($"{item.Name} - {item.Avg}");
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Gets average steals per game in one team with async task.
        /// </summary>
        /// <param name="teamLogic">Returns list.</param>
        public static void GetTeamAverageStealPerGameAsync(TeamLogic teamLogic)
        {
            var task = teamLogic.GetTeamAverageStealPerGameAsync();
            task.Wait();
            var res2 = task.Result;
            foreach (var item in res2)
            {
                MyCw($"{item.Name} - {item.Avg}");
                Thread.Sleep(800);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Gets average point per games in prev season by players with async task.
        /// </summary>
        /// <param name="playerLogic">Returns list.</param>
        public static void GetPlayerAveragePointPerGameAsync(PlayerLogic playerLogic)
        {
            var task = playerLogic.GetPlayerAveragePointPerGameAsync();
            task.Wait();
            var res2 = task.Result;
            foreach (var item in res2)
            {
                MyCw($"{item.Name} - {item.Avg}");
                Thread.Sleep(800);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Gets player who played the most games in previous season with async task.
        /// </summary>
        /// <param name="playerLogic">Returns list.</param>
        public static void GetPlayerWithTheMostGamesPlayedAsync(PlayerLogic playerLogic)
        {
            var task = playerLogic.GetPlayerWithTheMostGamesPlayedAsync();
            task.Wait();
            var res2 = task.Result;
            Thread.Sleep(800);
            Console.WriteLine(res2.FirstOrDefault());

            Console.ReadLine();
        }

        /// <summary>
        /// Calls the writeline method.
        /// </summary>
        /// <param name="text">text to write to console.</param>
        public static void MyCw(string text)
        {
            Console.WriteLine(text);
        }

        /// <summary>
        /// calls readline method.
        /// </summary>
        /// <returns>input string.</returns>
        public static string MyCr()
        {
            return Console.ReadLine();
        }
    }
}
