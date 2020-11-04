namespace NBA.Logic
{
    using NBA.Data.Model;
    using NBA.Repository;
    using System.Collections.Generic;
    using System.Linq;

    public class TeamLogic : ITeamLogic
    {
        ITeamsRepository teamRepo;
        ITeamsStatsRepository teamStatsRepo;

        public TeamLogic(ITeamsRepository teamRepo, ITeamsStatsRepository teamStatsRepo)
        {
            this.teamRepo = teamRepo;
            this.teamStatsRepo = teamStatsRepo;
        }

        public IList<Teams> GetAllTeams()
        {
            return teamRepo.GetAll().ToList();
        }

        public Teams GetOneTeam(int id)
        {
            return teamRepo.GetOne(id);
        }

        public IList<TeamStats> GetAllTeamStat()
        {
            return teamStatsRepo.GetAll().ToList();
        }

        // NON-CRUD methods 
    }
}
