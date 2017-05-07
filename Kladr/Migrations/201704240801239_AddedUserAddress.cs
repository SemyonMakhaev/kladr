namespace Kladr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserAddress : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Flats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        House_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Houses", t => t.House_Id)
                .Index(t => t.House_Id);
            
            CreateTable(
                "dbo.Houses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Street_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Streets", t => t.Street_Id)
                .Index(t => t.Street_Id);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Regions", t => t.Region_Id)
                .Index(t => t.Region_Id);
            
            CreateTable(
                "dbo.Streets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Settlement_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Settlements", t => t.Settlement_Id)
                .Index(t => t.Settlement_Id);
            
            AddColumn("dbo.AspNetUsers", "Flat_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "House_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Region_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Settlement_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Street_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Flat_Id");
            CreateIndex("dbo.AspNetUsers", "House_Id");
            CreateIndex("dbo.AspNetUsers", "Region_Id");
            CreateIndex("dbo.AspNetUsers", "Settlement_Id");
            CreateIndex("dbo.AspNetUsers", "Street_Id");
            AddForeignKey("dbo.AspNetUsers", "Flat_Id", "dbo.Flats", "Id");
            AddForeignKey("dbo.AspNetUsers", "House_Id", "dbo.Houses", "Id");
            AddForeignKey("dbo.AspNetUsers", "Region_Id", "dbo.Regions", "Id");
            AddForeignKey("dbo.AspNetUsers", "Settlement_Id", "dbo.Settlements", "Id");
            AddForeignKey("dbo.AspNetUsers", "Street_Id", "dbo.Streets", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Street_Id", "dbo.Streets");
            DropForeignKey("dbo.AspNetUsers", "Settlement_Id", "dbo.Settlements");
            DropForeignKey("dbo.AspNetUsers", "Region_Id", "dbo.Regions");
            DropForeignKey("dbo.Settlements", "Region_Id", "dbo.Regions");
            DropForeignKey("dbo.Streets", "Settlement_Id", "dbo.Settlements");
            DropForeignKey("dbo.Houses", "Street_Id", "dbo.Streets");
            DropForeignKey("dbo.AspNetUsers", "House_Id", "dbo.Houses");
            DropForeignKey("dbo.Flats", "House_Id", "dbo.Houses");
            DropForeignKey("dbo.AspNetUsers", "Flat_Id", "dbo.Flats");
            DropIndex("dbo.Streets", new[] { "Settlement_Id" });
            DropIndex("dbo.Settlements", new[] { "Region_Id" });
            DropIndex("dbo.Houses", new[] { "Street_Id" });
            DropIndex("dbo.Flats", new[] { "House_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Street_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Settlement_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Region_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "House_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Flat_Id" });
            DropColumn("dbo.AspNetUsers", "Street_Id");
            DropColumn("dbo.AspNetUsers", "Settlement_Id");
            DropColumn("dbo.AspNetUsers", "Region_Id");
            DropColumn("dbo.AspNetUsers", "House_Id");
            DropColumn("dbo.AspNetUsers", "Flat_Id");
            DropTable("dbo.Streets");
            DropTable("dbo.Settlements");
            DropTable("dbo.Regions");
            DropTable("dbo.Houses");
            DropTable("dbo.Flats");
        }
    }
}
