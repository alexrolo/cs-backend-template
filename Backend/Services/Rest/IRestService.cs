using Models.Entities.Models;

namespace Backend.Services.Rest
{
    public interface IRestService<Model> : IService
        where Model : IModel
    {
        Task<IEnumerable<Model>> GetAllAsync();
        Task<Model?> GetByIdAsync(int id);
        Task<Model> AddAsync(Model entityModel);
        Task<bool> UpdateAsync(int id, Model entityDto);
        Task<bool> DeleteAsync(int id);
    }
}
