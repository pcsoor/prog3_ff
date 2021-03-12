// <copyright file="MainWindow.xaml.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>
namespace NBA.WPFApp
{
    using System.Windows;
    using GalaSoft.MvvmLight.Messaging;
    using NBA.WPFApp.VM;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel VM;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            VM = FindResource("VM") as MainViewModel;

            Messenger.Default.Register<string>(this, "LogicResult", msg =>
            {
                MessageBox.Show(msg);
            });
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Messenger.Default.Unregister(this);
        }
    }
}
