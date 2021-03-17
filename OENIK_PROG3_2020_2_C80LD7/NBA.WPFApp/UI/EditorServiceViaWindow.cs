// <copyright file="EditorServiceViaWindow.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.WPFApp.UI
{
    using NBA.WPFApp.BL;
    using NBA.WPFApp.Data;

    /// <summary>
    /// Editor service via wndow.
    /// </summary>
    public class EditorServiceViaWindow : IEditorService
    {
        /// <summary>
        /// Returns player edit's result.
        /// </summary>
        /// <param name="p">Player ui entity.</param>
        /// <returns>true or false, depends on result.</returns>
        public bool EditPlayer(PlayerUI p)
        {
            EditorWindow win = new EditorWindow(p);
            return win.ShowDialog() ?? false;
        }

        /// <summary>
        /// Returns team edit's result.
        /// </summary>
        /// <param name="t">Team ui entity.</param>
        /// <returns>true or false, depends on result.</returns>
        public bool EditTeam(TeamUI t)
        {
            EditorWindowTeam winTeam = new EditorWindowTeam(t);
            return winTeam.ShowDialog() ?? false;
        }
    }
}
