// <copyright file="EditorViewModel.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.WPFApp.VM
{
    using System;
    using System.Collections.ObjectModel;
    using CommonServiceLocator;
    using GalaSoft.MvvmLight;
    using NBA.Data.Model;
    using NBA.Logic;
    using NBA.WPFApp.Data;

    /// <summary>
    /// Editor window.
    /// </summary>
    public class EditorViewModel : ViewModelBase
    {
        private PlayerUI playerui;
        private TeamUI teamui;
        private ITeamLogic logic;
        private TeamUI selectedTeam;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorViewModel"/> class.
        /// </summary>
        /// <param name="logic">Team logic ref.</param>
        public EditorViewModel(ITeamLogic logic)
        {
            this.logic = logic;
            this.TeamCollection = new ObservableCollection<TeamUI>();

            this.playerui = new PlayerUI();

            if (this.IsInDesignMode)
            {
                this.playerui.Name = "Unknown Bill";
                this.playerui.Height = 200;
                this.playerui.Salary = 69696969;
            }
            else
            {
                foreach (var item in this.logic.GetAllTeams())
                {
                    this.TeamCollection.Add(TeamUI.ConvertToTeamUiEntity(item));
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorViewModel"/> class.
        /// </summary>
        public EditorViewModel()
            : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<ITeamLogic>())
        {
        }

        /// <summary>
        /// Gets list of positions.
        /// </summary>
        public static Array Positions
        {
            get { return Enum.GetValues(typeof(PositionTypeUI)); }
        }

        /// <summary>
        /// Gets or sets player ui entity.
        /// </summary>
        public PlayerUI PlayerUi
        {
            get { return this.playerui; }
            set { this.Set(ref this.playerui, value); }
        }

        /// <summary>
        /// Gets or sets returns selected team.
        /// </summary>
        public TeamUI SelectedTeam
        {
            get { return this.selectedTeam; }
            set { this.Set(ref this.selectedTeam, value); }
        }

        /// <summary>
        /// Gets collection of teams.
        /// </summary>
        public ObservableCollection<TeamUI> TeamCollection { get; private set; }

        /// <summary>
        /// Gets or sets team ui entity.
        /// </summary>
        public TeamUI TeamUi
        {
            get { return this.teamui; }
            set { this.Set(ref this.teamui, value); }
        }
    }
}
