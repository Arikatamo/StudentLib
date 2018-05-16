namespace StudentBlank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tblRatings", "Student_Id", "dbo.tblEStudent");
            DropForeignKey("dbo.tblRatings", "Rating_Id", "dbo.tbERating");
            DropForeignKey("dbo.tblRatings", "Subject_Id", "dbo.tblESubject");
            DropIndex("dbo.tblRatings", new[] { "Rating_Id" });
            DropIndex("dbo.tblRatings", new[] { "Student_Id" });
            DropIndex("dbo.tblRatings", new[] { "Subject_Id" });
            RenameColumn(table: "dbo.tblRatings", name: "Student_Id", newName: "StudentId");
            RenameColumn(table: "dbo.tblRatings", name: "Rating_Id", newName: "RatingId");
            RenameColumn(table: "dbo.tblRatings", name: "Subject_Id", newName: "SubjectId");
            AlterColumn("dbo.tblRatings", "RatingId", c => c.Int(nullable: false));
            AlterColumn("dbo.tblRatings", "StudentId", c => c.Int(nullable: false));
            AlterColumn("dbo.tblRatings", "SubjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.tblRatings", "RatingId");
            CreateIndex("dbo.tblRatings", "SubjectId");
            CreateIndex("dbo.tblRatings", "StudentId");
            AddForeignKey("dbo.tblRatings", "StudentId", "dbo.tblEStudent", "Id", cascadeDelete: true);
            AddForeignKey("dbo.tblRatings", "RatingId", "dbo.tbERating", "Id", cascadeDelete: true);
            AddForeignKey("dbo.tblRatings", "SubjectId", "dbo.tblESubject", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblRatings", "SubjectId", "dbo.tblESubject");
            DropForeignKey("dbo.tblRatings", "RatingId", "dbo.tbERating");
            DropForeignKey("dbo.tblRatings", "StudentId", "dbo.tblEStudent");
            DropIndex("dbo.tblRatings", new[] { "StudentId" });
            DropIndex("dbo.tblRatings", new[] { "SubjectId" });
            DropIndex("dbo.tblRatings", new[] { "RatingId" });
            AlterColumn("dbo.tblRatings", "SubjectId", c => c.Int());
            AlterColumn("dbo.tblRatings", "StudentId", c => c.Int());
            AlterColumn("dbo.tblRatings", "RatingId", c => c.Int());
            RenameColumn(table: "dbo.tblRatings", name: "SubjectId", newName: "Subject_Id");
            RenameColumn(table: "dbo.tblRatings", name: "RatingId", newName: "Rating_Id");
            RenameColumn(table: "dbo.tblRatings", name: "StudentId", newName: "Student_Id");
            CreateIndex("dbo.tblRatings", "Subject_Id");
            CreateIndex("dbo.tblRatings", "Student_Id");
            CreateIndex("dbo.tblRatings", "Rating_Id");
            AddForeignKey("dbo.tblRatings", "Subject_Id", "dbo.tblESubject", "Id");
            AddForeignKey("dbo.tblRatings", "Rating_Id", "dbo.tbERating", "Id");
            AddForeignKey("dbo.tblRatings", "Student_Id", "dbo.tblEStudent", "Id");
        }
    }
}
