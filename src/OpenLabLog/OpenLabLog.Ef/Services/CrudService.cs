using Microsoft.EntityFrameworkCore;
using OpenLabLog.Core.Contracts.Models;
using OpenLabLog.Core.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLabLog.Ef.Services
{
    public class CrudService<TContext, TEntity> : IRepositoryService<TEntity>
        where TContext : DbContext
        where TEntity : class, IEntity
    {
        protected TContext context;
        public CrudService(TContext context)
        {
            this.context = context;
        }
        public async Task<TEntity?> GetAsync(long id)
        {
            return await context.Set<TEntity>().Where(x => x.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await context.Set<TEntity>().ToListAsync().ConfigureAwait(false);
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(long id)
        {
            var originalEntity = await context.Set<TEntity>().Where(a => a.Id == id).FirstOrDefaultAsync();
            if (originalEntity != null)
            {
                context.Set<TEntity>().Remove(originalEntity);
                await context.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task UpdateAsync(TEntity entity)
        {
            if (entity.Id != 0)
            {
                var originalEntity = await context.Set<TEntity>().Where(a => a.Id == entity.Id).FirstOrDefaultAsync();
                if (originalEntity != null)
                {
                    context.Entry(originalEntity).CurrentValues.SetValues(entity);
                    await context.SaveChangesAsync();
                }
                else
                    throw new ArgumentOutOfRangeException(nameof(entity), "Entity is not found in the database. Cannot update it.");
            }
        }
    }
    public class CrudContextFactoryService<TContext, TEntity> : IRepositoryService<TEntity>
        where TContext : DbContext
        where TEntity : class, IEntity
    {
        protected IDbContextFactory<TContext> _dbContextFactory;
        public CrudContextFactoryService(IDbContextFactory<TContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<TEntity?> GetAsync(long id)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.Set<TEntity>().Where(x => x.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.Set<TEntity>().ToListAsync().ConfigureAwait(false);
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(long id)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            var originalEntity = await context.Set<TEntity>().Where(a => a.Id == id).FirstOrDefaultAsync();
            if (originalEntity != null)
            {
                context.Set<TEntity>().Remove(originalEntity);
                await context.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task UpdateAsync(TEntity entity)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            if (entity.Id != 0)
            {
                var originalEntity = await context.Set<TEntity>().Where(a => a.Id == entity.Id).FirstOrDefaultAsync();
                if (originalEntity != null)
                {
                    context.Entry(originalEntity).CurrentValues.SetValues(entity);
                    await context.SaveChangesAsync();
                }
                else
                    throw new ArgumentOutOfRangeException(nameof(entity), "Entity is not found in the database. Cannot update it.");
            }
        }
    }
}
