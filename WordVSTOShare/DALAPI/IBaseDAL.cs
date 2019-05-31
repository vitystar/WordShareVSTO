using System;
using System.Linq;
using System.Linq.Expressions;

namespace DALAPI
{
    /// <summary>
    /// 数据操作接口
    /// </summary>
    /// <typeparam name="T">要操作的数据类型</typeparam>
    public interface IBaseDAL<T>where T:class,new()
    {
        /// <summary>
        /// 创建数据库
        /// </summary>
        /// <returns>数据库创捷结果</returns>
        bool CreateDataBase();
        /// <summary>
        /// 数据查询
        /// </summary>
        /// <param name="whereLambda">查询条件</param>
        /// <returns>数据集合</returns>
        IQueryable<T> LoadEntity(Expression<Func<T, bool>> whereLambda);
        /// <summary>
        /// 分页查询数据
        /// </summary>
        /// <typeparam name="T">排序类型</typeparam>
        /// <param name="pageIndex">查询的页数</param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="totalCount">总记录数</param>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="orderbyLambda">排序条件</param>
        /// <param name="asc">升降顺序</param>
        /// <returns>数据集合</returns>
        IQueryable<T> LoadEntityPage<S>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderbyLambda, bool asc);
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="entity">需要删除的数据实体</param>
        /// <returns>操作完成情况</returns>
        bool DeleteEntity(T entity);
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="entity">修改后的数据实体</param>
        /// <returns>操作完成情况</returns>
        bool EditEntity(T entity);
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="entity">新增的数据实体</param>
        /// <returns>操作完成情况</returns>
        bool AddEntity(T entity);
    }
}
