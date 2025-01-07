using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Models.Entities.Models;

namespace Models
{
    public static class DataSeeder
    {
        public static void Seed(IServiceProvider services)
        {
            SeedExamples(services);
        }

        private static void SeedExamples(IServiceProvider services)
        {
            using AppDbContext context = new(
                services.GetRequiredService<DbContextOptions<AppDbContext>>()
            );

            if (context.Examples == null)
                return;

            List<ExampleModel> seedData =
            [
                new() { Name = "Sample Data 1" },
                new() { Name = "Sample Data 2" },
            ];

            foreach (ExampleModel example in seedData)
            {
                if (!context.Examples.Any(e => e.Name == example.Name))
                {
                    context.Examples.Add(example);
                }
            }

            context.SaveChanges();
        }
    }
}
