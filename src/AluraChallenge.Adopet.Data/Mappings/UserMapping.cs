using AluraChallenge.Adopet.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AluraChallenge.Adopet.Data.Mappings
{
    public class UserMapping : BaseEntityMapping<User>
    {
        public override void ConfigureProperties(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.UserName)
                .IsRequired()
                .HasColumnType("nvarchar(250)");

            builder.Property(e => e.Password)
                .IsRequired()
                .HasColumnType("nvarchar(MAX)");

            builder.Property(e => e.Role)
                .IsRequired()
                .HasConversion<string>();

            builder.ToTable("Users");
        }
    }
}
