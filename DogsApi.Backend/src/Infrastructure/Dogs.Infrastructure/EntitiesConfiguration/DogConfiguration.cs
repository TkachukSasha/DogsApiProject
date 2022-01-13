using Dogs.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dogs.Infrastructure.EntitiesConfiguration
{
    public class DogConfiguration : IEntityTypeConfiguration<Dog>
    {
        public void Configure(EntityTypeBuilder<Dog> builder)
        {
            builder.HasKey(dog => dog.Id);
            builder.HasIndex(dog => dog.Id).IsUnique();
            builder.Property(dog => dog.Name).IsRequired().HasMaxLength(25);
            builder.Property(dog => dog.Color).IsRequired().HasMaxLength(25);
            builder.Property(dog => dog.TailLenght).IsRequired();
            builder.Property(dog => dog.Weight).IsRequired();
        }
    }
}
