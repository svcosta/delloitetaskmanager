namespace Delloite.TaskManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Task",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        OwnerId = c.Int(nullable: false),
                        UserUpdateId = c.Int(nullable: false),
                        Title = c.String(maxLength: 100, unicode: false),
                        Description = c.String(maxLength: 800, unicode: false),
                        Priority = c.String(maxLength: 30, unicode: false),
                        Status = c.String(maxLength: 30, unicode: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.User", t => t.OwnerId)
                .ForeignKey("dbo.User", t => t.UserUpdateId)
                .Index(t => t.OwnerId)
                .Index(t => t.UserUpdateId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 250, unicode: false),
                        UserName = c.String(maxLength: 250, unicode: false),
                        Role = c.String(maxLength: 50, unicode: false),
                        Password = c.String(maxLength: 50, unicode: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Task", "UserUpdateId", "dbo.User");
            DropForeignKey("dbo.Task", "OwnerId", "dbo.User");
            DropIndex("dbo.Task", new[] { "UserUpdateId" });
            DropIndex("dbo.Task", new[] { "OwnerId" });
            DropTable("dbo.User");
            DropTable("dbo.Task");
        }
    }
}
