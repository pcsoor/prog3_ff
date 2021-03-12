// <copyright file="App.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBA.WPFApp
{
    using System.Windows;
    using CommonServiceLocator;
    using GalaSoft.MvvmLight.Ioc;
    using GalaSoft.MvvmLight.Messaging;
    using NBA.WPFApp.BL;
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
            MyIoc.Instance.Register<IPlayerLogic, PlayerLogic>();
            MyIoc.Instance.Register<Factory, Factory>();
        }
    }
}
