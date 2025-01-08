using Models.Entities.DTOs;
using Models.Entities.Models;

namespace Models.Entities.Mappers
{
    public class ExampleMapper : IMapper<ExampleModel, ExampleDto>
    {
        public ExampleModel ToModel(ExampleDto dto)
        {
            return new ExampleModel { Id = dto.Id, Name = dto.Name };
        }

        public ExampleDto ToDto(ExampleModel model)
        {
            return new ExampleDto { Id = model.Id, Name = model.Name };
        }
    }
}
