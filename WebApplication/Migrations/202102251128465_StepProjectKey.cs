namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StepProjectKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Assignment", "ProjectID", "dbo.Project");
            DropForeignKey("dbo.ProjectEmployee", "Project_ProjectID", "dbo.Project");
            DropForeignKey("dbo.Step", "ProjectID", "dbo.Project");
            DropPrimaryKey("dbo.Project");
            AlterColumn("dbo.Project", "ProjectID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Project", "ProjectID");
            AddForeignKey("dbo.Assignment", "ProjectID", "dbo.Project", "ProjectID", cascadeDelete: true);
            AddForeignKey("dbo.ProjectEmployee", "Project_ProjectID", "dbo.Project", "ProjectID", cascadeDelete: true);
            AddForeignKey("dbo.Step", "ProjectID", "dbo.Project", "ProjectID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Step", "ProjectID", "dbo.Project");
            DropForeignKey("dbo.ProjectEmployee", "Project_ProjectID", "dbo.Project");
            DropForeignKey("dbo.Assignment", "ProjectID", "dbo.Project");
            DropPrimaryKey("dbo.Project");
            AlterColumn("dbo.Project", "ProjectID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Project", "ProjectID");
            AddForeignKey("dbo.Step", "ProjectID", "dbo.Project", "ProjectID", cascadeDelete: true);
            AddForeignKey("dbo.ProjectEmployee", "Project_ProjectID", "dbo.Project", "ProjectID", cascadeDelete: true);
            AddForeignKey("dbo.Assignment", "ProjectID", "dbo.Project", "ProjectID", cascadeDelete: true);
        }
    }
}
