using BeatNationAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;


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
        public DbSet<Licenca> Licencas { get; set; }
        public DbSet<PresetLicenca> PresetLicencas { get; set; }
        public DbSet<LicencaConfig> LicencaConfig { get; set; }

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


            //Faz converão para que não de erro ao salvar "Ilimitado" no banco
            var converter = new ValueConverter<ValorOuIlimitado, string>(
                   v => v.Valor, // Converte do objeto -> banco
                   v => new ValorOuIlimitado { Valor = v } // Converte do banco -> objeto
               );

            modelBuilder.Entity<LicencaConfig>(entity =>
            {
                entity.Property(e => e.Distribuicao).HasConversion(converter);
                entity.Property(e => e.PeriodoUso).HasConversion(converter);
                entity.Property(e => e.StreamingAudio).HasConversion(converter);
                entity.Property(e => e.StreamingVideo).HasConversion(converter);
                entity.Property(e => e.Video).HasConversion(converter);
                entity.Property(e => e.ApresenSemFinsLucrativos).HasConversion(converter);
                entity.Property(e => e.ApresenFimLucrativos).HasConversion(converter);
            });

            // Seed inicial das licenças base
            var licencaBasicaId = Guid.Parse("724c5c55-ecb3-4fc1-a2ad-d77a02833d24");
            var licencaVIPId = Guid.Parse("75974e74-12de-41e4-9fca-f9b87e04e5a6");
            var licencaExclusivaId = Guid.Parse("ead25d1b-6568-4913-98cd-2f363f235d8b");

            // Configurações padrão para cada licença no preset "Default"
            var presetConfigBasicaId = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var presetConfigVIPId = Guid.Parse("22222222-2222-2222-2222-222222222222");
            var presetConfigExclusivaId = Guid.Parse("33333333-3333-3333-3333-333333333333");

            var defaultPresetId = Guid.Parse("97806a3e-ea4d-4c0f-a82f-664f9016990f");
            modelBuilder.Entity<PresetLicenca>().HasData(
                new PresetLicenca
                {
                    Id = defaultPresetId,
                    Nome = "Default",
                    Descricao = "Preset inicial com as 3 licenças padrão",
                    OwnerId = null // preset padrão não tem dono
                }
            );

            modelBuilder.Entity<Licenca>().HasData(
                    new Licenca { Id = licencaBasicaId, Nome = "Básica", OwnerId = null, Categoria = "NaoExclusiva", Descricao = "Licença padrão para uso básico", PresetLicencaId = defaultPresetId },
                    new Licenca { Id = licencaVIPId, Nome = "VIP", OwnerId = null, Categoria = "NaoExclusiva", Descricao = "Licença avançada com mais benefícios dispóniveis", PresetLicencaId = defaultPresetId },
                    new Licenca { Id = licencaExclusivaId, Nome = "Exclusiva", OwnerId = null, Categoria = "Exclusiva", Descricao = "Licença exclusiva para uso total e irrestrito", PresetLicencaId = defaultPresetId }
                );
            // Preset inicial "Default" com as 3 licenças padrão

            modelBuilder.Entity<LicencaConfig>().HasData(
                            new LicencaConfig // Básica
                            {

                                Id = presetConfigBasicaId,
                                LicencasId = licencaBasicaId,

                                PeriodoUso = 1,
                                Distribuicao = 15000,
                                StreamingAudio = 20000,
                                StreamingVideo = 20000,
                                Video = 1,
                                ApresenSemFinsLucrativos = 2500,
                                ApresenFimLucrativos = 300,
                                Preco = 0,
                                Porcentagem = 20,
                                RoyaltShare = 20,
                                ExibirEmissoraRadio = true,
                                ExibirEmissoraTV = false
                            },
            new LicencaConfig // VIP
            {

                Id = presetConfigVIPId,
                LicencasId = licencaVIPId, // Id da licenca VIP
                PeriodoUso = 3,
                Distribuicao = 20000,
                StreamingAudio = 50000,
                StreamingVideo = 50000,
                Video = 1,
                ApresenSemFinsLucrativos = 5000,
                ApresenFimLucrativos = 500,
                Preco = 0,
                Porcentagem = 30,
                RoyaltShare = 20,
                ExibirEmissoraRadio = true,
                ExibirEmissoraTV = true
            },
            new LicencaConfig // Exclusiva
            {
                Id = presetConfigExclusivaId,
                LicencasId = licencaExclusivaId,
                PeriodoUso = "Ilimitado", // Ilimitado
                Distribuicao = "Ilimitado",
                StreamingAudio = "Ilimitado",
                StreamingVideo = "Ilimitado",
                Video = "Ilimitado",
                ApresenSemFinsLucrativos = "Ilimitado",
                ApresenFimLucrativos = "Ilimitado",
                Preco = 0,
                Porcentagem = 100,
                RoyaltShare = 20,
                ExibirEmissoraRadio = true,
                ExibirEmissoraTV = true
            });
        }
    }
}
