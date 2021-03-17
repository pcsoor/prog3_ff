// <copyright file="ITeamsRepository.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.Repository
{
    using NBA.Data.Model;

    /// <summary>
    /// Implements team specific operations.
    /// </summary>
    public interface ITeamsRepository : IRepository<Teams>
    {
        /// <summary>
        /// Changes team's name.
        /// </summary>
        /// <param name="id">team's id.</param>
        /// <param name="newname">team's new name.</param>
        void ChangeTeamName(int id, string newname);

        /// <summary>
        /// Updates team properties.
        /// </summary>
        /// <param name="id">team entity id.</param>
        void UpdateTeam(int id);
    }
}
