using DomainObjects;
using DomainObjects.Entities;
using Microsoft.EntityFrameworkCore;

namespace DomainObjects.Repositories
{
    public interface IDbRepository<TEntity> where TEntity : class
    {
        Task<int> Create(TEntity entity);
        Task<TEntity> CreateO(TEntity entity);
        IQueryable<TEntity> Get(int id);
        IQueryable<TEntity> Search();
        Task Update(TEntity entity);
    }

    public class DbRepository<TEntity> : IDbRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly TiContext _db;

        public DbRepository(TiContext db)
        {
            _db = db;
        }

        public async Task<int> Create(TEntity entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            entity.UpdatedDate = DateTime.UtcNow;

            _db.Set<TEntity>().Add(entity);
            await _db.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<TEntity> CreateO(TEntity entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            entity.UpdatedDate = DateTime.UtcNow;

            _db.Set<TEntity>().Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public IQueryable<TEntity> Get(int id)
        {
            return _db.Set<TEntity>().AsNoTracking().Where(_ => _.Id == id).AsQueryable();
        }

        public IQueryable<TEntity> Search()
        {
            return _db.Set<TEntity>().AsNoTracking().AsQueryable();
        }
        public async Task Update(TEntity entity)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            _db.Set<TEntity>().Update(entity);
            await _db.SaveChangesAsync();
        }
    }
}
