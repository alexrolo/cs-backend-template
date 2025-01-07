using Microsoft.EntityFrameworkCore;

namespace Models.Configuration
{
    public class PostgreSqlConfigurator : IDatabaseConfigurator
    {
        public void Configure(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString =
                Environment.GetEnvironmentVariable("POSTGRESQL_CONNECTION_STRING")
                ?? "Host=localhost;Database=mydb;Username=myuser;Password=mypassword";
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
