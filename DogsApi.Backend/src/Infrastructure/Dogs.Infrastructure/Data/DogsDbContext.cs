using Dogs.Application.Common.Contracts;
using Dogs.Core.Entities;
using Dogs.Infrastructure.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Dogs.Infrastructure.Data
{
    public class DogsDbContext : DbContext, IDogsDbContext
    {
        public DogsDbContext(DbContextOptions<DogsDbContext> options) : base(options) { }

        public DbSet<Dog> Dogs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new DogConfiguration());
            base.OnModelCreating(builder);
        }

    }
}
