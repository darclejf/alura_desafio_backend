using AluraChallenge.Adopet.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AluraChallenge.Adopet.Data.Mappings
{
    internal class CityMapping : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name)
                .IsRequired()
                .HasColumnType("nvarchar(250)");

            builder.Property(u => u.UF)
                .IsRequired()
                .HasColumnType("nvarchar(2)");

            builder.ToTable("Cities");

            builder.Ignore(t => t.DomainEvents);
        }
    }
}
