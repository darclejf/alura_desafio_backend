using AluraChallenge.Adopet.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AluraChallenge.Adopet.Data.Mappings
{
    public class CityMapping : BaseEntityMapping<City>
    {
        public override void ConfigureProperties(EntityTypeBuilder<City> builder)
        {
            builder.Property(u => u.Name)
                .IsRequired()
                .HasColumnType("nvarchar(250)");

            builder.Property(u => u.UF)
                .IsRequired()
                .HasColumnType("nvarchar(2)");

            builder.ToTable("Cities");
        }
    }
}
