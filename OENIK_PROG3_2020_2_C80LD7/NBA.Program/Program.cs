using ConsoleTools;
using NBA.Data.Model;
using NBA.Repository;
using System;
using System.Linq;

namespace NBA.Program
{
    public class Program
    {
        static void Main(string[] args)
        {
            //NBADbContext ctx = new NBADbContext();
            //Console.WriteLine(ctx.Player.Count());
            //Player p = new Player();
            //PlayerRepository pr = new PlayerRepository(ctx);
            //Console.WriteLine(pr.GetOne(4).Name);

            //var menu = new ConsoleMenu().
            //    Add("Delete Player", () => Console.WriteLine("Ez még nincs kész")).
            //    Add("Exit", ConsoleMenu.Close);
            //menu.Show();


            Factory f = new Factory();
            f.Menu.Show();
        }
    }
}
