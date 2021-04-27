// <copyright file="ErrorViewModel.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.Web.Models
{
    using System;

    /// <summary>
    /// Error view model.
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Gets or sets request ID.
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Gets a value indicating whether shows request id.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);
    }
}
