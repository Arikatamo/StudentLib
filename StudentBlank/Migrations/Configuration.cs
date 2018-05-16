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
                new ESex { Id = 1, Sex = "������" },
                new ESex { Id = 2, Sex = "Ƴ���" });
            context.Subject.AddOrUpdate(
                new ESubject {Id = 1, Name = "����������" },
                new ESubject { Id = 2, Name = "Գ����" });
            context.CatZarah.AddOrUpdate(
                new ECatZarah { Id = 1, Name = "��������" },
                new ECatZarah { Id = 2, Name = "��������" });
            context.CvalLvL.AddOrUpdate(
                new ECvalLvL { Id = 1, Name = "����������" },
                new ECvalLvL { Id = 2, Name = "��� ������" });
            context.Facultet.AddOrUpdate(
                new EFacultet { Id = 1, Name = "���������� ���������" },
                new EFacultet { Id = 2, Name = "��������� ��������� ���"},
                new EFacultet { Id = 2, Name = "������������ ���������" });
            context.FormEdu.AddOrUpdate(
                new EFormEdu { Id = 1, Name = "��������" },
                new EFormEdu { Id = 2, Name = "��������" });
            context.Finance.AddOrUpdate(
                new EFinInport { Id = 1, Name = "��������" },
                new EFinInport { Id = 2, Name = "��������" });

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
