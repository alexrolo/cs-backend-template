using Backend.Services.Example;
using Models.Entities.DTOs;
using Models.Entities.Mappers;
using Models.Entities.Models;

namespace Backend.Controllers
{
    public class ExampleController(
        IExampleService service,
        IMapper<ExampleModel, ExampleDto> mapper
    ) : RestController<ExampleModel, ExampleDto>(service, mapper) { }
}
