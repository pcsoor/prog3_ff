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
    using NBA.WPFApp.BL;
    using NBA.WPFApp.Data;

    /// <summary>
    /// Main view model class that implements view model base.
    /// </summary>
    class MainViewModel : ViewModelBase
    {
        private IPlayerLogic logic;
        private Factory factory;
        private PlayerUI teamSelected;

        public PlayerUI TeamSelected
        {
            get { return teamSelected; }
            set { Set(ref teamSelected, value); }
        }

        public ObservableCollection<PlayerUI> Team { get; private set; }

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

        public MainViewModel(IPlayerLogic logic, Factory factory) // Dependency Injection
        {
            this.logic = logic;
            this.factory = factory;

            this.Team = new ObservableCollection<PlayerUI>();

            if (this.IsInDesignMode)
            {
                PlayerUI p1 = new PlayerUI() { Name = "Test Test", Birth = new DateTime(1984, 12, 20), Height = 206, Weight = 113, Number = 23, Post = "SF/PF", Salary = 37436858 };
                PlayerUI p2 = new PlayerUI() { Name = "Test2 Test2", Birth = new DateTime(1988, 09, 29), Height = 208, Weight = 109, Number = 35, Post = "SF/PF", Salary = 37199000 };
                this.Team.Add(p1);
                this.Team.Add(p2);
                SimpleIoc.Default.Register<IPlayerLogic>();
            }

            this.AddCmd = new RelayCommand(() => this.logic.AddPlayer(this.Team));
            this.ModCmd = new RelayCommand(() => this.logic.ModPlayer(this.TeamSelected));
            this.DelCmd = new RelayCommand(() => this.logic.DelPlayer(this.Team, this.TeamSelected));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// implements main view model.
        /// </summary>
        public MainViewModel()
            : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<IPlayerLogic>(), IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<Factory>())
        {
        }
    }
}
