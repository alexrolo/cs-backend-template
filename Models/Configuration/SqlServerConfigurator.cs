using Microsoft.EntityFrameworkCore;

namespace Models.Configuration
{
    public class SqlServerConfigurator : IDatabaseConfigurator
    {
        public void Configure(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString =
                Environment.GetEnvironmentVariable("SQLSERVER_CONNECTION_STRING")
                ?? "Server=localhost;Database=mydb;User Id=myuser;Password=mypassword;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
