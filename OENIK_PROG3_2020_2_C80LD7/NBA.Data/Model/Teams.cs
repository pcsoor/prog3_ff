using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace NBA.Data.Model
{
    [Table("Teams")]
    public class Teams
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Coach { get; set; }

        [Required]
        [MaxLength(20)]
        public string Region { get; set; }

        [NotMapped]
        public virtual TeamStats TeamStats { get; set; }

        [NotMapped]
        public virtual ICollection<Series> Series { get; set; }

        public Teams()
        {
            Series = new HashSet<Series>();
        }

        public override string ToString()
        {
            
            string tartalom = string.Format("{0,-4} {1,-25} {2,-20} {3,-1}", this.TeamID, this.Name, this.Coach, this.Region);
            return tartalom;
        }
    }
}
