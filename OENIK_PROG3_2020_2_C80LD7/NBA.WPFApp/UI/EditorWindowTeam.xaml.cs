// <copyright file="EditorWindowTeam.xaml.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.WPFApp.UI
{
    using System.Windows;
    using NBA.WPFApp.Data;
    using NBA.WPFApp.VM;

    /// <summary>
    /// Interaction logic for EditorWindowTeam.xaml.
    /// </summary>
    public partial class EditorWindowTeam : Window
    {
        private readonly EditorViewModelTeam VM;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorWindowTeam"/> class.
        /// </summary>
        public EditorWindowTeam()
        {
            this.InitializeComponent();

            this.VM = this.FindResource("VM") as EditorViewModelTeam;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorWindowTeam"/> class.
        /// </summary>
        /// <param name="oldTeam">Player ui entity.</param>
        public EditorWindowTeam(TeamUI oldTeam)
            : this()
        {
            this.VM.TeamUi = oldTeam;
        }

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
