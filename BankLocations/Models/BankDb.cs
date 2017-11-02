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

        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Site> Sites { get; set; }
        public virtual DbSet<Zone> Zones { get; set; }
        public virtual DbSet<Tab_Data> Tab_Data { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bank>()
                .Property(e => e.BankNumber)
                .IsUnicode(false);
            
            modelBuilder.Entity<Site>()
                .Property(e => e.SiteName)
                .IsUnicode(false);

            modelBuilder.Entity<Zone>()
                .Property(e => e.ZoneName)
                .IsUnicode(false);

            modelBuilder.Entity<Tab_Data>()
                .Property(e => e.ZoneName)
                .IsUnicode(false);

            modelBuilder.Entity<Tab_Data>()
                .Property(e => e.BankNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Tab_Data>()
                .Property(e => e.LocationNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Tab_Data>()
                .Property(e => e.SiteName)
                .IsUnicode(false);
        }
    }
}
