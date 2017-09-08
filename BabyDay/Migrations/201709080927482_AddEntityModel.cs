namespace BabyDay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEntityModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Children", "ParentId", "dbo.Parents");
            DropPrimaryKey("dbo.Parents");
            DropPrimaryKey("dbo.Children");
            DropColumn("dbo.Parents", "ParentId");
            DropColumn("dbo.Children", "ChildId");
            AddColumn("dbo.Parents", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Children", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Parents", "Id");
            AddPrimaryKey("dbo.Children", "Id");
            AddForeignKey("dbo.Children", "ParentId", "dbo.Parents", "Id", cascadeDelete: true);            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Children", "ChildId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Parents", "ParentId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Children", "ParentId", "dbo.Parents");
            DropPrimaryKey("dbo.Children");
            DropPrimaryKey("dbo.Parents");
            DropColumn("dbo.Children", "Id");
            DropColumn("dbo.Parents", "Id");
            AddPrimaryKey("dbo.Children", "ChildId");
            AddPrimaryKey("dbo.Parents", "ParentId");
            AddForeignKey("dbo.Children", "ParentId", "dbo.Parents", "ParentId", cascadeDelete: true);
        }
    }
}
