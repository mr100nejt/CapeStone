namespace CapStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intia : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pharmacies", "DateAdded", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pharmacies", "DateAdded");
        }
    }
}
