// <copyright file="MyIoc.xaml.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.WPFApp
{
    using System.Windows;
    using CommonServiceLocator;
    using GalaSoft.MvvmLight.Ioc;
    using GalaSoft.MvvmLight.Messaging;
    using Microsoft.EntityFrameworkCore;
    using NBA.Data.Model;
    using NBA.Logic;
    using NBA.Repository;
    using NBA.WPFApp.BL;
    using NBA.WPFApp.Data;
    using NBA.WPFApp.UI;
    using NBA.WPFApp.VM;

    /// <summary>
    /// Custom MyIoc container.
    /// </summary>
    public class MyIoc : SimpleIoc, IServiceLocator
    {
        /// <summary>
        /// Gets myIoc instance.
        /// </summary>
        public static MyIoc Instance { get; private set; } = new MyIoc();
    }
}
