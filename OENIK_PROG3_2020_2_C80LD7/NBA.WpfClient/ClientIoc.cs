// <copyright file="ClientIoc.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.WpfClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CommonServiceLocator;
    using GalaSoft.MvvmLight.Ioc;

    /// <summary>
    /// IoC container.
    /// </summary>
    public class ClientIoc : SimpleIoc, IServiceLocator
    {
        /// <summary>
        /// Gets ClientIoc instance.
        /// </summary>
        public static ClientIoc Instance { get; private set; } = new ClientIoc();
    }
}
