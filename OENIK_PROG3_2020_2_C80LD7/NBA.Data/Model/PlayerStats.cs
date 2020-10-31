using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NBA.Data.Model
{
    [Table("PlayerStats")]
    public class PlayerStats
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayerStatID { get; set; }

        [ForeignKey(nameof(Player))]
        public int PlayerID { get; set; }

        /// <summary>
        /// games played.
        /// </summary>
        [Required]
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
        public virtual Player Player { get; }
    }
}
