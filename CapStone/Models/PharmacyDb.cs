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
        public int StandardRefId { get; set; }
        [ForeignKey("AppUserId")]
        public ApplicationUser appUserId { get; set; }
       

    }
}