namespace NBA.Program
{
    using ConsoleTools;
    using NBA.Data.Model;
    using NBA.Logic;
    using NBA.Repository;
    using System;
    using System.Linq;

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
        private static SeriesRepository seriesRepo = new SeriesRepository(ctx);

        /// <summary>
        /// Initializes a new instance of the <see cref="Factory"/> class.
        /// </summary>
        public Factory()
        {
            this.PlayerLogic = new PlayerLogic(playerRepo);
            this.TeamLogic = new TeamLogic(teamRepo);
            this.Menu = new ConsoleMenu();
            this.Kiir();
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

        public void Kiir()
        {
            this.Menu.Add("Insert Player", () => this.AddPlayer());
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
            playerRepo.AddPlayer(new Player()
            {
                Name = name,
                Birth = dob,
                Height = height,
                Weight = weight,
                Number = number,
                Post = post,
                Salary = salary,
            });
            Console.WriteLine(">>> Player added to the database!");
            Console.ReadKey();
        }
    }
}
