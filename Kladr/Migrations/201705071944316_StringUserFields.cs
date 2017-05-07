namespace Kladr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StringUserFields : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Flat_Id", "dbo.Flats");
            DropForeignKey("dbo.Flats", "House_Id", "dbo.Houses");
            DropForeignKey("dbo.AspNetUsers", "House_Id", "dbo.Houses");
            DropForeignKey("dbo.Houses", "Street_Id", "dbo.Streets");
            DropForeignKey("dbo.Streets", "Settlement_Id", "dbo.Settlements");
            DropForeignKey("dbo.Settlements", "Region_Id", "dbo.Regions");
            DropForeignKey("dbo.AspNetUsers", "Region_Id", "dbo.Regions");
            DropForeignKey("dbo.AspNetUsers", "Settlement_Id", "dbo.Settlements");
            DropForeignKey("dbo.AspNetUsers", "Street_Id", "dbo.Streets");
            DropIndex("dbo.AspNetUsers", new[] { "Flat_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "House_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Region_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Settlement_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Street_Id" });
            DropIndex("dbo.Flats", new[] { "House_Id" });
            DropIndex("dbo.Houses", new[] { "Street_Id" });
            DropIndex("dbo.Settlements", new[] { "Region_Id" });
            DropIndex("dbo.Streets", new[] { "Settlement_Id" });
            AddColumn("dbo.AspNetUsers", "Region", c => c.String());
            AddColumn("dbo.AspNetUsers", "Settlement", c => c.String());
            AddColumn("dbo.AspNetUsers", "Street", c => c.String());
            AddColumn("dbo.AspNetUsers", "House", c => c.String());
            AddColumn("dbo.AspNetUsers", "Flat", c => c.String());
            DropColumn("dbo.AspNetUsers", "Flat_Id");
            DropColumn("dbo.AspNetUsers", "House_Id");
            DropColumn("dbo.AspNetUsers", "Region_Id");
            DropColumn("dbo.AspNetUsers", "Settlement_Id");
            DropColumn("dbo.AspNetUsers", "Street_Id");
            DropTable("dbo.Flats");
            DropTable("dbo.Houses");
            DropTable("dbo.Regions");
            DropTable("dbo.Settlements");
            DropTable("dbo.Streets");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Streets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Settlement_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Settlements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Region_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Houses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Street_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Flats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        House_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
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
            CreateIndex("dbo.Streets", "Settlement_Id");
            CreateIndex("dbo.Settlements", "Region_Id");
            CreateIndex("dbo.Houses", "Street_Id");
            CreateIndex("dbo.Flats", "House_Id");
            CreateIndex("dbo.AspNetUsers", "Street_Id");
            CreateIndex("dbo.AspNetUsers", "Settlement_Id");
            CreateIndex("dbo.AspNetUsers", "Region_Id");
            CreateIndex("dbo.AspNetUsers", "House_Id");
            CreateIndex("dbo.AspNetUsers", "Flat_Id");
            AddForeignKey("dbo.AspNetUsers", "Street_Id", "dbo.Streets", "Id");
            AddForeignKey("dbo.AspNetUsers", "Settlement_Id", "dbo.Settlements", "Id");
            AddForeignKey("dbo.AspNetUsers", "Region_Id", "dbo.Regions", "Id");
            AddForeignKey("dbo.Settlements", "Region_Id", "dbo.Regions", "Id");
            AddForeignKey("dbo.Streets", "Settlement_Id", "dbo.Settlements", "Id");
            AddForeignKey("dbo.Houses", "Street_Id", "dbo.Streets", "Id");
            AddForeignKey("dbo.AspNetUsers", "House_Id", "dbo.Houses", "Id");
            AddForeignKey("dbo.Flats", "House_Id", "dbo.Houses", "Id");
            AddForeignKey("dbo.AspNetUsers", "Flat_Id", "dbo.Flats", "Id");
        }
    }
}
