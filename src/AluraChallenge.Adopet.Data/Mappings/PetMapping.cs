using AluraChallenge.Adopet.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AluraChallenge.Adopet.Data.Mappings
{
    public class PetMapping : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name)
                .IsRequired()
                .HasColumnType("varchar(250)");

            //builder.Property(u => u.Type)
            //    .HasDefaultValue(ResponsibleType.Individual)
            //    .HasConversion<string>();

            builder.ToTable("Pets");

            builder.Ignore(t => t.DomainEvents);
        }
    }
}
