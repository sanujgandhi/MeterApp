namespace MeterAppDal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Developer_Module");
            DropPrimaryKey("dbo.Developer_Skill");
            DropPrimaryKey("dbo.Screenshots");
            DropPrimaryKey("dbo.WorkLogs");
            AddColumn("dbo.Module", "DeveloperId", c => c.String());
            AddColumn("dbo.Module", "Name", c => c.String());
            AddColumn("dbo.Module", "Description", c => c.String());
            AlterColumn("dbo.Developer_Module", "DeveloperId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Developer_Skill", "DeveloperId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.FileUpload", "ClientId", c => c.String());
            AlterColumn("dbo.FileUpload", "DeveloperId", c => c.String());
            AlterColumn("dbo.Messages", "SenderId", c => c.String());
            AlterColumn("dbo.Messages", "RecieverId", c => c.String());
            AlterColumn("dbo.Project", "ClientId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Project", "ProjectName", c => c.String(nullable: false));
            AlterColumn("dbo.Screenshots", "DeveloperId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.WorkLogs", "DeveloperId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Developer_Module", new[] { "DeveloperId", "ModuleId" });
            AddPrimaryKey("dbo.Developer_Skill", new[] { "DeveloperId", "SkillId" });
            AddPrimaryKey("dbo.Screenshots", new[] { "DeveloperId", "ModuleId" });
            AddPrimaryKey("dbo.WorkLogs", new[] { "DeveloperId", "ModuleId" });
            CreateIndex("dbo.Project", "ClientId");
            CreateIndex("dbo.Project_Technology", "ProjectId");
            AddForeignKey("dbo.Project", "ClientId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Project_Technology", "ProjectId", "dbo.Project", "ProjectId", cascadeDelete: true);
            DropColumn("dbo.Module", "ModuleName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Module", "ModuleName", c => c.String());
            DropForeignKey("dbo.Project_Technology", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.Project", "ClientId", "dbo.AspNetUsers");
            DropIndex("dbo.Project_Technology", new[] { "ProjectId" });
            DropIndex("dbo.Project", new[] { "ClientId" });
            DropPrimaryKey("dbo.WorkLogs");
            DropPrimaryKey("dbo.Screenshots");
            DropPrimaryKey("dbo.Developer_Skill");
            DropPrimaryKey("dbo.Developer_Module");
            AlterColumn("dbo.WorkLogs", "DeveloperId", c => c.Int(nullable: false));
            AlterColumn("dbo.Screenshots", "DeveloperId", c => c.Int(nullable: false));
            AlterColumn("dbo.Project", "ProjectName", c => c.String());
            AlterColumn("dbo.Project", "ClientId", c => c.Int(nullable: false));
            AlterColumn("dbo.Messages", "RecieverId", c => c.Int(nullable: false));
            AlterColumn("dbo.Messages", "SenderId", c => c.Int(nullable: false));
            AlterColumn("dbo.FileUpload", "DeveloperId", c => c.Int(nullable: false));
            AlterColumn("dbo.FileUpload", "ClientId", c => c.Int(nullable: false));
            AlterColumn("dbo.Developer_Skill", "DeveloperId", c => c.Int(nullable: false));
            AlterColumn("dbo.Developer_Module", "DeveloperId", c => c.Int(nullable: false));
            DropColumn("dbo.Module", "Description");
            DropColumn("dbo.Module", "Name");
            DropColumn("dbo.Module", "DeveloperId");
            AddPrimaryKey("dbo.WorkLogs", new[] { "DeveloperId", "ModuleId" });
            AddPrimaryKey("dbo.Screenshots", new[] { "DeveloperId", "ModuleId" });
            AddPrimaryKey("dbo.Developer_Skill", new[] { "DeveloperId", "SkillId" });
            AddPrimaryKey("dbo.Developer_Module", new[] { "DeveloperId", "ModuleId" });
        }
    }
}
