﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.Entity
{
    [Table("tblEFacultet")]
    public class EFacultet
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<EStudent> Student { get; set; }

    }
}
