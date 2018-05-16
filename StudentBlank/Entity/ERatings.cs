using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.Entity
{
    [Table("tblRatings")]
    public class ERatings
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Rating")]
        public int RatingId { get; set; }
        public virtual ERating Rating { get; set; }
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        public virtual ESubject Subject { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public virtual EStudent Student { get; set; }
    }
}
