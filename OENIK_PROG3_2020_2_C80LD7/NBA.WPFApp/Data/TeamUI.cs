// <copyright file="TeamUI.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.WPFApp.Data
{
    using GalaSoft.MvvmLight;
    using NBA.Data.Model;

    /// <summary>
    /// Team ui entity.
    /// </summary>
    public class TeamUI : ObservableObject
    {
        private int teamID;
        private string teamName;

        /// <summary>
        /// Gets or sets the team's id.
        /// </summary>
        public int TeamID
        {
            get { return this.teamID; }
            set { this.Set(ref this.teamID, value); }
        }

        /// <summary>
        /// Gets or sets the team's name.
        /// </summary>
        public string TeamName
        {
            get { return this.teamName; }
            set { this.Set(ref this.teamName, value); }
        }

        /// <summary>
        /// Converts PlayerUI entity to Player db entity.
        /// </summary>
        /// <param name="teamui">Player ui entity.</param>
        /// <returns>Player db entity.</returns>
        public static Teams ConvertToTeamEntity(TeamUI teamui)
        {
            Teams team = new Teams();
            if (teamui != null)
            {
                team.TeamID = teamui.TeamID;
                team.Name = teamui.TeamName;
            }

            return team;
        }

        /// <summary>
        /// Converts one db player entity to player ui entity.
        /// </summary>
        /// <param name="team">player entity.</param>
        /// <returns>PlayerUI entity.</returns>
        public static TeamUI ConvertToTeamUiEntity(Teams team)
        {
            TeamUI teamui = new TeamUI();
            if (team != null)
            {
                teamui.TeamID = team.TeamID;
                teamui.TeamName = team.Name;
            }

            return teamui;
        }

        /// <summary>
        /// Overrides the tostring method. It returs the team's name.
        /// </summary>
        /// <returns>string.</returns>
        public override string ToString()
        {
            return this.TeamName;
        }
    }
}
