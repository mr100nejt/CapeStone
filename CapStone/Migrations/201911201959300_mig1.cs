namespace CapStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pharmacies",
                c => new
                    {
                        MemberId = c.Int(nullable: false, identity: true),
                        MemberFirstName = c.String(),
                        MemberLastName = c.String(),
                        MemberMiddleInitial = c.String(),
                        DateofBirth = c.Int(nullable: false),
                        Gender = c.String(),
                        FillDate = c.Int(nullable: false),
                        ClaimStatus = c.String(),
                        ClaimNumber = c.String(),
                        OriginalClaimNumber = c.Int(nullable: false),
                        PerscriptionNumber = c.Int(nullable: false),
                        NDCCode = c.Int(nullable: false),
                        DrugName = c.String(),
                        OTCIndicator = c.String(),
                        Multisource = c.Int(nullable: false),
                        DEASchedule = c.Int(nullable: false),
                        DiagnosisCode = c.String(),
                        DWAIndecator = c.Int(nullable: false),
                        DaysSupply = c.Int(nullable: false),
                        BilledAmount = c.Int(nullable: false),
                        PharmacyProviderID = c.Int(nullable: false),
                        PrescribingProviderID = c.Int(nullable: false),
                        RefillCode = c.Int(nullable: false),
                        NCPDPrejectcodes = c.Int(nullable: false),
                        NPI = c.Int(nullable: false),
                        Last_Name = c.String(),
                        First_Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.Int(nullable: false),
                        Zip_Code = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MemberId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pharmacies");
        }
    }
}
