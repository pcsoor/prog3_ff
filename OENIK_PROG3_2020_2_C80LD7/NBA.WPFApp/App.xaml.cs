// <copyright file="App.xaml.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.WPFApp
{
    using System.Windows;
    using CommonServiceLocator;
    using GalaSoft.MvvmLight.Ioc;
    using GalaSoft.MvvmLight.Messaging;
    using Microsoft.EntityFrameworkCore;
    using NBA.Data.Model;
    using NBA.Logic;
    using NBA.Repository;
    using NBA.WPFApp.BL;
    using NBA.WPFApp.Data;
    using NBA.WPFApp.UI;
    using NBA.WPFApp.VM;

    /// <summary>
    /// Interaction logic for App.xaml.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            ServiceLocator.SetLocatorProvider(() => MyIoc.Instance);
            MyIoc.Instance.Register<IEditorService, EditorServiceViaWindow>();
            MyIoc.Instance.Register<IMessenger>(() => Messenger.Default);

            MyIoc.Instance.Register<DbContext>(() => new NBADbContext());
            MyIoc.Instance.Register<PlayerUI, PlayerUI>();
            MyIoc.Instance.Register<TeamUI, TeamUI>();

            MyIoc.Instance.Register<IPlayerRepository, PlayerRepository>();
            MyIoc.Instance.Register<IPlayerStatsRepository, PlayerStatsRepository>();
            MyIoc.Instance.Register<ITeamsRepository, TeamsRepository>();
            MyIoc.Instance.Register<ITeamsStatsRepository, TeamsStatsRepository>();
            MyIoc.Instance.Register<ISeriesRepository, SeriesRepository>();

            MyIoc.Instance.Register<IPlayerUiLogic, PlayerUiLogic>();
            MyIoc.Instance.Register<IPlayerLogic, PlayerLogic>();
            MyIoc.Instance.Register<ITeamLogic, TeamLogic>();
            MyIoc.Instance.Register<ITeamUiLogic, TeamUiLogic>();

            MyIoc.Instance.Register<Factory, Factory>();
        }
    }
}