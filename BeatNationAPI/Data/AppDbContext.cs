using BeatNationAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;


namespace BeatNationAPI.Data
{
    public class AppDbContext(DbContextOptions options) : IdentityDbContext<User, IdentityRole<Guid>, Guid>(options)
    {

        // DbSets representam suas tabelas
        public DbSet<Beat> Beats { get; set; }
        // public DbSet<BeatLicencas> BeatLicencas { get; set; }
        public DbSet<License> Licenses { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        // Configurações extras (opcional)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             base.OnModelCreating(modelBuilder);
            // // Exemplo: relação 1:N Beat -> BeatColab
            // modelBuilder.Entity<BeatColab>()
            //         .HasOne(c => c.Beat)
            //         .WithMany(b => b.Colaboradores)
            //         .HasForeignKey(c => c.BeatId);

            // // Exemplo: relação 1:N Beat -> BeatLicencas
            // modelBuilder.Entity<BeatLicencas>()
            //         .HasOne(l => l.Beat)
            //         .WithMany(b => b.BeatLicencas)
            //         .HasForeignKey(l => l.BeatId);



            //Faz converão para que não de erro ao salvar "Ilimitado" no banco
            var converter = new ValueConverter<ValueOrIlimited, string>(
                v => v.Value, // objeto → string (para salvar no banco)
                v => v == "Ilimitado"
                    ? ValueOrIlimited.CreateIlimited()
                    : ValueOrIlimited.CreateNumber(int.Parse(v)) // string → objeto
            );

            //Refazer depois essa parte 
            modelBuilder.Entity<LicenseAssignment>(entity =>
            {
                entity.Property(e => e.Distribuicao).HasConversion(converter);
                entity.Property(e => e.PeriodoUso).HasConversion(converter);
                entity.Property(e => e.StreamingAudio).HasConversion(converter);
                entity.Property(e => e.StreamingVideo).HasConversion(converter);
                entity.Property(e => e.Video).HasConversion(converter);
                entity.Property(e => e.ApresenSemFinsLucrativos).HasConversion(converter);
                entity.Property(e => e.ApresenFimLucrativos).HasConversion(converter);
            });

            modelBuilder.Entity<License>(entity =>
            {
                entity.Property(e => e.Distribution).HasConversion(converter);
                entity.Property(e => e.DurationUse).HasConversion(converter);
                entity.Property(e => e.StreamingAudio).HasConversion(converter);
                entity.Property(e => e.StreamingVideo).HasConversion(converter);
                entity.Property(e => e.Video).HasConversion(converter);
                entity.Property(e => e.ApresenSemFinsLucrativos).HasConversion(converter);
                entity.Property(e => e.ApresenFimLucrativos).HasConversion(converter);
            });

            // Seed inicial das licenças base
            var licenseBasicId = Guid.Parse("724c5c55-ecb3-4fc1-a2ad-d77a02833d24");
            var licenseVIPId = Guid.Parse("75974e74-12de-41e4-9fca-f9b87e04e5a6");
            var licenseExclusiveId = Guid.Parse("ead25d1b-6568-4913-98cd-2f363f235d8b");

            modelBuilder.Entity<License>().HasData(
                    new License
                    {
                        Id = licenseBasicId,
                        Name = "Básica",
                        ProducerId = null,
                        Category = "NaoExclusiva",
                        Description = "Licença padrão para uso básico",
                        DurationUse = ValueOrIlimited.CreateNumber(1),
                        Distribution = ValueOrIlimited.CreateNumber(15000),
                        StreamingAudio = ValueOrIlimited.CreateNumber(20000),
                        StreamingVideo = ValueOrIlimited.CreateNumber(20000),
                        Video = ValueOrIlimited.CreateNumber(1),
                        ApresenSemFinsLucrativos = ValueOrIlimited.CreateNumber(2500),
                        ApresenFimLucrativos = ValueOrIlimited.CreateNumber(300),
                        RoyaltShare = 20,
                        ExibirEmissoraRadio = true,
                        ExibirEmissoraTV = false,
                        ShareMp3 = true,
                        ShareWav = false,
                        ShareTrackout = false

                    },
                    new License
                    {
                        Id = licenseVIPId,
                        Name = "VIP",
                        ProducerId = null,
                        Category = "NaoExclusiva",
                        Description = "Licença avançada com mais benefícios dispóniveis",
                        DurationUse = ValueOrIlimited.CreateNumber(3),
                        Distribution = ValueOrIlimited.CreateNumber(20000),
                        StreamingAudio = ValueOrIlimited.CreateNumber(50000),
                        StreamingVideo = ValueOrIlimited.CreateNumber(50000),
                        Video = ValueOrIlimited.CreateNumber(1),
                        ApresenSemFinsLucrativos = ValueOrIlimited.CreateNumber(5000),
                        ApresenFimLucrativos = ValueOrIlimited.CreateNumber(500),
                        RoyaltShare = 20,
                        ExibirEmissoraRadio = true,
                        ExibirEmissoraTV = true,
                        ShareMp3 = false,
                        ShareWav = true,
                        ShareTrackout = false
                    },

                    new License
                    {
                        Id = licenseExclusiveId,
                        Name = "Exclusiva",
                        ProducerId = null,
                        Category = "Exclusiva",
                        Description = "Licença exclusiva para uso total e irrestrito",
                        DurationUse = ValueOrIlimited.CreateIlimited(), // Ilimitado
                        Distribution = ValueOrIlimited.CreateIlimited(),
                        StreamingAudio = ValueOrIlimited.CreateIlimited(),
                        StreamingVideo = ValueOrIlimited.CreateIlimited(),
                        Video = ValueOrIlimited.CreateIlimited(),
                        ApresenSemFinsLucrativos = ValueOrIlimited.CreateIlimited(),
                        ApresenFimLucrativos = ValueOrIlimited.CreateIlimited(),
                        RoyaltShare = 20,
                        ExibirEmissoraRadio = true,
                        ExibirEmissoraTV = true,
                        ShareMp3 = true,
                        ShareWav = true,
                        ShareTrackout = true
                    }
                );
        }
    }
}
