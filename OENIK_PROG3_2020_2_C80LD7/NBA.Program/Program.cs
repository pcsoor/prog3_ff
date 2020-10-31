using NBA.Data.Model;
using NBA.Repository;
using System;
using System.Linq;

namespace NBA.Program
{
    class Program
    {
        static void Main(string[] args)
        {
            NBADbContext ctx = new NBADbContext();
            Console.WriteLine(ctx.Player.Count());
            Player p = new Player();
            PlayerRepository pr = new PlayerRepository(ctx);
            Console.WriteLine(pr.GetOne(4).Name);
            Console.ReadLine();
           
        }
    }
}
