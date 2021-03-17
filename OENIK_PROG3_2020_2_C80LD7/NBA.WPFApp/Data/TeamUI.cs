// <copyright file="TeamUI.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.WPFApp.Data
{
    using System.Linq;
    using GalaSoft.MvvmLight;
    using NBA.Data.Model;

    /// <summary>
    /// Team ui entity.
    /// </summary>
    public class TeamUI : ObservableObject
    {
        private int teamID;
        private string teamName;
        private string coach;
        private string region;

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
        /// Gets or sets the team's coach.
        /// </summary>
        public string Coach
        {
            get { return this.coach; }
            set { this.Set(ref this.coach, value); }
        }

        /// <summary>
        /// Gets or sets the team's location.
        /// </summary>
        public string Region
        {
            get { return this.region; }
            set { this.Set(ref this.region, value); }
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
                team.Coach = teamui.Coach;
                team.Region = teamui.Region;
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
                teamui.Coach = team.Coach;
                teamui.Region = team.Region;
            }

            return teamui;
        }

        /// <summary>
        /// Copies a team entity.
        /// </summary>
        /// <param name="other">team to copy.</param>
        public void CopyFrom(TeamUI other)
        {
            this.GetType().GetProperties().ToList().
                ForEach(property => property.SetValue(this, property.GetValue(other)));
        }

        /// <summary>
        /// Overrides the tostring method. It returs the team's name.
        /// </summary>
        /// <returns>string.</returns>
        public override string ToString()
        {
            return this.TeamName;
        }

        /// <summary>
        /// Overrides equals method.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>true or false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is TeamUI)
            {
                TeamUI secondTeam = obj as TeamUI;
                return this.TeamID == secondTeam.TeamID && this.TeamName == secondTeam.TeamName && this.Coach == secondTeam.Coach && this.Region == secondTeam.Region;
            }

            return false;
        }

        /// <summary>
        /// Overries get hash code method.
        /// </summary>
        /// <returns>int.</returns>
        public override int GetHashCode()
        {
            return this.TeamID;
        }
    }
}
