using AluraChallenge.Adopet.Data.Mappings;
using AluraChallenge.Adopet.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace AluraChallenge.Adopet.Data
{
    /// <summary>
    /// Classe que representa um contexto para base de dados AdopetDb
    /// </summary>
    public class AdopetDbContext : DbContext
    {
        //public static readonly ILoggerFactory loggerFactory = new LoggerFactory().AddConsole((_, ___) => true);

        public DbSet<Tutor> Tutors { get; set; }
        //public DbSet<Pet> Pets { get; set; }
        public DbSet<City> Cities { get; set; }

        public AdopetDbContext(DbContextOptions<AdopetDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TutorMapping());
            modelBuilder.ApplyConfiguration(new CityMapping());
        }
    }
}