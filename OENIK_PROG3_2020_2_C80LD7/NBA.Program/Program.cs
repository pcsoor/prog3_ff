using NBA.Data.Model;
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
            Console.ReadLine();
           
        }
    }
}
