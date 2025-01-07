using Microsoft.EntityFrameworkCore;
using Models.Configuration;
using Models.Entities.Models;

namespace Models
{
    public class AppDbContext(
        DbContextOptions<AppDbContext> options,
        IDatabaseConfigurator databaseConfigurator
    ) : DbContext(options)
    {
        private readonly IDatabaseConfigurator _databaseConfigurator = databaseConfigurator;

        public AppDbContext(IDatabaseConfigurator databaseConfigurator)
            : this(new DbContextOptions<AppDbContext>(), databaseConfigurator) { }

        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions)
            : this(DatabaseConfiguratorFactory.Create(DatabaseConfigurators.SQLITE)) { }

        public AppDbContext()
            : this(
                new DbContextOptions<AppDbContext>(),
                DatabaseConfiguratorFactory.Create(DatabaseConfigurators.SQLITE)
            ) { }

        public DbSet<ExampleModel>? Examples { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            _databaseConfigurator.Configure(optionsBuilder);
        }
    }
}
