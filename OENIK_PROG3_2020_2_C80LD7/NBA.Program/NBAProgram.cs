// <copyright file="NBAProgram.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

[assembly: System.CLSCompliant(false)]

namespace NBA.Program
{
    /// <summary>
    /// Top layer of the project.
    /// </summary>
    public class NBAProgram
    {
        /// <summary>
        /// This method implements the factory class and calls its methods.
        /// </summary>
        private static void Main()
        {
            Factory f = new Factory();
            f.Kiir();
        }
    }
}