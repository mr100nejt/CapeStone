namespace CapStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PharmacyDbs",
                c => new
                    {
                        PharmacyId = c.Int(nullable: false, identity: true),
                        DateEntered = c.String(),
                        ApplicationId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PharmacyId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationId)
                .Index(t => t.ApplicationId);
            
            AddColumn("dbo.Pharmacies", "PharmacyDb_PharmacyId", c => c.Int());
            CreateIndex("dbo.Pharmacies", "PharmacyDb_PharmacyId");
            AddForeignKey("dbo.Pharmacies", "PharmacyDb_PharmacyId", "dbo.PharmacyDbs", "PharmacyId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pharmacies", "PharmacyDb_PharmacyId", "dbo.PharmacyDbs");
            DropForeignKey("dbo.PharmacyDbs", "ApplicationId", "dbo.AspNetUsers");
            DropIndex("dbo.PharmacyDbs", new[] { "ApplicationId" });
            DropIndex("dbo.Pharmacies", new[] { "PharmacyDb_PharmacyId" });
            DropColumn("dbo.Pharmacies", "PharmacyDb_PharmacyId");
            DropTable("dbo.PharmacyDbs");
        }
    }
}
