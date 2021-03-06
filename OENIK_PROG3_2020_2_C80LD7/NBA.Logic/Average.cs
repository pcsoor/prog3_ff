// <copyright file="Average.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This class necessary for calculating average values given by logic.
    /// </summary>
    public class Average
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the average result.
        /// </summary>
        public double Avg { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{this.Name} - {this.Avg}";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is Average)
            {
                Average other = obj as Average;
                return this.Avg == other.Avg && this.Name == other.Name;
            }

            return false;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return 0;
        }
    }
}
