using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace NBA.Data.Model
{
    [Table("Player")]
    public class Player
    {
        
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayerID { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public DateTime Birth { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        [MaxLength(10)]
        public string Post { get; set; }

        public int Salary { get; set; }

        public int Number { get; set; }

        [NotMapped]
        public virtual PlayerStats PlayerStats { get; set; }

        public override string ToString()
        {
            
            string context = string.Format
                (
                "{0,-4} {1,-20} {2,-15} {3,-8} {4,-8} {5,-8} {6,-12} {7:n0}",
                this.PlayerID ,this.Name, this.Birth.ToShortDateString(), this.Height, this.Weight, this.Post, this.Number, this.Salary
                );
            return context;
        }
    }
}
