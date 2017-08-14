namespace BabyDay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ParentChild : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parents",
                c => new
                    {
                        ParentId = c.Int(nullable: false, identity: true),
                        BirthDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UserProfileId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ParentId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserProfileId, cascadeDelete: true)
                .Index(t => t.UserProfileId);
            
            CreateTable(
                "dbo.Children",
                c => new
                    {
                        ChildId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BirthDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ParentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ChildId)
                .ForeignKey("dbo.Parents", t => t.ParentId, cascadeDelete: true)
                .Index(t => t.ParentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parents", "UserProfileId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Children", "ParentId", "dbo.Parents");
            DropIndex("dbo.Children", new[] { "ParentId" });
            DropIndex("dbo.Parents", new[] { "UserProfileId" });
            DropTable("dbo.Children");
            DropTable("dbo.Parents");
        }
    }
}
