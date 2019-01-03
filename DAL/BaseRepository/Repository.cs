using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal PercorsoCircolareEntities dbContext;
        internal DbSet<TEntity> dbSet;

        public Repository(PercorsoCircolareEntities context)
        {
            dbContext = context;
            dbSet = dbContext.Set<TEntity>();
        }


        /// <summary>
        /// Retrieve a record of the entity
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns></returns>
        public TEntity GetById(int id)
        {
            return dbContext.Set<TEntity>().Find(id);
        }

        /// <summary>
        /// Insert a record in the database
        /// </summary>
        /// <param name="entity">Record to insert in the database</param>
        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
            dbContext.SaveChanges();
        }

        /// <summary>
        /// Insert a record in the database and retrieve the record inserted
        /// </summary>
        /// <param name="entity">Record to insert in the database</param>
        /// <returns></returns>
        public TEntity InsertAndGet(TEntity entity)
        {
            dbSet.Add(entity);
            dbContext.SaveChanges();
            return entity;
        }

        /// <summary>
        /// Retrieve all the records of an entity in the database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>().AsEnumerable();
        }

        /// <summary>
        /// Update the record in the database
        /// </summary>
        /// <param name="entity">Record to update</param>
        public void Update(TEntity entity)
        {   
            dbSet.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        /// <summary>
        /// Delete a record from the database
        /// </summary>
        /// <param name="entity">Record to delete</param>
        public void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
            dbContext.SaveChanges();
        }

        /// <summary>
        /// Delete a record from the database by ID
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            TEntity entity = dbSet.Find(id);
            dbSet.Remove(entity);
            dbContext.SaveChanges();
        }
    }
}
