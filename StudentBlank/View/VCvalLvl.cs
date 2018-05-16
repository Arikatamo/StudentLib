using StudentBlank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.View
{
    public class VCvalLvl
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static implicit operator VCvalLvl(ECvalLvL s)
        {
            return new VCvalLvl
            {
                Id = s.Id,
                Name = s.Name
            };
        }
    }
}
