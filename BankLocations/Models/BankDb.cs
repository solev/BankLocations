namespace BankLocations.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BankDb : DbContext
    {
        public BankDb()
            : base("name=BankDb")
        {
        }

        public virtual DbSet<CadVendor> CadVendors { get; set; }
        public virtual DbSet<CadZoneBankLocation> CadZoneBankLocations { get; set; }
        public virtual DbSet<Site> Sites { get; set; }        
        public virtual DbSet<vwTab_Data> vwTab_Data { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CadVendor>()
                .Property(e => e.VendorName)
                .IsUnicode(false);

            modelBuilder.Entity<CadVendor>()
                .Property(e => e.VendorAbbreviation)
                .IsUnicode(false);

            modelBuilder.Entity<CadVendor>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<CadVendor>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<CadZoneBankLocation>()
                .Property(e => e.Zone)
                .IsUnicode(false);

            modelBuilder.Entity<CadZoneBankLocation>()
                .Property(e => e.Bank)
                .IsUnicode(false);

            modelBuilder.Entity<CadZoneBankLocation>()
                .Property(e => e.Location)
                .IsUnicode(false);

            modelBuilder.Entity<Site>()
                .Property(e => e.SiteName)
                .IsUnicode(false);
            

            modelBuilder.Entity<vwTab_Data>()
                .Property(e => e.ZoneName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTab_Data>()
                .Property(e => e.BankNumber)
                .IsUnicode(false);

            modelBuilder.Entity<vwTab_Data>()
                .Property(e => e.LocationNumber)
                .IsUnicode(false);

            modelBuilder.Entity<vwTab_Data>()
                .Property(e => e.SiteName)
                .IsUnicode(false);
        }
    }
}
