// <copyright file="IEditorService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBA.WPFApp.BL
{
    using NBA.WPFApp.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Editor service interface.
    /// </summary>
    public interface IEditorService
    {
        bool EditPlayer(Player p);
    }
}
