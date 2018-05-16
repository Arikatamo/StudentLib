using StudentBlank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.View
{
    public class VFinImport
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static implicit operator VFinImport(EFinInport s)
        {
            return new VFinImport
            {
                Id = s.Id,
                Name = s.Name
            };
        }
    }
}
