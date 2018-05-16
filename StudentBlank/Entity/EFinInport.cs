﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.Entity
{
    [Table("tblEFinInport")]
    public class EFinInport
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
