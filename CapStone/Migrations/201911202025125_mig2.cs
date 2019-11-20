namespace CapStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pharmacies", "DateofBirth", c => c.Int());
            AlterColumn("dbo.Pharmacies", "FillDate", c => c.Int());
            AlterColumn("dbo.Pharmacies", "OriginalClaimNumber", c => c.Int());
            AlterColumn("dbo.Pharmacies", "PerscriptionNumber", c => c.Int());
            AlterColumn("dbo.Pharmacies", "NDCCode", c => c.Int());
            AlterColumn("dbo.Pharmacies", "Multisource", c => c.Int());
            AlterColumn("dbo.Pharmacies", "DEASchedule", c => c.Int());
            AlterColumn("dbo.Pharmacies", "DWAIndecator", c => c.Int());
            AlterColumn("dbo.Pharmacies", "DaysSupply", c => c.Int());
            AlterColumn("dbo.Pharmacies", "BilledAmount", c => c.Int());
            AlterColumn("dbo.Pharmacies", "PharmacyProviderID", c => c.Int());
            AlterColumn("dbo.Pharmacies", "PrescribingProviderID", c => c.Int());
            AlterColumn("dbo.Pharmacies", "RefillCode", c => c.Int());
            AlterColumn("dbo.Pharmacies", "NCPDPrejectcodes", c => c.Int());
            AlterColumn("dbo.Pharmacies", "NPI", c => c.Int());
            AlterColumn("dbo.Pharmacies", "State", c => c.Int());
            AlterColumn("dbo.Pharmacies", "Zip_Code", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pharmacies", "Zip_Code", c => c.Int(nullable: false));
            AlterColumn("dbo.Pharmacies", "State", c => c.Int(nullable: false));
            AlterColumn("dbo.Pharmacies", "NPI", c => c.Int(nullable: false));
            AlterColumn("dbo.Pharmacies", "NCPDPrejectcodes", c => c.Int(nullable: false));
            AlterColumn("dbo.Pharmacies", "RefillCode", c => c.Int(nullable: false));
            AlterColumn("dbo.Pharmacies", "PrescribingProviderID", c => c.Int(nullable: false));
            AlterColumn("dbo.Pharmacies", "PharmacyProviderID", c => c.Int(nullable: false));
            AlterColumn("dbo.Pharmacies", "BilledAmount", c => c.Int(nullable: false));
            AlterColumn("dbo.Pharmacies", "DaysSupply", c => c.Int(nullable: false));
            AlterColumn("dbo.Pharmacies", "DWAIndecator", c => c.Int(nullable: false));
            AlterColumn("dbo.Pharmacies", "DEASchedule", c => c.Int(nullable: false));
            AlterColumn("dbo.Pharmacies", "Multisource", c => c.Int(nullable: false));
            AlterColumn("dbo.Pharmacies", "NDCCode", c => c.Int(nullable: false));
            AlterColumn("dbo.Pharmacies", "PerscriptionNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Pharmacies", "OriginalClaimNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Pharmacies", "FillDate", c => c.Int(nullable: false));
            AlterColumn("dbo.Pharmacies", "DateofBirth", c => c.Int(nullable: false));
        }
    }
}
