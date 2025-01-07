using Models.Entities.DTOs;
using Models.Entities.Models;

namespace Models.Entities.Mappers
{
    public interface IMapper<TModel, TDto>
        where TModel : IModel
        where TDto : IDto
    {
        TModel ToModel(TDto dto);
        TDto ToDto(TModel model);
    }
}
