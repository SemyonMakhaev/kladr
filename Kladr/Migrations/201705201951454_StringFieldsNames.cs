namespace Kladr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StringFieldsNames : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "Flat");
            DropColumn("dbo.AspNetUsers", "House");
            DropColumn("dbo.AspNetUsers", "Region");
            DropColumn("dbo.AspNetUsers", "Settlement");
            DropColumn("dbo.AspNetUsers", "Street");
            AddColumn("dbo.AspNetUsers", "Region", c => c.String());
            AddColumn("dbo.AspNetUsers", "Settlement", c => c.String());
            AddColumn("dbo.AspNetUsers", "Street", c => c.String());
            AddColumn("dbo.AspNetUsers", "House", c => c.String());
            AddColumn("dbo.AspNetUsers", "Flat", c => c.String());
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Street_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Settlement_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Region_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "House_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Flat_Id", c => c.Int());
            DropColumn("dbo.AspNetUsers", "Flat");
            DropColumn("dbo.AspNetUsers", "House");
            DropColumn("dbo.AspNetUsers", "Street");
            DropColumn("dbo.AspNetUsers", "Settlement");
            DropColumn("dbo.AspNetUsers", "Region");
            CreateIndex("dbo.AspNetUsers", "Street_Id");
            CreateIndex("dbo.AspNetUsers", "Settlement_Id");
            CreateIndex("dbo.AspNetUsers", "Region_Id");
            CreateIndex("dbo.AspNetUsers", "House_Id");
            CreateIndex("dbo.AspNetUsers", "Flat_Id");
            AddForeignKey("dbo.AspNetUsers", "Street_Id", "dbo.Streets", "Id");
            AddForeignKey("dbo.AspNetUsers", "Settlement_Id", "dbo.Settlements", "Id");
            AddForeignKey("dbo.AspNetUsers", "Region_Id", "dbo.Regions", "Id");
            AddForeignKey("dbo.AspNetUsers", "House_Id", "dbo.Houses", "Id");
            AddForeignKey("dbo.AspNetUsers", "Flat_Id", "dbo.Flats", "Id");
        }
    }
}
