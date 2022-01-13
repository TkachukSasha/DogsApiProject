namespace Dogs.Infrastructure.Data
{
    public class DbInitializer
    {
        public static void Initialize(DogsDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
