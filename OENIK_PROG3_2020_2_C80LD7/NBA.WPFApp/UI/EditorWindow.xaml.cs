// <copyright file="EditorWindow.xaml.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.WPFApp.UI
{
    using System.Windows;
    using NBA.WPFApp.Data;
    using NBA.WPFApp.VM;

    /// <summary>
    /// Interaction logic for EditorWindow.xaml.
    /// </summary>
    public partial class EditorWindow : Window
    {
        private readonly EditorViewModel VM;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorWindow"/> class.
        /// </summary>
        public EditorWindow()
        {
            this.InitializeComponent();

            this.VM = this.FindResource("VM") as EditorViewModel;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorWindow"/> class.
        /// </summary>
        /// <param name="oldPlayer">Player ui entity.</param>
        public EditorWindow(PlayerUI oldPlayer)
            : this()
        {
            this.VM.PlayerUi = oldPlayer;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorWindow"/> class.
        /// </summary>
        /// <param name="oldTeam">Player ui entity.</param>
        public EditorWindow(TeamUI oldTeam)
            : this()
        {
            this.VM.TeamUi = oldTeam;
        }

        /// <summary>
        /// Gets player ui ref.
        /// </summary>
        public PlayerUI PlayerUI { get => this.VM.PlayerUi; }

        /// <summary>
        /// Gets team ui ref.
        /// </summary>
        public TeamUI TeamUI { get => this.VM.TeamUi; }

        private void OkClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
