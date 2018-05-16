using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.Entity
{
    [Table("tblPassport")]
    public class Epassport
    {
        [Key]
        public int Id { get; set; }
        public string Serial { get; set; }
        public int Number { get; set; }
        public string WhoGave { get; set; }
        public string WhenGave { get; set; }
        public virtual IList<EStudent> Student { get; set; }

    }
}
