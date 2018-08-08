using FinPort.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinPort.Data
{
    public partial class EfRepository<T> : IRepository<T> where T : BaseEntity
    {

        private readonly IDbContext _dbContext;
        private DbSet<T> _entities;

        #region Ctor

        public EfRepository(IDbContext context)
        {
            this._dbContext = context;
        }

        #endregion

        #region Methods

        public void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));
                Entities.Remove(entity);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));
                Entities.RemoveRange(entities);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public virtual T GetById(object id)
        {
            return Entities.Find(id);
        }

        public virtual T Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));
                Entities.Add(entity);
                _dbContext.SaveChanges();

                return entity;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public virtual void Insert(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));
                Entities.AddRange(entities);

                //foreach (var entity in entities)
                //    Entities.Add(entity);

                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public virtual void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public virtual void Update(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #endregion

        #region Properties

        public virtual IQueryable<T> Table
        {
            get
            {
                return Entities;
            }
        }

        protected virtual DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _dbContext.Set<T>();
                return _entities;
            }
        }

        #endregion
    }
}
