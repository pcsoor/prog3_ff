// <copyright file="ITeamUiLogic.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.WPFApp.BL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NBA.WPFApp.Data;

    /// <summary>
    /// Team logic interface.
    /// </summary>
    public interface ITeamUiLogic
    {
        /// <summary>
        /// Adds new team to the list.
        /// </summary>
        /// <param name="list">list of teams in ui.</param>
        void AddTeam(IList<TeamUI> list);

        /// <summary>
        /// Modify a team's props.
        /// </summary>
        /// <param name="teamToModify">team in ui to modify.</param>
        void ModTeam(TeamUI teamToModify);

        /// <summary>
        /// Deletes one team from the list and from the db as well.
        /// </summary>
        /// <param name="list">list of players in ui.</param>
        /// <param name="team">team in ui to delete.</param>
        void DelTeam(IList<TeamUI> list, TeamUI team);

        /// <summary>
        /// Retruns a list of teams in ui.
        /// </summary>
        /// <returns>IList collection.</returns>
        IList<TeamUI> GetAllTeam();
    }
}
