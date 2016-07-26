namespace cake_assignment1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CakeModel : DbContext
    {
        public CakeModel()
            : base("name=CakeModel")
        {
        }

        public virtual DbSet<CakeDesc> CakeDescs { get; set; }
        public virtual DbSet<Cake> Cakes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CakeDesc>()
                .Property(e => e.CakeName)
                .IsUnicode(false);

            modelBuilder.Entity<CakeDesc>()
                .Property(e => e.CakesDesc)
                .IsUnicode(false);

            modelBuilder.Entity<CakeDesc>()
                .Property(e => e.Rate)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Cake>()
                .Property(e => e.CakeName)
                .IsUnicode(false);

            modelBuilder.Entity<Cake>()
                .HasOptional(e => e.CakeDesc)
                .WithRequired(e => e.Cake);
        }
    }
}
