// <copyright file="EditorViewModelTeam.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.WPFApp.VM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using GalaSoft.MvvmLight;
    using NBA.Logic;
    using NBA.WPFApp.Data;

    /// <summary>
    /// Team editor view model.
    /// </summary>
    public class EditorViewModelTeam : ViewModelBase
    {
        private TeamUI teamui;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorViewModelTeam"/> class.
        /// </summary>
        public EditorViewModelTeam()
        {
            this.teamui = new TeamUI();

            if (this.IsInDesignMode)
            {
                this.teamui.TeamName = "Unknown Bill";
                this.teamui.Coach = "Test Coach";
                this.teamui.Region = "Pacific";
            }
        }

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
