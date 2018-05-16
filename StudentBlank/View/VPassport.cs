using StudentBlank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.View
{
    public class VPassport
    {
        public int Id { get; set; }
        public string Serial { get; set; }
        public int Number { get; set; }
        public string WhoGave { get; set; }
        public string WhenGave { get; set; }
        public static implicit operator VPassport(Epassport s)
        {
            return new VPassport
            {
                Id = s.Id,
                Number = s.Number,
                Serial = s.Serial,
                WhenGave = s.WhenGave,
                WhoGave = s.WhoGave 
            };
        }
    }
}
