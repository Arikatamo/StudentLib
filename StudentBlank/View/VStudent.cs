using StudentBlank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank.View
{
    public class VStudent
    {
        public VStudent(EStudent s)
        {
            Blanks = new List<VBlanks>();
            foreach (var item in s.Blanks)
            {
                Blanks.Add(item);
            }
            Ratings = new List<VRatings>();
            foreach (var item in s.Ratings)
            {
                Ratings.Add(item);
            }
            Residence = s.Residence;
            Id = s.Id;
            Age = s.Age;
            CatZarah = s.CatZarah;
            CvalLvl = s.CvalLvl;
            Facultet = s.Facultet;
            FinImport = s.FinImport;
            FName = s.FName;
            FormEdu = s.FormEdu;
            Image = s.Image;
            Name = s.Name;
            Pasport = s.Pasport;
            Sex = s.Sex.Sex;
            SName = s.SName;
            StudY = s.StudY;
            Phone = s.Phone;
            MobilePhone = s.MobilePhone;
            Email = s.Email;


        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string SName { get; set; }
        public string FName { get; set; }
        public int Age { get; set; }
        public byte[] Image { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public virtual List<VBlanks> Blanks { get; set; }
        public virtual List<VRatings> Ratings { get; set; }
        public virtual string Sex { get; set; }
        public virtual VResidence Residence { get; set; }
        
        public virtual VPassport Pasport { get; set; }
        public virtual VFormEdu FormEdu { get; set; }
        public virtual VFinImport FinImport { get; set; }
        public virtual VFacultet Facultet { get; set; }
        public virtual VCvalLvl CvalLvl { get; set; }
        public virtual VCatZarah CatZarah { get; set; }
        public bool StudY { get; set; }


    }
}
