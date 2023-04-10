using AluraChallenge.Adopet.Domain.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace AluraChallenge.Adopet.Data.Mappings
{
    public abstract class BaseEntityMapping<T> : IEntityTypeConfiguration<T>  where T : Entity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(e => e.Id);
            //builder.Property(e => e.Id).HasValueGenerator(DatabaseGeneratedOption.Identity);
            builder.Ignore(t => t.DomainEvents);
            ConfigureProperties(builder);
        }

        public abstract void ConfigureProperties(EntityTypeBuilder<T> builder);
    }
}
