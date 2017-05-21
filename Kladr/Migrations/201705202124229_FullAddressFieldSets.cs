namespace Kladr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FullAddressFieldSets : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Regions", "Index", c => c.String());
            AddColumn("dbo.Settlements", "Index", c => c.String());
            AddColumn("dbo.Streets", "RegionName", c => c.String());
            AddColumn("dbo.Streets", "Index", c => c.String());
            AddColumn("dbo.Houses", "SettlementName", c => c.String());
            AddColumn("dbo.Houses", "RegionName", c => c.String());
            AddColumn("dbo.Houses", "Index", c => c.String());
            AddColumn("dbo.Flats", "StreetName", c => c.String());
            AddColumn("dbo.Flats", "SettlementName", c => c.String());
            AddColumn("dbo.Flats", "RegionName", c => c.String());
            AddColumn("dbo.Flats", "Index", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Regions", "Index");
            DropColumn("dbo.Settlements", "Index");
            DropColumn("dbo.Streets", "RegionName");
            DropColumn("dbo.Streets", "Index");
            DropColumn("dbo.Houses", "SettlementName");
            DropColumn("dbo.Houses", "RegionName");
            DropColumn("dbo.Houses", "Index");
            DropColumn("dbo.Flats", "StreetName");
            DropColumn("dbo.Flats", "SettlementName");
            DropColumn("dbo.Flats", "RegionName");
            DropColumn("dbo.Flats", "Index");
        }
    }
}
