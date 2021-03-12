// <copyright file="App.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
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

    class MyIoc : SimpleIoc, IServiceLocator
    {
        /// <summary>
        /// Gets simpleIoc default instance.
        /// </summary>
        public static MyIoc Instance { get; private set; } = new MyIoc();
    }

    /// <summary>
    /// Interaction logic for App.xaml.
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ServiceLocator.SetLocatorProvider(() => MyIoc.Instance);
            MyIoc.Instance.Register<IEditorService, EditorServiceViaWindow>();
            MyIoc.Instance.Register<IMessenger>(() => Messenger.Default);

            MyIoc.Instance.Register<DbContext>(() => new NBADbContext());
            MyIoc.Instance.Register<PlayerUI, PlayerUI>();

            MyIoc.Instance.Register<IPlayerRepository, PlayerRepository>();
            MyIoc.Instance.Register<IPlayerStatsRepository, PlayerStatsRepository>();
            MyIoc.Instance.Register<ITeamsRepository, TeamsRepository>();

            MyIoc.Instance.Register<IPlayerUiLogic, PlayerUiLogic>();
            MyIoc.Instance.Register<IPlayerLogic, PlayerLogic>();

            MyIoc.Instance.Register<Factory, Factory>();
        }
    }
}
