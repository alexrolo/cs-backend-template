using Backend.Services.Rest;
using Models.Entities.Models;

namespace Backend.Services.Example
{
    public interface IExampleService : IRestService<ExampleModel>;
}
