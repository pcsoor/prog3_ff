using NBA.Data.Model;
using NBA.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NBA.Logic
{
    public class TeamLogic : ITeamLogic
    {
        ITeamsRepository teamRepo;

        public TeamLogic(ITeamsRepository teamRepo)
        {
            this.teamRepo = teamRepo;
        }

        public Teams GetOneTeam(int id)
        {
            return teamRepo.GetOne(id);
        }
    }
}
