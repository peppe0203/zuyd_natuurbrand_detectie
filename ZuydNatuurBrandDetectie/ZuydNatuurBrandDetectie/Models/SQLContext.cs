namespace ZuydNatuurBrandDetectie.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SQLContext : DbContext
    {
        public SQLContext()
            : base("name=SQLContext")
        {
        }

        public virtual DbSet<koppelmeldingTbl> koppelmeldingTbls { get; set; }
        public virtual DbSet<meldingenTbl> meldingenTbls { get; set; }
        public virtual DbSet<metingTbl> metingTbls { get; set; }
        public virtual DbSet<nodeTbl> nodeTbls { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<meldingenTbl>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<meldingenTbl>()
                .Property(e => e.beschrijving)
                .IsUnicode(false);

            modelBuilder.Entity<meldingenTbl>()
                .HasMany(e => e.koppelmeldingTbls)
                .WithRequired(e => e.meldingenTbl)
                .HasForeignKey(e => e.meldingId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nodeTbl>()
                .Property(e => e.locatie)
                .IsUnicode(false);

            modelBuilder.Entity<nodeTbl>()
                .Property(e => e.natuurgebied)
                .IsUnicode(false);

            modelBuilder.Entity<nodeTbl>()
                .HasMany(e => e.koppelmeldingTbls)
                .WithRequired(e => e.nodeTbl)
                .HasForeignKey(e => e.nodeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nodeTbl>()
                .HasMany(e => e.metingTbls)
                .WithRequired(e => e.nodeTbl)
                .HasForeignKey(e => e.nodeId)
                .WillCascadeOnDelete(false);
        }
    }
}
