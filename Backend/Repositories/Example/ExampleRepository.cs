using Backend.Repositories.Rest;
using Models;
using Models.Entities.Models;

namespace Backend.Repositories.Example
{
    public class ExampleRepository(AppDbContext context)
        : RestRepository<ExampleModel>(context),
            IExampleRepository { }
}
