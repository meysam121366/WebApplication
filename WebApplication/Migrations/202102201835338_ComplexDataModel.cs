namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComplexDataModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employee", "Project_ProjectID", "dbo.Project");
            DropIndex("dbo.Employee", new[] { "Project_ProjectID" });
            CreateTable(
                "dbo.ProjectEmployee",
                c => new
                    {
                        Project_ProjectID = c.Int(nullable: false),
                        Employee_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Project_ProjectID, t.Employee_ID })
                .ForeignKey("dbo.Project", t => t.Project_ProjectID, cascadeDelete: true)
                .ForeignKey("dbo.Employee", t => t.Employee_ID, cascadeDelete: true)
                .Index(t => t.Project_ProjectID)
                .Index(t => t.Employee_ID);
            
            DropColumn("dbo.Employee", "Project_ProjectID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employee", "Project_ProjectID", c => c.Int());
            DropForeignKey("dbo.ProjectEmployee", "Employee_ID", "dbo.Employee");
            DropForeignKey("dbo.ProjectEmployee", "Project_ProjectID", "dbo.Project");
            DropIndex("dbo.ProjectEmployee", new[] { "Employee_ID" });
            DropIndex("dbo.ProjectEmployee", new[] { "Project_ProjectID" });
            DropTable("dbo.ProjectEmployee");
            CreateIndex("dbo.Employee", "Project_ProjectID");
            AddForeignKey("dbo.Employee", "Project_ProjectID", "dbo.Project", "ProjectID");
        }
    }
}
