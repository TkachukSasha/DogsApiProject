using Dogs.Core.Entities;
using Dogs.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Dogs.Test.Common.Helpers
{
    public class DogsContextFactory
    {
        public static DogsDbContext Create()
        {
            var options = new DbContextOptionsBuilder<DogsDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new DogsDbContext(options);
            context.Database.EnsureCreated();
            context.Dogs.AddRange(
                new Dog
                {
                    Id = Guid.Parse("A6BB65BB-5AC2-4AFA-8A28-2616F675B825"),
                    Name = "Jerry",
                    Color = "Black",
                    TailLenght = 35,
                    Weight = 25
                },
                new Dog
                {

                    Id = Guid.Parse("A6BB65BB-5AC2-4AFA-8A28-2616F675B825"),
                    Name = "Marry",
                    Color = "White",
                    TailLenght = 23,
                    Weight = 15
                }
            );
            context.SaveChanges();
            return context;
        }

        public static void Destroy(DogsDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
