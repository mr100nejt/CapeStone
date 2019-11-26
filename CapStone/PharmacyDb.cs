namespace CapStone
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PharmacyDb : DbContext
    {
        public PharmacyDb()
            : base("name=PharmacyDb")
        {
        }

        public virtual DbSet<Pharmacy> Pharmacies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
