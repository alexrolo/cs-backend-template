using Microsoft.EntityFrameworkCore;
using Models;
using Models.Entities.Models;

namespace Backend.Repositories.Rest
{
    public class RestRepository<Model> : IRestRepository<Model>
        where Model : class, IModel
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Model> _dbSet;

        public RestRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Model>();
        }

        public async Task<IEnumerable<Model>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Model?> GetByIdAsync(int id)
        {
            Model? entity = await _dbSet.FindAsync(id);
            return entity;
        }

        public async Task AddAsync(Model entityModel)
        {
            _dbSet.Add(entityModel);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(int id, Model entity)
        {
            Model? existingEntity = await _dbSet.FindAsync(id);
            if (existingEntity == null)
                return false;

            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Model? entity = await _dbSet.FindAsync(id);
            if (entity == null)
                return false;

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
