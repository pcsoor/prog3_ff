using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NBA.Data.Model
{
    [Table("Series")]
    class Series
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Year { get; set; }
        public int WinnerID { get; set; }

        public int LoserID { get; set; }

        public string Result { get; set; }
    }
}
