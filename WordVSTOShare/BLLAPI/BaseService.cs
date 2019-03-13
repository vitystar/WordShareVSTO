using DALAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLLAPI
{
    public abstract class BaseService<T> where T : class, new()
    {
        protected IBaseDAL<T> CurrentDal { get; set; }

        public BaseService(IBaseDAL<T> currentDal)
        {
            CurrentDal = currentDal;
        }

        public IQueryable<T> LoadEntity(Expression<Func<T, bool>> whereLambda) => CurrentDal.LoadEntity(whereLambda);


        public IQueryable<T> LoadEntityPage<S>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderbyLambda, bool asc) => CurrentDal.LoadEntityPage<S>(pageIndex, pageSize, out totalCount, whereLambda, orderbyLambda, asc);

        public bool DeleteEntity(T entity) => CurrentDal.DeleteEntity(entity);

        public abstract bool EditEntity(T entity);

        public bool AddEntity(T entity) => CurrentDal.AddEntity(entity);

        /// <summary>
        /// 通过查询改写数据以达到同一上下文写入
        /// </summary>
        /// <param name="wherelambda">查询表达式</param>
        /// <param name="EditEntityLambda">改写的内容，参数为需要改写的对象，返回值为改写后的对象</param>
        /// <returns>改写结果</returns>
        protected bool EditEntityWithSelect(Expression<Func<T, bool>> wherelambda, Func<T, T> EditEntityLambda)
        {
            T temp = LoadEntity(wherelambda).FirstOrDefault();
            temp = EditEntityLambda(temp);
            return CurrentDal.EditEntity(temp);
        }
    }
}
