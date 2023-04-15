using AluraChallenge.Adopet.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AluraChallenge.Adopet.Data.Mappings
{
    public class TutorMapping : BaseEntityMapping<Tutor>
    {
        public override void ConfigureProperties(EntityTypeBuilder<Tutor> builder)
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

            builder.Property(e => e.About)
                .HasColumnType("nvarchar(MAX)");

            builder.HasOne(e => e.City)
                .WithOne()
                .HasForeignKey<Tutor>(e => e.CityId)
                .OnDelete(DeleteBehavior.SetNull);

            //builder.HasOne<IdentityUser>()  //TODO error para FK com identityuser:  The entity type 'IdentityUserLogin' requires a primary key to be defined
            //    .WithMany()
            //    .HasForeignKey("UserId");

            builder.Property(e => e.UrlImage)
                .HasColumnType("nvarchar(MAX)");

            builder.ToTable("Tutors");
        }
    }
}
