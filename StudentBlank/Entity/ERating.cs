using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.Entity
{
    [Table("tbERating")]
    public class ERating
    {
        [Key]
        public int Id { get; set; }
        public int Rating { get; set; }
        public IList<ERatings> Ratings { get; set; }

    }
}
