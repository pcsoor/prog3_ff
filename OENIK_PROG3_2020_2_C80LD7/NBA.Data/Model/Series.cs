using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NBA.Data.Model
{
    [Table("Series")]
    public class Series
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Year { get; set; }

        [ForeignKey(nameof(Teams))]
        public int WinnerID { get; set; }

        [ForeignKey(nameof(Teams))]
        public int LoserID { get; set; }

        public string Result { get; set; }

        [NotMapped]
        public virtual Teams Teams { get; set; }
    }
}
