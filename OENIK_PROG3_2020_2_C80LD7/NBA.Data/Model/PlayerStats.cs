using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NBA.Data.Model
{
    [Table("PlayerStats")]
    class PlayerStats
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayerStatID { get; set; }

        public int PlayerID { get; set; }

        /// <summary>
        /// games played.
        /// </summary>
        public int GP { get; set; }

        /// <summary>
        /// points per game.
        /// </summary>
        public int PPG { get; set; }

        /// <summary>
        /// field goals made.
        /// </summary>
        public int FGM { get; set; }

        /// <summary>
        /// assist.
        /// </summary>
        public int AST { get; set; }

        /// <summary>
        /// rebound.
        /// </summary>
        public int REB { get; set; }

        /// <summary>
        /// block.
        /// </summary>
        public int BLK { get; set; }

        /// <summary>
        /// steal.
        /// </summary>
        public int STL { get; set; }
    }
}
