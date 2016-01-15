namespace MeterAppDal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Developer_Module",
                c => new
                    {
                        DeveloperId = c.Int(nullable: false),
                        ModuleId = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                        DeletedBy = c.Int(nullable: false),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => new { t.DeveloperId, t.ModuleId });
            
            CreateTable(
                "dbo.Developer_Skill",
                c => new
                    {
                        DeveloperId = c.Int(nullable: false),
                        SkillId = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                        DeletedBy = c.Int(nullable: false),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => new { t.DeveloperId, t.SkillId });
            
            CreateTable(
                "dbo.FileUpload",
                c => new
                    {
                        FileUploadId = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        DeveloperId = c.Int(nullable: false),
                        ModuleId = c.Int(nullable: false),
                        FileName = c.String(),
                        FilePath = c.String(),
                        FileType = c.String(),
                        Description = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                        DeletedBy = c.Int(nullable: false),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.FileUploadId);
            
            CreateTable(
                "dbo.GlobalCode",
                c => new
                    {
                        GlobalCodeId = c.Int(nullable: false, identity: true),
                        GlobalCodeCategoryId = c.Int(nullable: false),
                        GlobalCodeName = c.String(),
                        Description = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                        DeletedBy = c.Int(nullable: false),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.GlobalCodeId);
            
            CreateTable(
                "dbo.GlobalCodeCategory",
                c => new
                    {
                        GlobalCodeCategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        Description = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                        DeletedBy = c.Int(nullable: false),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.GlobalCodeCategoryId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        SenderId = c.Int(nullable: false),
                        RecieverId = c.Int(nullable: false),
                        Message = c.String(),
                        TimeStamp = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                        DeletedBy = c.Int(nullable: false),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.MessageId);
            
            CreateTable(
                "dbo.Module",
                c => new
                    {
                        ModuleId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        TechnologyId = c.Int(nullable: false),
                        ModuleName = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                        DeletedBy = c.Int(nullable: false),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.ModuleId);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        ProjectName = c.String(),
                        Description = c.String(),
                        StartDate = c.DateTime(),
                        TargetDate = c.DateTime(),
                        ClosureDate = c.DateTime(),
                        ProjectLink = c.String(),
                        Status = c.Boolean(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                        DeletedBy = c.Int(nullable: false),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.ProjectId);
            
            CreateTable(
                "dbo.Project_Skill",
                c => new
                    {
                        ProjectId = c.Int(nullable: false),
                        SkillId = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                        DeletedBy = c.Int(nullable: false),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => new { t.ProjectId, t.SkillId });
            
            CreateTable(
                "dbo.Project_Technology",
                c => new
                    {
                        ProjectId = c.Int(nullable: false),
                        TechnologyId = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                        DeletedBy = c.Int(nullable: false),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => new { t.ProjectId, t.TechnologyId });
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Screenshots",
                c => new
                    {
                        DeveloperId = c.Int(nullable: false),
                        ModuleId = c.Int(nullable: false),
                        ScreenName = c.String(),
                        ScreenPath = c.String(),
                        Comments = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                        DeletedBy = c.Int(nullable: false),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => new { t.DeveloperId, t.ModuleId });
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Address = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Level = c.Byte(nullable: false),
                        JoinDate = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.WorkLogs",
                c => new
                    {
                        DeveloperId = c.Int(nullable: false),
                        ModuleId = c.Int(nullable: false),
                        TaskToDo = c.String(),
                        TaskDone = c.String(),
                        Reason = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                        DeletedBy = c.Int(nullable: false),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => new { t.DeveloperId, t.ModuleId });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.WorkLogs");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Screenshots");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Project_Technology");
            DropTable("dbo.Project_Skill");
            DropTable("dbo.Project");
            DropTable("dbo.Module");
            DropTable("dbo.Messages");
            DropTable("dbo.GlobalCodeCategory");
            DropTable("dbo.GlobalCode");
            DropTable("dbo.FileUpload");
            DropTable("dbo.Developer_Skill");
            DropTable("dbo.Developer_Module");
        }
    }
}
