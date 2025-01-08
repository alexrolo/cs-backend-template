using Models.Entities.Models;

namespace Backend.Repositories.Rest
{
    public interface IRestRepository<Model> : IRepository
        where Model : IModel
    {
        Task<IEnumerable<Model>> GetAllAsync();
        Task<Model?> GetByIdAsync(int id);
        Task<Model> AddAsync(Model entityModel);
        Task<bool> UpdateAsync(int id, Model entity);
        Task<bool> DeleteAsync(int id);
    }
}
