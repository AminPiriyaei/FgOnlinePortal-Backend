using FgOnlinePortal.DataLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FgOnlinePortal.DataLayer.Repository
{
    public interface IGenericRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {

        /// <summary>
        /// get information tables
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetEntitiesQuery();
        /// <summary>
        /// get id tables
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        Task<TEntity> GetEntityById(long entityId);
        /// <summary>
        /// insert table
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddEntity(TEntity entity);
        /// <summary>
        /// update tables
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>

        void UpdateEntity(TEntity entity);
        /// <summary>
        /// remove tables
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void RemoveEntity(TEntity entity);

        /// <summary>
        /// get id used delete tables
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        Task RemoveEntity(long entityId);
        /// <summary>
        /// save 
        /// </summary>
        /// <returns></returns>
        Task SaveChanges();

    }
}
