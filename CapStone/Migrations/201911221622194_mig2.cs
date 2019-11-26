namespace CapStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pharmacies", "MemberId", c => c.Double());
            DropColumn("dbo.Pharmacies", "MemberIdNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pharmacies", "MemberIdNumber", c => c.Double());
            DropColumn("dbo.Pharmacies", "MemberId");
        }
    }
}
