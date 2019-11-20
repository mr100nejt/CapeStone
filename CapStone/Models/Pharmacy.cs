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
        public int MemberId { get; set; }
        public string MemberFirstName { get; set; }
        public string MemberLastName { get; set; }
        public string MemberMiddleInitial { get; set; }
        public int DateofBirth { get; set; }
        public string Gender { get; set; }
        public int FillDate { get; set; }
        public string ClaimStatus{ get; set; }
        public int ClaimNumber { get; set; }
        public int OriginalClaimNumber { get; set; }
        public int PerscriptionNumber { get; set; }
        public int NDCCode { get; set; }
        public string DrugName { get; set; }
        public string OTCIndicator { get; set; }
        public int Multisource { get; set; }
        public int DEASchedule { get; set; }
        public string DiagnosisCode { get; set; }
        public int DWAIndecator { get; set; }
        public int DaysSupply { get; set; }
        public int BilledAmount { get; set; }
        public int PharmacyProviderID { get; set; }
        public int PrescribingProviderID { get; set; }
        public int RefillCode { get; set; }
        public int NCPDPrejectcodes { get; set; }
        public int NPI  { get; set; }
        public string Last_Name { get; set; }
        public string First_Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int State { get; set; }
        public int Zip_Code { get; set; }


    }
}