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
        /// This method implements the factory class and call its methods.
        /// </summary>
        /// <param name="args">Array of string objects.</param>
        private static void Main(string[] args)
        {
            Factory f = new Factory();
            f.Kiir();
        }
    }
}