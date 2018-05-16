namespace StudentBlank.Migrations
{
    using StudentBlank.Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentBlank.EFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StudentBlank.EFContext context)
        {
            for (int i = 1; i <= 12; i++)
            {
                context.Rating.AddOrUpdate(new ERating {Id = i, Rating = i });
            }
            context.Sex.AddOrUpdate(
                new ESex { Id = 1, Sex = "Чоловік" },
                new ESex { Id = 2, Sex = "Жінка" });
            context.Subject.AddOrUpdate(
                new ESubject {Id = 1, Name = "Математика" },
                new ESubject { Id = 2, Name = "Фізика" });
            context.CatZarah.AddOrUpdate(
                new ECatZarah { Id = 1, Name = "Державна" },
                new ECatZarah { Id = 2, Name = "Приватна" });
            context.CvalLvL.AddOrUpdate(
                new ECvalLvL { Id = 1, Name = "Досвідчений" },
                new ECvalLvL { Id = 2, Name = "Без досвіду" });
            context.Facultet.AddOrUpdate(
                new EFacultet { Id = 1, Name = "Економічний факультет" },
                new EFacultet { Id = 2, Name = "Факультет іноземних мов"},
                new EFacultet { Id = 2, Name = "Географічний факультет" });
            context.FormEdu.AddOrUpdate(
                new EFormEdu { Id = 1, Name = "Державна" },
                new EFormEdu { Id = 2, Name = "Приватна" });
            context.Finance.AddOrUpdate(
                new EFinInport { Id = 1, Name = "Державна" },
                new EFinInport { Id = 2, Name = "Приватна" });

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
