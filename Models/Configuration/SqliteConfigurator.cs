using Microsoft.EntityFrameworkCore;

namespace Models.Configuration
{
    public class SqliteConfigurator : IDatabaseConfigurator
    {
        public void Configure(DbContextOptionsBuilder optionsBuilder)
        {
            string databaseFileLocation =
                Environment.GetEnvironmentVariable("DATABASE_FILE_LOCATION") ?? "../database.db";
            optionsBuilder.UseSqlite($"Data Source={databaseFileLocation}");
        }
    }
}
