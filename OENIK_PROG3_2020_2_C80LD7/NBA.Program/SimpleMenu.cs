﻿// <copyright file="SimpleMenu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
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
            string header = $"{"ID",-4} {"NAME",-20} {"BIRTH",-15} {"HEIGHT",-8} {"WEIGHT",-8} {"POST",-8} {"SALARY",-12} {"NUMBER",-2}";
            Console.WriteLine(header);
            Console.WriteLine(playerLogic.GetOnePlayerByID(id).ToString());
            Console.ReadLine();
        }
    }
}
