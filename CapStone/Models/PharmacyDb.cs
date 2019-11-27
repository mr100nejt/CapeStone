
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace CapStone.Models
{
    public class PharmacyDb
    {
        [Key]
        public int PharmacyId { get; set; }
        public string DateEntered { get; set; }
        public List<Pharmacy> pharmList { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }


    }
}