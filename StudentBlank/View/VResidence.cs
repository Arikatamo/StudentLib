using StudentBlank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.View
{
    public class VResidence
    {
        public int Id { get; set; }
        public int Index { get; set; }
        public string Oblast { get; set; }
        public string Rajon { get; set; }
        public string Town { get; set; }
        public string Street { get; set; }
        public int NumberBuild { get; set; }
        public int NumberKW { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public static implicit operator VResidence(EResidenc s)
        {
            return new VResidence
            {
                Id = s.Id,
                
                Index = s.Index,
                
                NumberBuild =s.NumberBuild,
                NumberKW = s.NumberKW,
                Oblast =s.Oblast,
              
                Rajon = s.Rajon,
                Street =s.Street,
                Town =s.Town
                
            };
        }
    }
}
