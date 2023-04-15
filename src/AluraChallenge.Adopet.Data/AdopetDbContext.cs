using AluraChallenge.Adopet.Data.Mappings;
using AluraChallenge.Adopet.Domain;
using AluraChallenge.Adopet.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AluraChallenge.Adopet.Data
{
    /// <summary>
    /// Classe que representa um contexto para base de dados AdopetDb
    /// </summary>
    public class AdopetDbContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
    {
        //public static readonly ILoggerFactory loggerFactory = new LoggerFactory().AddConsole((_, ___) => true);

        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<Shelter> Shelters { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Pet> Pets { get; set; } //TODO de momento serve apenas para services query, separar em outro projeto??
        public DbSet<Domain.Adopet> Adopets { get; set; }


        public AdopetDbContext(DbContextOptions<AdopetDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CityMapping());
            modelBuilder.ApplyConfiguration(new PetMapping());
            modelBuilder.ApplyConfiguration(new ShelterMapping());
            modelBuilder.ApplyConfiguration(new TutorMapping());
            modelBuilder.ApplyConfiguration(new AdopetMapping());

            modelBuilder.Entity<IdentityRole<Guid>>().HasData(
                new IdentityRole<Guid> { Id = Guid.NewGuid(), Name = ProfileRole.Admin, NormalizedName = ProfileRole.Admin.ToUpper() });

            modelBuilder.Entity<IdentityRole<Guid>>().HasData(
                new IdentityRole<Guid> { Id = Guid.NewGuid(), Name = ProfileRole.Tutor, NormalizedName = ProfileRole.Tutor.ToUpper() });

            modelBuilder.Entity<IdentityRole<Guid>>().HasData(
                new IdentityRole<Guid> { Id = Guid.NewGuid(), Name = ProfileRole.Shelter, NormalizedName = ProfileRole.Shelter.ToUpper() });
        }
    }
}