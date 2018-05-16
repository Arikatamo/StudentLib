using StudentBlank.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Connection")
        {
             
        }
        public DbSet<EStudent> Student { get; set; }
        public DbSet<ECatZarah> CatZarah { get; set; }
        public DbSet<ESex> Sex { get; set; }
        public DbSet<ESubject> Subject { get; set; }
        public DbSet<EResidenc> Residence { get; set; }
        public DbSet<ERatings> Ratings { get; set; }
        public DbSet<ERating> Rating { get; set; }

        public DbSet<Epassport> Passport { get; set; }
        public DbSet<EFormEdu> FormEdu { get; set; }
        public DbSet<EFinInport> Finance { get; set; }
        public DbSet<EFacultet> Facultet { get; set; }
        public DbSet<ECvalLvL> CvalLvL { get; set; }
        public DbSet<EBlanks> Blanks { get; set; }

    }
}
