using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NBA.Data.Model
{
    [Table("TeamStats")]
    public class TeamStats
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamStatID { get; set; }

        [ForeignKey(nameof(Teams))]
        public int TeamID { get; set; }

        /// <summary>
        /// games played.
        /// </summary>
        public double GP { get; set; }

        /// <summary>
        /// points per game.
        /// </summary>
        public double PPG { get; set; }

        /// <summary>
        /// field goals made.
        /// </summary>
        public double FGM { get; set; }

        /// <summary>
        /// assist.
        /// </summary>
        public double AST { get; set; }

        /// <summary>
        /// rebound.
        /// </summary>
        public double REB { get; set; }

        /// <summary>
        /// block.
        /// </summary>
        public double BLK { get; set; }

        /// <summary>
        /// steal.
        /// </summary>
        public double STL { get; set; }

        [NotMapped]
        public virtual Teams Teams { get; set; }

        public override string ToString()
        {
            string context = string.Format("{0,-6} {1,-6} {2,-6} {3,-6} {4,-6} {5,-6} {6,-6} {7,-6}",
                this.TeamStatID, this.GP, this.PPG, this.REB, this.STL, this.AST, this.BLK, this.FGM);
            return context;
        }
    }
}
