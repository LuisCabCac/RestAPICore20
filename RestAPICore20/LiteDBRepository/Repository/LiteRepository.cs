using System;
using System.Collections.Generic;
using LiteDB;
using System.Linq.Expressions;
using System.Linq;
using RestAPICore20.NoSQL.LiteDB.Context;

namespace RestAPICore20.NoSQL.LiteDB.Repository
{
    public class LiteRepository<T> : INoSQLRepository<T>
    {

        protected internal LiteCollection<T> collection;

        public LiteRepository()
        {
            this.collection = LiteDBInstance<T>.Instance.GetMongoDatabase("collection");

        }

        public bool Save(T param)
        {
            this.collection.Insert(param);
            return true;
        }

        public void Save(IEnumerable<T> param)
        {
            collection.InsertBulk(param);
        }

        public T Update(T entity)
        {
            this.collection.Update(entity);
            return entity;
        }

        public void Update(IEnumerable<T> entities)
        {
            this.collection.Update(entities);
        }

        public T GetOne(Expression<Func<T, bool>> predicate)
        {
            return this.collection.FindOne(predicate);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return this.collection.Find(predicate).ToList();
        }

        public IEnumerable<T> GetTop(Expression<Func<T, bool>> predicate, int top)
        {
            return this.collection.Find(predicate, limit: top).ToList();
        }

        public long Count(Expression<Func<T, bool>> predicate)
        {
            return this.collection.Find(predicate)?.Count() ?? 0;
        }

        public bool Exists(Expression<Func<T, bool>> predicate)
        {
            return  this.collection.FindOne(predicate) != null;
        }
    }
}
