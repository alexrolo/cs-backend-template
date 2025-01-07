using Backend.Repositories.Example;
using Backend.Services.Rest;
using Models.Entities.Models;

namespace Backend.Services.Example
{
    public class ExampleService(IExampleRepository repository)
        : RestService<ExampleModel>(repository),
            IExampleService { }
}
