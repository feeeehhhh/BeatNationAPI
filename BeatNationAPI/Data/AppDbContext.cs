using BeatNationAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace BeatNationAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSets representam suas tabelas
        public DbSet<Beat> Beats { get; set; }
        public DbSet<BeatColab> BeatColabs { get; set; }
        public DbSet<Licenca> Licencas { get; set; }
        public DbSet<LicencaPresets> LicencaPresets { get; set; }
        public DbSet<BeatLicencas> BeatLicencas { get; set; }

        // Configurações extras (opcional)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Exemplo: relação 1:N Beat -> BeatColab
            modelBuilder.Entity<BeatColab>()
                .HasOne(c => c.Beat)
                .WithMany(b => b.Colaboradores)
                .HasForeignKey(c => c.BeatId);

            // Exemplo: relação 1:N Beat -> BeatLicencas
            modelBuilder.Entity<BeatLicencas>()
                .HasOne(l => l.Beat)
                .WithMany(b => b.Licencas)
                .HasForeignKey(l => l.BeatId);

            // outras configurações de chave primária, índices, etc
        }
    }
}
