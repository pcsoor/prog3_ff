// <copyright file="MainVM.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.WpfClient
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using CommonServiceLocator;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;

    /// <summary>
    /// Main view model.
    /// </summary>
    public class MainVM : ViewModelBase
    {
        private MainLogic logic;
        private PlayerVM selectedPlayer;
        private ObservableCollection<PlayerVM> allPlayers;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainVM"/> class.
        /// </summary>
        /// <param name="logic">logic reference.</param>
        public MainVM(MainLogic logic)
        {
            this.logic = logic;

            this.AllPlayers = new ObservableCollection<PlayerVM>();

            if (this.IsInDesignMode)
            {
                PlayerVM first = new PlayerVM() { PlayerID = 1, Name = "Jakab András", Birth = new DateTime(2000, 09, 01), Height = 192, Weight = 100, Number = 10, Salary = 1111111, Post = PositionType.Center, TeamName = "LA Clippers" };
                PlayerVM second = new PlayerVM() { PlayerID = 1, Name = "Kiss Béla", Birth = new DateTime(1994, 05, 27), Height = 185, Weight = 85, Number = 3, Salary = 2222222, Post = PositionType.ShootingGuard, TeamName = "Houston Rockets" };
                this.AllPlayers.Add(first);
                this.AllPlayers.Add(second);
            }

            this.LoadCmd = new RelayCommand(() => this.AllPlayers = new ObservableCollection<PlayerVM>(this.logic.ApiGetPlayers()));
            this.DelCmd = new RelayCommand(() => this.logic.ApiDelPlayer(this.selectedPlayer));
            this.AddCmd = new RelayCommand(() => this.logic.EditPlayer(null, this.EditorFunc));
            this.ModCmd = new RelayCommand(() => this.logic.EditPlayer(this.selectedPlayer, this.EditorFunc));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainVM"/> class.
        /// </summary>
        public MainVM()
            : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<MainLogic>())
        {
        }

        /// <summary>
        /// Gets or sets all players.
        /// </summary>
        public ObservableCollection<PlayerVM> AllPlayers
        {
            get { return this.allPlayers; }
            set { this.Set(ref this.allPlayers, value); }
        }

        /// <summary>
        /// Gets or sets selected player.
        /// </summary>
        public PlayerVM SelectedPlayer
        {
            get { return this.selectedPlayer; }
            set { this.Set(ref this.selectedPlayer, value); }
        }

        /// <summary>
        /// Gets or sets editor function.
        /// </summary>
        public Func<PlayerVM, bool> EditorFunc { get; set; }

        /// <summary>
        /// Gets add command.
        /// </summary>
        public ICommand AddCmd { get; private set; }

        /// <summary>
        /// Gets delete command.
        /// </summary>
        public ICommand DelCmd { get; private set; }

        /// <summary>
        /// Gets modify command.
        /// </summary>
        public ICommand ModCmd { get; private set; }

        /// <summary>
        /// Gets load command.
        /// </summary>
        public ICommand LoadCmd { get; private set; }
    }
}
