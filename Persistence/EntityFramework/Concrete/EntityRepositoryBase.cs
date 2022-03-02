using Domain.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityFramework.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityFramework.Concrete
{
    public class EntityRepositoryBase<TEntity, TContext> : IEntityRepositoryBase<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        protected TContext _context;
        public EntityRepositoryBase(TContext context)
        {
            _context = context;
        }
        public TEntity Add(TEntity entity)
        {
            return _context.Add(entity).Entity;
        }

        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> expression)
        {
            return _context.Set<TEntity>().FirstOrDefault(expression);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> expression = null)
        {
            return expression == null ? _context.Set<TEntity>().AsNoTracking() : _context.Set<TEntity>().Where(expression).AsNoTracking();
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            return expression == null ? await _context.Set<TEntity>().ToListAsync() :
                 await _context.Set<TEntity>().Where(expression).ToListAsync();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public TEntity Update(TEntity entity)
        {
            _context.Update(entity);
            return entity;
        }
    }
}
