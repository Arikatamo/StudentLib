namespace StudentBlank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblBlanks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblEStudent", t => t.Student_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.tblEStudent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SName = c.String(),
                        FName = c.String(),
                        Age = c.Int(nullable: false),
                        Image = c.Binary(),
                        Phone = c.String(),
                        MobilePhone = c.String(),
                        Email = c.String(),
                        SexId = c.Int(nullable: false),
                        ResidenceId = c.Int(nullable: false),
                        PasportId = c.Int(nullable: false),
                        FormEduId = c.Int(nullable: false),
                        FinImportId = c.Int(nullable: false),
                        FacultetId = c.Int(nullable: false),
                        CvalLvlId = c.Int(nullable: false),
                        CatZarahId = c.Int(nullable: false),
                        StudY = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblECatZarah", t => t.CatZarahId, cascadeDelete: true)
                .ForeignKey("dbo.tblCvalLvL", t => t.CvalLvlId, cascadeDelete: true)
                .ForeignKey("dbo.tblEFacultet", t => t.FacultetId, cascadeDelete: true)
                .ForeignKey("dbo.tblEFinInport", t => t.FinImportId, cascadeDelete: true)
                .ForeignKey("dbo.tblEFormEdu", t => t.FormEduId, cascadeDelete: true)
                .ForeignKey("dbo.tblPassport", t => t.PasportId, cascadeDelete: true)
                .ForeignKey("dbo.tblEResidenc", t => t.ResidenceId, cascadeDelete: true)
                .ForeignKey("dbo.tblSex", t => t.SexId, cascadeDelete: true)
                .Index(t => t.SexId)
                .Index(t => t.ResidenceId)
                .Index(t => t.PasportId)
                .Index(t => t.FormEduId)
                .Index(t => t.FinImportId)
                .Index(t => t.FacultetId)
                .Index(t => t.CvalLvlId)
                .Index(t => t.CatZarahId);
            
            CreateTable(
                "dbo.tblECatZarah",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblCvalLvL",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblEFacultet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblEFinInport",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblEFormEdu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblPassport",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Serial = c.String(),
                        Number = c.Int(nullable: false),
                        WhoGave = c.String(),
                        WhenGave = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblRatings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating_Id = c.Int(),
                        Student_Id = c.Int(),
                        Subject_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tbERating", t => t.Rating_Id)
                .ForeignKey("dbo.tblEStudent", t => t.Student_Id)
                .ForeignKey("dbo.tblESubject", t => t.Subject_Id)
                .Index(t => t.Rating_Id)
                .Index(t => t.Student_Id)
                .Index(t => t.Subject_Id);
            
            CreateTable(
                "dbo.tbERating",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblESubject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblEResidenc",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Index = c.Int(nullable: false),
                        Oblast = c.String(nullable: false),
                        Rajon = c.String(nullable: false),
                        Town = c.String(nullable: false),
                        Street = c.String(nullable: false),
                        NumberBuild = c.Int(nullable: false),
                        NumberKW = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblSex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sex = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblEStudent", "SexId", "dbo.tblSex");
            DropForeignKey("dbo.tblEStudent", "ResidenceId", "dbo.tblEResidenc");
            DropForeignKey("dbo.tblRatings", "Subject_Id", "dbo.tblESubject");
            DropForeignKey("dbo.tblRatings", "Student_Id", "dbo.tblEStudent");
            DropForeignKey("dbo.tblRatings", "Rating_Id", "dbo.tbERating");
            DropForeignKey("dbo.tblEStudent", "PasportId", "dbo.tblPassport");
            DropForeignKey("dbo.tblEStudent", "FormEduId", "dbo.tblEFormEdu");
            DropForeignKey("dbo.tblEStudent", "FinImportId", "dbo.tblEFinInport");
            DropForeignKey("dbo.tblEStudent", "FacultetId", "dbo.tblEFacultet");
            DropForeignKey("dbo.tblEStudent", "CvalLvlId", "dbo.tblCvalLvL");
            DropForeignKey("dbo.tblEStudent", "CatZarahId", "dbo.tblECatZarah");
            DropForeignKey("dbo.tblBlanks", "Student_Id", "dbo.tblEStudent");
            DropIndex("dbo.tblRatings", new[] { "Subject_Id" });
            DropIndex("dbo.tblRatings", new[] { "Student_Id" });
            DropIndex("dbo.tblRatings", new[] { "Rating_Id" });
            DropIndex("dbo.tblEStudent", new[] { "CatZarahId" });
            DropIndex("dbo.tblEStudent", new[] { "CvalLvlId" });
            DropIndex("dbo.tblEStudent", new[] { "FacultetId" });
            DropIndex("dbo.tblEStudent", new[] { "FinImportId" });
            DropIndex("dbo.tblEStudent", new[] { "FormEduId" });
            DropIndex("dbo.tblEStudent", new[] { "PasportId" });
            DropIndex("dbo.tblEStudent", new[] { "ResidenceId" });
            DropIndex("dbo.tblEStudent", new[] { "SexId" });
            DropIndex("dbo.tblBlanks", new[] { "Student_Id" });
            DropTable("dbo.tblSex");
            DropTable("dbo.tblEResidenc");
            DropTable("dbo.tblESubject");
            DropTable("dbo.tbERating");
            DropTable("dbo.tblRatings");
            DropTable("dbo.tblPassport");
            DropTable("dbo.tblEFormEdu");
            DropTable("dbo.tblEFinInport");
            DropTable("dbo.tblEFacultet");
            DropTable("dbo.tblCvalLvL");
            DropTable("dbo.tblECatZarah");
            DropTable("dbo.tblEStudent");
            DropTable("dbo.tblBlanks");
        }
    }
}
