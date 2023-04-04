using AluraChallenge.Adopet.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AluraChallenge.Adopet.Data.Mappings
{
    public class TutorMapping : IEntityTypeConfiguration<Tutor>
    {
        public void Configure(EntityTypeBuilder<Tutor> builder)
        {
            builder.HasKey(t => t.Id);          

            builder.Property(t => t.Name)
                .IsRequired()
                .HasColumnType("nvarchar(250)");

            //TODO commo identificar valuobject email como unique constraint no efcore
            builder.OwnsOne(t => t.Email)
                .Property(t => t.Address)
                .HasColumnName("Email")
                .HasColumnType("nvarchar(250)")
                .IsRequired(true);

            builder.Property(t => t.Phone)
                .HasColumnType("nvarchar(250)");

            builder.Property(t => t.Password)
                .IsRequired()
                .HasColumnType("nvarchar(MAX)");

            builder.HasOne(t => t.City)
                .WithOne()
                .HasForeignKey<Tutor>(t => t.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.ToTable("Tutors");

            builder.Ignore(t => t.DomainEvents);
        }
    }
}
