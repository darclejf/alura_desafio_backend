using AluraChallenge.Adopet.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AluraChallenge.Adopet.Data.Mappings
{
    public class PetMapping : BaseEntityMapping<Pet>
    {
        public override void ConfigureProperties(EntityTypeBuilder<Pet> builder)
        {
            builder.Property(e => e.Name)
                        .IsRequired()
                        .HasColumnType("varchar(250)");

            builder.Property(e => e.Age)
                        .IsRequired()
                        .HasColumnType("varchar(250)");

            builder.Property(e => e.Specimen)
                        .IsRequired()
                        .HasConversion<string>();

            builder.Property(e => e.Size)
                        .IsRequired()
                        .HasConversion<string>();

            builder.Property(e => e.Gender)
                        .IsRequired()
                        .HasConversion<string>();

            builder.Property(e => e.Behavior)
                        .IsRequired()
                        .HasColumnType("varchar(250)");

            builder.Property(e => e.Adopeted)
                        .IsRequired();

            builder.HasOne(e => e.Shelter)
                        .WithOne()
                        .HasForeignKey<Pet>(e => e.ShelterId)
                        .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Pets");
        }
    }
}
