using StudentBlank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.View
{
    public class VBlanks
    {
        public int Id { get; set; }
        public string File { get; set; }
        public static implicit operator VBlanks(EBlanks s)
        {
            return new VBlanks
            {
                Id = s.Id,
                File = s.Url                
            };
        }
    }
}
