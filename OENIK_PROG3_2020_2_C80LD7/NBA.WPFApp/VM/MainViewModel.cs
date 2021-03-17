// <copyright file="MainViewModel.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.WPFApp.VM
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using CommonServiceLocator;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using GalaSoft.MvvmLight.Ioc;
    using NBA.Logic;
    using NBA.WPFApp.BL;
    using NBA.WPFApp.Data;

    /// <summary>
    /// Main view model class that implements view model base.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private IPlayerUiLogic logic;
        private ITeamUiLogic teamUiLogic;
        private PlayerUI playerSelected;
        private TeamUI teamSelected;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        /// <param name="logic">Player ui logic ref.</param>
        /// <param name="teamUiLogic">Team ui logic ref.</param>
        public MainViewModel(IPlayerUiLogic logic, ITeamUiLogic teamUiLogic)
        {
            this.logic = logic;
            this.teamUiLogic = teamUiLogic;

            this.TeamCollection = new ObservableCollection<TeamUI>();
            this.Team = new ObservableCollection<PlayerUI>();

            if (this.IsInDesignMode)
            {
                PlayerUI p1 = new PlayerUI() { Name = "Test Test", Birth = new DateTime(1984, 12, 20), Height = 206, Weight = 113, Number = 23, Post = PositionTypeUI.PointGuard, Salary = 37436858, TeamUI = new TeamUI { TeamName = "Test", Coach = "Test Coach", Region = "Test region" } };
                PlayerUI p2 = new PlayerUI() { Name = "Test2 Test2", Birth = new DateTime(1988, 09, 29), Height = 208, Weight = 109, Number = 35, Post = PositionTypeUI.PowerForward, Salary = 37199000, TeamUI = new TeamUI { TeamName = "Test", Coach = "Test Coach", Region = "Test region" } };
                this.Team.Add(p1);
                this.Team.Add(p2);
            }
            else
            {
                foreach (var item in this.logic.GetAllPlayers())
                {
                    TeamUI.ConvertToTeamEntity(item.TeamUI);
                    this.Team.Add(item);
                }

                foreach (var item in this.teamUiLogic.GetAllTeam())
                {
                    this.TeamCollection.Add(item);
                }
            }

            this.AddCmd = new RelayCommand(() => this.logic.AddPlayer(this.Team));
            this.ModCmd = new RelayCommand(() => this.logic.ModPlayer(this.PlayerSelected));
            this.DelCmd = new RelayCommand(() => this.logic.DelPlayer(this.Team, this.PlayerSelected));

            this.AddTeamCmd = new RelayCommand(() => this.teamUiLogic.AddTeam(this.TeamCollection));
            this.ModTeamCmd = new RelayCommand(() => this.teamUiLogic.ModTeam(this.TeamSelected));
            this.DelTeamCmd = new RelayCommand(() => this.teamUiLogic.DelTeam(this.TeamCollection, this.TeamSelected));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// implements main view model.
        /// </summary>
        public MainViewModel()
            : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<IPlayerUiLogic>(), IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<ITeamUiLogic>())
        {
        }

        /// <summary>
        /// Gets or sets the selected player.
        /// </summary>
        public PlayerUI PlayerSelected
        {
            get { return this.playerSelected; }
            set { this.Set(ref this.playerSelected, value); }
        }

        /// <summary>
        /// Gets or sets selected team.
        /// </summary>
        public TeamUI TeamSelected
        {
            get { return this.teamSelected; }
            set { this.Set(ref this.teamSelected, value); }
        }

        // public TeamUI TeamSelected
        // {
        //    get { return this.teamSelected; }
        //    set { Set(ref teamSelected, value); }
        // }

        /// <summary>
        /// Gets team collection.
        /// </summary>
        public ObservableCollection<PlayerUI> Team { get; private set; }

        /// <summary>
        /// Gets collection of teams.
        /// </summary>
        public ObservableCollection<TeamUI> TeamCollection { get; private set; }

        /// <summary>
        /// Gets add command.
        /// </summary>
        public ICommand AddCmd { get; private set; }

        /// <summary>
        /// Gets modification command.
        /// </summary>
        public ICommand ModCmd { get; private set; }

        /// <summary>
        /// Gets delete command.
        /// </summary>
        public ICommand DelCmd { get; private set; }

        /// <summary>
        /// Gets add command.
        /// </summary>
        public ICommand AddTeamCmd { get; private set; }

        /// <summary>
        /// Gets modification command.
        /// </summary>
        public ICommand ModTeamCmd { get; private set; }

        /// <summary>
        /// Gets delete command.
        /// </summary>
        public ICommand DelTeamCmd { get; private set; }
    }
}
