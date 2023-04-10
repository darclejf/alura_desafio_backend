using AluraChallenge.Adopet.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AluraChallenge.Adopet.Data.Mappings
{
    public class ShelterMapping : BaseEntityMapping<Shelter>
    {
        public override void ConfigureProperties(EntityTypeBuilder<Shelter> builder)
        {
            builder.Property(e => e.Name)
               .IsRequired()
               .HasColumnType("nvarchar(250)");

            //TODO commo identificar valuobject email como unique constraint no efcore
            builder.OwnsOne(e => e.Email)
                .Property(e => e.Address)
                .HasColumnName("Email")
                .HasColumnType("nvarchar(250)")
                .IsRequired(true);

            builder.Property(e => e.Phone)
                .HasColumnType("nvarchar(250)");

            builder.HasOne(e => e.User)
                .WithOne()
                .HasForeignKey<Shelter>(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.City)
                .WithOne()
                .HasForeignKey<Shelter>(e => e.CityId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.Pets)
                .WithOne(e => e.Shelter)
                .HasForeignKey(e => e.ShelterId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.UrlImage)
                .HasColumnType("nvarchar(MAX)");

            builder.ToTable("Shelters");
        }
    }
}
