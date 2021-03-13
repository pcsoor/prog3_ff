// <copyright file="IEditorService.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.WPFApp.BL
{
    using NBA.WPFApp.Data;

    /// <summary>
    /// Editor service interface.
    /// </summary>
    public interface IEditorService
    {
        /// <summary>
        /// Returns edit player result.
        /// </summary>
        /// <param name="p">Player entity ref.</param>
        /// <returns>true or false.</returns>
        bool EditPlayer(PlayerUI p);
    }
}
