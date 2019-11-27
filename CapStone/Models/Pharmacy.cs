using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CapStone.Models
{
    public class Pharmacy
    {
        [Key]
        public int? PharmacyDataId { get; set; }
        public double? MemberId { get; set; }
        public string MemberFirstName { get; set; }
        public string MemberLastName { get; set; }
        public string MemberMiddleInitial { get; set; }
        public double? DateofBirth { get; set; }
        public string Gender { get; set; }
        public double? FillDate { get; set; }
        public string ClaimStatus { get; set; }
        public string ClaimNumber { get; set; }
        public string OriginalClaimNumber { get; set; }
        public double? PerscriptionNumber { get; set; }
        public double? NDCCode { get; set; }
        public string DrugName { get; set; }
        public string OTCIndicator { get; set; }
        public double? Multisource { get; set; }
        public double? DEASchedule { get; set; }
        public string DiagnosisCode { get; set; }
        public double? DWAIndecator { get; set; }
        public double? DaysSupply { get; set; }
        public double? BilledAmount { get; set; }
        public string PharmacyProviderID { get; set; }
        public double? PrescribingProviderID { get; set; }
        public double? RefillCode { get; set; }
        public double? blankSpace{ get; set;}
        public string NCPDPrejectcodes { get; set; }
        public double? NPI  { get; set; }
        public string Last_Name { get; set; }
        public string First_Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip_Code { get; set; }
        public string DateAdded { get; set;  }


    }
}