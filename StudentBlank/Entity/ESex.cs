using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.Entity
{
    [Table("tblSex")]
    public class ESex
    {
        [Key]
        public int Id { get; set; }
        public string Sex { get; set; }
        public virtual IList<EStudent> Student { get; set; }
    }
}
