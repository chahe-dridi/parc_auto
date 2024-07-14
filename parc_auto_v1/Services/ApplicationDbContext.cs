using Microsoft.EntityFrameworkCore;

namespace parc_auto_v1.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Voiture> Voitures { get; set; }
        public DbSet<VisiteTechnique> VisiteTechniques { get; set; }
        public DbSet<Vidange> Vidanges { get; set; }
        public DbSet<Sinistre> Sinistres { get; set; }
        public DbSet<Assurance> Assurances { get; set; }
        public DbSet<Vignette> Vignettes { get; set; }
        public DbSet<Demandes> Demandes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Voiture>()
                .HasKey(v => v.Id);

            modelBuilder.Entity<Voiture>()
                .Property(v => v.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Voiture>()
                .HasMany(v => v.VisiteTechniques)
                .WithOne(vt => vt.Voiture)
                .HasForeignKey(vt => vt.VoitureId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Voiture>()
                .HasMany(v => v.Vidanges)
                .WithOne(vd => vd.Voiture)
                .HasForeignKey(vd => vd.VoitureId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Voiture>()
                .HasMany(v => v.Sinistres)
                .WithOne(s => s.Voiture)
                .HasForeignKey(s => s.VoitureId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Voiture>()
                .HasMany(v => v.Assurances)
                .WithOne(a => a.Voiture)
                .HasForeignKey(a => a.VoitureId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Voiture>()
                .HasMany(v => v.Vignettes)
                .WithOne(vg => vg.Voiture)
                .HasForeignKey(vg => vg.VoitureId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
