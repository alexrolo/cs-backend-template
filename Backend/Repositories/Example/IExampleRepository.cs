using Backend.Repositories.Rest;
using Models.Entities.Models;

namespace Backend.Repositories.Example
{
    public interface IExampleRepository : IRestRepository<ExampleModel> { }
}
