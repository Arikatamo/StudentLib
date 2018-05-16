using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentBlank.View;

namespace StudentBlank.Entity
{
    [Table("tblEStudent")]
    public class EStudent
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string SName { get; set; }
        public string FName { get; set; }
        public int Age { get; set; }
        public byte[] Image { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public virtual IList<EBlanks> Blanks { get; set; }
        public virtual IList<ERatings> Ratings { get; set; }
        [ForeignKey("Sex")]
        public int SexId { get; set; }
        public virtual ESex Sex { get; set; }
        [ForeignKey("Residence")]
        public int ResidenceId { get; set; }
        public virtual EResidenc Residence { get; set; }
        [ForeignKey("Pasport")]
        public int PasportId { get; set; }
        public virtual Epassport Pasport { get; set; }
        [ForeignKey("FormEdu")]
        public int FormEduId { get; set; }
        public virtual EFormEdu FormEdu { get; set; }
        [ForeignKey("FinImport")]
        public int FinImportId { get; set; }
        public virtual EFinInport FinImport{ get; set; }
        [ForeignKey("Facultet")]
        public int FacultetId { get; set; }
        public virtual EFacultet Facultet { get; set; }
        [ForeignKey("CvalLvl")]
        public int CvalLvlId { get; set; }
        public virtual ECvalLvL CvalLvl { get; set; }
        [ForeignKey("CatZarah")]
        public int CatZarahId { get; set; }
        public virtual ECatZarah CatZarah { get; set; }
        public bool StudY { get; set; }


    }
}
