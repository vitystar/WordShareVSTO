using ModelAPI;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DALAPI
{
    public class BaseDAL<T> where T : class, new()
    {
        WordDBContext db = EFFactory.GetEF();
        public bool CreateDataBase() => db.Database.CreateIfNotExists();
        public bool AddEntity(T entity)
        {
            db.Set<T>().Add(entity);
            return db.SaveChanges() > 0;
        }


        public bool DeleteEntity(T entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
            return db.SaveChanges() > 0;
        }

        public bool EditEntity(T entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public IQueryable<T> LoadEntity(Expression<Func<T, bool>> whereLambda) => db.Set<T>().Where(whereLambda);

        public IQueryable<T> LoadEntityPage<S>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderbyLambda, bool asc)
        {
            IQueryable<T> entities = db.Set<T>().Where(whereLambda);
            totalCount = entities.Count();
            if (asc)
                entities = entities.OrderBy(orderbyLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            else
                entities = entities.OrderByDescending(orderbyLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return entities;
        }
    }
}
