using StudentBlank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.View
{
    public class VFormEdu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static implicit operator VFormEdu(EFormEdu s)
        {
            return new VFormEdu
            {
                Id = s.Id,
                Name = s.Name
            };
        }
    }
}
