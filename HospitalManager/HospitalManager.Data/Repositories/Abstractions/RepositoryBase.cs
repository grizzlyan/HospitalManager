using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Data.Repositories.Abstractions
{
    public abstract class RepositoryBase<TEntity, TKey>
        where TEntity: class, IEntity<TKey>
    {
        private readonly ApplicationDbContext _ctx;
        private DbSet<TEntity> _dbSet;

        public RepositoryBase(ApplicationDbContext context)
        {
            _ctx = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> Get (TKey id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<IEnumerable<TEntity>> Get (Expression<Func<TEntity,bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> Get()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task Add(TEntity entity, bool isSaveChangesRequired = true)
        {
            await _dbSet.AddAsync(entity);
            if(isSaveChangesRequired)
            {
                await _ctx.SaveChangesAsync();
            }
        }

        public async Task Delete(TKey id, bool isSaveChangesRequired = true)
        {
            var entityToDelete = await _dbSet.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if(entityToDelete!=null)
            {
                _dbSet.Remove(entityToDelete);

                if(isSaveChangesRequired)
                {
                    await _ctx.SaveChangesAsync();
                }
            }
        }

        public virtual async Task Update(TEntity entity, bool isSaveChangesRequired = true)
        {
            _ctx.Entry(entity).State = EntityState.Modified;

            if(isSaveChangesRequired)
            {
                await _ctx.SaveChangesAsync();
            }
        }
    }
}
