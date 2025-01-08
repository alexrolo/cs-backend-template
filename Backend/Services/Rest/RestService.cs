using Backend.Repositories.Rest;
using Models.Entities.DTOs;
using Models.Entities.Models;

namespace Backend.Services.Rest
{
    public class RestService<Model>(IRestRepository<Model> repository) : IRestService<Model>
        where Model : IModel
    {
        private readonly IRestRepository<Model> _repository = repository;

        public Task<Model> AddAsync(Model entityModel)
        {
            return _repository.AddAsync(entityModel);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }

        public Task<IEnumerable<Model>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<Model?> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task<bool> UpdateAsync(int id, Model entityDto)
        {
            return _repository.UpdateAsync(id, entityDto);
        }
    }
}
