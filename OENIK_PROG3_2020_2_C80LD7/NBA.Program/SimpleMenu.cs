using NBA.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NBA.Program
{
    class SimpleMenu
    {
        public void ListAllTeams(TeamLogic teamsLogic)
        {
            Console.WriteLine("List of teams");
            string fejlec = string.Format("{0,-4} {1,-25} {2,-20} {3,-1}", "ID", "NAME", "COACH", "REGION");
            Console.WriteLine(fejlec);
            teamsLogic.GetAllTeams()
                .ToList().ForEach(x => Console.WriteLine(x.ToString()));
            Console.ReadLine();
        }

        public void ListAllPlayer(PlayerLogic playerLogic)
        {
            Console.WriteLine("List of players");
            string header = string.Format("{0,-4} {1,-20} {2,-15} {3,-8} {4,-8} {5,-8} {6,-12} {7,0}",
                "ID", "NAME", "BIRTH", "HEIGHT", "WEIGHT", "POST", "NUMBER", "SALARY");
            Console.WriteLine(header);
            playerLogic.GetAllPlayers()
                .ToList().ForEach(x => Console.WriteLine(x.ToString()));
            Console.ReadLine();
        }

        public void ListAllTeamStat(TeamLogic teamLogic)
        {
            Console.WriteLine("List of team stats:");
            string header = string.Format("{0,-6} {1,-6} {2,-6} {3,-6} {4,-6} {5,-6} {6,-6} {7,-6}",
                "ID","GP", "PPG", "REB", "STL", "AST", "BLK", "FGM");
            Console.WriteLine(header);
            teamLogic.GetAllTeamStat()
                .ToList().ForEach(x => Console.WriteLine(x.ToString()));
            Console.ReadLine();

        }

        public void GetOnePlayer(PlayerLogic playerLogic)
        {
            Console.WriteLine("Enter player's ID");
            int id = int.Parse(Console.ReadLine());
            string header = string.Format("{0,-4} {1,-20} {2,-15} {3,-8} {4,-8} {5,-8} {6,-12} {7,-2}",
                "ID", "NAME", "BIRTH", "HEIGHT", "WEIGHT", "POST", "SALARY", "NUMBER");
            Console.WriteLine(header);
            Console.WriteLine(playerLogic.GetOnePlayerByID(id).ToString());
            Console.ReadLine();

        }

    }
}
