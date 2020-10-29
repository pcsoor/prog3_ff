using Castle.Components.DictionaryAdapter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NBA.Data.Model
{
    [Table("Player")]
    class Player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayerID { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Post { get; set; }
        public int Salary { get; set; }
        public int Number { get; set; }
    }
}
