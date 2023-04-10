using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AluraChallenge.Adopet.Data.Mappings
{
    public class AdopetMapping : BaseEntityMapping<Domain.Adopet>
    {
        public override void ConfigureProperties(EntityTypeBuilder<Domain.Adopet> builder)
        {
            builder.HasOne(e => e.Tutor)
                    .WithOne()
                    .HasForeignKey<Domain.Adopet>(e => e.TutorId)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.Pet)
                    .WithOne()
                    .HasForeignKey<Domain.Adopet>(e => e.PetId)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("Adopets");
        }
    }
}
