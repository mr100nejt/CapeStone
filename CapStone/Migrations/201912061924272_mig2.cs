namespace CapStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pharmacies",
                c => new
                    {
                        PharmacyDataId = c.Int(nullable: false, identity: true),
                        MemberId = c.Double(),
                        MemberFirstName = c.String(),
                        MemberLastName = c.String(),
                        MemberMiddleInitial = c.String(),
                        DateofBirth = c.Double(),
                        Gender = c.String(),
                        FillDate = c.Double(),
                        ClaimStatus = c.String(),
                        ClaimNumber = c.String(),
                        OriginalClaimNumber = c.String(),
                        PerscriptionNumber = c.Double(),
                        NDCCode = c.Double(),
                        DrugName = c.String(),
                        OTCIndicator = c.String(),
                        Multisource = c.Double(),
                        DEASchedule = c.Double(),
                        DiagnosisCode = c.String(),
                        DWAIndecator = c.Double(),
                        DaysSupply = c.Double(),
                        BilledAmount = c.Double(),
                        PharmacyProviderID = c.String(),
                        PrescribingProviderID = c.Double(),
                        RefillCode = c.Double(),
                        blankSpace = c.Double(),
                        NCPDPrejectcodes = c.String(),
                        NPI = c.Double(),
                        Last_Name = c.String(),
                        First_Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip_Code = c.String(),
                        DateAdded = c.String(),
                        Watch = c.Boolean(nullable: false),
                        specialId = c.Int(nullable: false),
                        ApplicationId = c.String(maxLength: 128),
                        PharmacyDb_PharmacyId = c.Int(),
                    })
                .PrimaryKey(t => t.PharmacyDataId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationId)
                .ForeignKey("dbo.PharmacyDbs", t => t.PharmacyDb_PharmacyId)
                .Index(t => t.ApplicationId)
                .Index(t => t.PharmacyDb_PharmacyId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Pharmacies", "PharmacyDb_PharmacyId", "dbo.PharmacyDbs");
            DropForeignKey("dbo.PharmacyDbs", "ApplicationId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Pharmacies", "ApplicationId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PharmacyDbs", new[] { "ApplicationId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Pharmacies", new[] { "PharmacyDb_PharmacyId" });
            DropIndex("dbo.Pharmacies", new[] { "ApplicationId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PharmacyDbs");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Pharmacies");
        }
    }
}
