namespace NBA.Logic
{
    using NBA.Data.Model;
    using NBA.Repository;

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
