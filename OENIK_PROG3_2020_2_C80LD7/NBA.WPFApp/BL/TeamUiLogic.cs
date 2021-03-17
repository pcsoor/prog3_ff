// <copyright file="TeamUiLogic.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.WPFApp.BL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using GalaSoft.MvvmLight.Ioc;
    using GalaSoft.MvvmLight.Messaging;
    using NBA.Logic;
    using NBA.WPFApp.Data;

    /// <summary>
    /// Business Logic of team.
    /// </summary>
    public class TeamUiLogic : ITeamUiLogic
    {
        private readonly IEditorService editorService;
        private readonly IMessenger messengerService;
        private readonly Logic.ITeamLogic teamLogic;
        private readonly Factory factory;
        private readonly TeamUI teamuidata;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamUiLogic"/> class.
        /// </summary>
        /// <param name="editorService">editor service ref.</param>
        /// <param name="messengerService">messenger service ref.</param>
        /// <param name="teamLogic">team logic ref.</param>
        /// <param name="factory">ref to factory.</param>
        /// <param name="teamuidata">ref to team data.</param>
        [PreferredConstructor]
        public TeamUiLogic(IEditorService editorService, IMessenger messengerService, ITeamLogic teamLogic, Factory factory, TeamUI teamuidata)
        {
            this.editorService = editorService;
            this.messengerService = messengerService;
            this.teamLogic = teamLogic;
            this.factory = factory;
            this.teamuidata = teamuidata;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamUiLogic"/> class.
        /// </summary>
        /// <param name="teamLogic">Ref to team logic.</param>
        public TeamUiLogic(ITeamLogic teamLogic)
        {
            this.teamLogic = teamLogic;
        }

        /// <summary>
        /// Adds a team to list.
        /// </summary>
        /// <param name="list">list of teams.</param>
        public void AddTeam(IList<TeamUI> list)
        {
            TeamUI newTeam = new TeamUI();
            if (this.editorService.EditTeam(newTeam) == true)
            {
                list?.Add(newTeam);
                this.teamLogic.AddNewTeam(new NBA.Data.Model.Teams
                {
                    Name = newTeam.TeamName,
                    Coach = newTeam.Coach,
                    Region = newTeam.Region,
                });

                list.Last().TeamID = this.teamLogic.GetAllTeams().Last().TeamID;
                this.messengerService.Send("ADD OK", "LogicResult");
            }
        }

        /// <summary>
        /// Deletes one team from list.
        /// </summary>
        /// <param name="list">list of teams.</param>
        /// <param name="team">team ref.</param>
        public void DelTeam(IList<TeamUI> list, TeamUI team)
        {
            if (team != null && list != null && list.Remove(team))
            {
                var toDel = this.teamLogic.GetOneTeamById(TeamUI.ConvertToTeamEntity(team).TeamID);
                this.teamLogic.DeleteTeam(toDel.TeamID);
                this.messengerService.Send("DELETE OK", "LogicResult");
            }
            else
            {
                this.messengerService.Send("DELETE FAILED", "LogicResult");
            }
        }

        /// <summary>
        /// Returns a list of all team.
        /// </summary>
        /// <returns>list.</returns>
        public IList<TeamUI> GetAllTeam()
        {
            List<TeamUI> teamUiEntities = new List<TeamUI>();
            if (this.teamLogic.GetAllTeams() != null)
            {
                foreach (var entity in this.teamLogic.GetAllTeams())
                {
                    teamUiEntities.Add(TeamUI.ConvertToTeamUiEntity(entity));
                }

                this.messengerService.Send("QUERY OK", "LogicResult");
                return teamUiEntities;
            }
            else
            {
                this.messengerService.Send("QUERY FAILED", "LogicResult");
                return null;
            }
        }

        /// <summary>
        /// Modifies one team.
        /// </summary>
        /// <param name="teamToModify">team to mod.</param>
        public void ModTeam(TeamUI teamToModify)
        {
            if (teamToModify == null)
            {
                this.messengerService.Send("EDIT FAILED", "LogicResult");
                return;
            }

            TeamUI clone = new TeamUI();
            this.teamLogic.GetOneTeamById(teamToModify.TeamID);
            clone.CopyFrom(teamToModify);
            if (this.editorService.EditTeam(clone) == true)
            {
                teamToModify.CopyFrom(clone);
                this.teamLogic.UpdateTeam(this.teamLogic.GetOneTeamById(clone.TeamID).TeamID);
                this.messengerService.Send("MODIFY OK", "LogicResult");
            }
            else
            {
                this.messengerService.Send("MODIFY CANCEL", "LogicResult");
            }
        }
    }
}
