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
        public DbSet<BeatLicencas> BeatLicencas { get; set; }
        public DbSet<LicencaBase> LicencasBase { get; set; }
        public DbSet<PresetLicenca> PresetLicencas { get; set; }
        public DbSet<PresetLicencaConfig> PresetLicencasConfig { get; set; }

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
                .WithMany(b => b.BeatLicencas)
                .HasForeignKey(l => l.BeatId);

            // outras configurações de chave primária, índices, etc

            // PresetLicenca -> PresetLicencaConfig
            modelBuilder.Entity<PresetLicencaConfig>()
                .HasOne(c => c.PresetLicenca)              // cada config tem 1 preset
                .WithMany(p => p.Licencas)          // um preset tem várias configs
                .HasForeignKey(c => c.PresetLicencaId)     // FK em PresetLicencaConfig
                .OnDelete(DeleteBehavior.Cascade);  // se deletar o preset, apaga as configs

        }
    }
}
