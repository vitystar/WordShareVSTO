using DALAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLLAPI
{
    public class BaseService<T> where T : class, new()
    {
        protected IBaseDAL<T> CurrentDal { get; set; }

        public BaseService(IBaseDAL<T> currentDal)
        {
            CurrentDal = currentDal;
        }

        public IQueryable<T> LoadEntity(Expression<Func<T, bool>> whereLambda) => CurrentDal.LoadEntity(whereLambda);


        public IQueryable<T> LoadEntityPage<S>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderbyLambda, bool asc) => CurrentDal.LoadEntityPage<S>(pageIndex, pageSize, out totalCount, whereLambda, orderbyLambda, asc);
        
        public bool DeleteEntity(T entity) => CurrentDal.DeleteEntity(entity);

        public virtual bool EditEntity(T entity) => CurrentDal.EditEntity(entity);

        public bool AddEntity(T entity) => CurrentDal.AddEntity(entity);
    }
}
