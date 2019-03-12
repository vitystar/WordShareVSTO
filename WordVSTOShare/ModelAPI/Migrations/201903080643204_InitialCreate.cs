namespace ModelAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrganizationInfo",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        OrganizationName = c.String(nullable: false, maxLength: 32),
                        Password = c.String(nullable: false, maxLength: 32),
                        DefaultUserAuth = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserInfo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 32),
                        UserPwd = c.String(nullable: false, maxLength: 32),
                        PhoneNumber = c.String(maxLength: 32),
                        UserAuth = c.Int(nullable: false),
                        Organization_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OrganizationInfo", t => t.Organization_ID)
                .Index(t => t.Organization_ID);
            
            CreateTable(
                "dbo.WordTemplet",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TempletName = c.String(nullable: false, maxLength: 32),
                        TempletIntroduction = c.String(maxLength: 255),
                        Accessibility = c.Int(nullable: false),
                        FilePath = c.String(nullable: false, maxLength: 255),
                        ImagePath = c.String(nullable: false, maxLength: 255),
                        ModTime = c.DateTime(nullable: false),
                        Organization_ID = c.Guid(),
                        User_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OrganizationInfo", t => t.Organization_ID)
                .ForeignKey("dbo.UserInfo", t => t.User_ID, cascadeDelete: true)
                .Index(t => t.Organization_ID)
                .Index(t => t.User_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WordTemplet", "User_ID", "dbo.UserInfo");
            DropForeignKey("dbo.WordTemplet", "Organization_ID", "dbo.OrganizationInfo");
            DropForeignKey("dbo.UserInfo", "Organization_ID", "dbo.OrganizationInfo");
            DropIndex("dbo.WordTemplet", new[] { "User_ID" });
            DropIndex("dbo.WordTemplet", new[] { "Organization_ID" });
            DropIndex("dbo.UserInfo", new[] { "Organization_ID" });
            DropTable("dbo.WordTemplet");
            DropTable("dbo.UserInfo");
            DropTable("dbo.OrganizationInfo");
        }
    }
}
