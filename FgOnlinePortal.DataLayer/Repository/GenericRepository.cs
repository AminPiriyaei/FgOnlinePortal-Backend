
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//***
using FgOnlinePortal.DataLayer.Common;
using FgOnlinePortal.DataLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace FgOnlinePortal.DataLayer.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        #region Field
        private readonly FgOnlinePortalDbContext context;
        private readonly DbSet<TEntity> dbSet;
        #endregion

        #region Counstractor
        public GenericRepository(FgOnlinePortalDbContext Context)
        {
            this.context = Context;
            this.dbSet = this.context.Set<TEntity>();
        }
        #endregion
        public IQueryable<TEntity> GetEntitiesQuery()
        {
            return dbSet.AsQueryable();
        }

        public async Task<TEntity> GetEntityById(long entityId)
        {
            return await dbSet.SingleOrDefaultAsync(e => e.Id == entityId);
        }

        public async Task AddEntity(TEntity entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.LastUpdateDate = entity.CreateDate;
            await dbSet.AddAsync(entity);

        }


        public void RemoveEntity(TEntity entity)
        {
            entity.IsDelete = true;
            UpdateEntity(entity);
            
        }

        public async Task RemoveEntity(long entityId)
        {
            var entity = await GetEntityById(entityId);
            RemoveEntity(entity);

        }
        public void UpdateEntity(TEntity entity)
        {
            entity.LastUpdateDate = DateTime.Now;
            dbSet.Update(entity);
        }
        public async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context?.Dispose();
        }
    }
}
