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
        public DbSet<Licencas> Licencas { get; set; }
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

            //Faz converão para que não de erro ao salvar "Ilimitado" no banco
            var converter = new ValueConverter<ValorOuIlimitado, string>(
                   v => v.Valor, // Converte do objeto -> banco
                   v => new ValorOuIlimitado { Valor = v } // Converte do banco -> objeto
               );

            modelBuilder.Entity<PresetLicencaConfig>(entity =>
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

            modelBuilder.Entity<Licencas>().HasData(
                    new Licencas { Id = licencaBasicaId, Nome = "Básica", OwnerId = null, Categoria = "NaoExclusiva", Descricao = "Licença padrão para uso básico" },
                    new Licencas { Id = licencaVIPId, Nome = "VIP", OwnerId = null, Categoria = "NaoExclusiva", Descricao = "Licença avançada com mais benefícios dispóniveis" },
                    new Licencas { Id = licencaExclusivaId, Nome = "Exclusiva", OwnerId = null, Categoria = "Exclusiva", Descricao = "Licença exclusiva para uso total e irrestrito" }
                );
            // Preset inicial "Default" com as 3 licenças padrão
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
            // Configurações padrão para cada licença no preset "Default"
            var presetConfigBasicaId = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var presetConfigVIPId = Guid.Parse("22222222-2222-2222-2222-222222222222");
            var presetConfigExclusivaId = Guid.Parse("33333333-3333-3333-3333-333333333333");

            modelBuilder.Entity<PresetLicencaConfig>().HasData(
                            new PresetLicencaConfig // Básica
                            {

                                Id = presetConfigBasicaId,
                                LicencasId = licencaBasicaId,
                                LicencaNome = "Básica",
                                PresetLicencaId = defaultPresetId, // ID da Básica
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
            new PresetLicencaConfig // VIP
            {

                Id = presetConfigVIPId,
                PresetLicencaId = defaultPresetId,
                LicencaNome = "VIP",
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
            new PresetLicencaConfig // Exclusiva
            {
                Id = presetConfigExclusivaId,
                LicencasId = licencaExclusivaId,
                LicencaNome = "Exclusiva",
                PresetLicencaId = defaultPresetId, //Id da exclusiva
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
