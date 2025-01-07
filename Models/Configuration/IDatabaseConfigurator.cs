using Microsoft.EntityFrameworkCore;

namespace Models.Configuration
{
    public interface IDatabaseConfigurator
    {
        void Configure(DbContextOptionsBuilder optionsBuilder);
    }
}
