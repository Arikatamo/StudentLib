using StudentBlank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.View
{
    public class VSex
    {
        public int Id { get; set; }
        public string Sex { get; set; }
        public static implicit operator VSex(ESex s)
        {
            return new VSex
            {
                Id = s.Id,
                Sex = s.Sex
            };
        }
    }
}
