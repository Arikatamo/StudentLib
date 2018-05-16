using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.Entity
{
    [Table("tblEResidenc")]
    public class EResidenc
    {
        [Key]
        public int Id { get; set; }
        public int Index { get; set; }
        [Required]
        public string Oblast { get; set; }
        [Required]
        public string Rajon { get; set; }
        [Required]
        public string Town { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public int NumberBuild { get; set; }
        public int NumberKW { get; set; }
        public virtual IList<EStudent> Student { get; set; }


    }
}
