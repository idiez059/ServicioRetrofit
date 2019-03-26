namespace WebApiRestE2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Modelo : DbContext
    {
        public Modelo()
            : base("name=Modelo")
        {
        }

        public DbSet<alimentos> alimentos { get; set; }
        public DbSet<calorias> calorias { get; set; }
        public DbSet<usuario> usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<alimentos>()
            //    .HasMany(e => e.calorias1)
            //    .WithRequired(e => e.alimentos)
            //    .HasForeignKey(e => e.codigoalimento)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<usuario>()
            //    .HasMany(e => e.calorias)
            //    .WithRequired(e => e.usuario)
            //    .WillCascadeOnDelete(false);
        }
    }
}
