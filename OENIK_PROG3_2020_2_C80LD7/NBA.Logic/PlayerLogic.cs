using NBA.Data.Model;
using NBA.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NBA.Logic
{
    public class PlayerLogic : IPlayerLogic
    {
        IPlayerRepository playerRepo;

        public PlayerLogic(IPlayerRepository repo)
        {
            this.playerRepo = repo;
        }
        public IList<Player> GetAllPlayers()
        {
            return playerRepo.GetAll().ToList();
        }

        
    }
}
