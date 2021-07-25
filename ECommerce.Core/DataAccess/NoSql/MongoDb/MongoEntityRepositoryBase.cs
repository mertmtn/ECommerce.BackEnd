using ECommerce.Core.Entities; 
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ECommerce.Core.DataAccess.NoSql.MongoDb
{
    public class MongoEntityRepositoryBase<TEntity> : IEntityRepository<TEntity> 
        where TEntity : class, IEntity, new()
    {
        protected readonly IMongoDbContext Context;
        protected IMongoCollection<TEntity> DbSet;

        protected MongoEntityRepositoryBase(IMongoDbContext context)
        {
            Context = context;
            DbSet = Context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public void Add(TEntity entity)
        {
            DbSet.InsertOneAsync(entity);
        }

        public void Delete(TEntity entity, Expression<Func<TEntity, bool>> filter)
        {
            DbSet.DeleteOne(Builders<TEntity>.Filter.Where(filter));
        }
        
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return DbSet.Find(Builders<TEntity>.Filter.Where(filter)).FirstOrDefault();
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return DbSet.Find(Builders<TEntity>.Filter.Empty).ToList();
        }       

        public void Update(TEntity entity,Expression<Func<TEntity, bool>> filter)
        {
             DbSet.FindOneAndReplace(filter, entity);
        } 
    }
}
