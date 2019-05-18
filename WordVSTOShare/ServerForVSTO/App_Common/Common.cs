using ModelAPI;
using ServerForVSTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ServerForVSTO.App_Common
{
    public class Common
    {
        public IQueryable<BaseTemplet> GetScreenResult(UserForTemplet user, ScreenResultModel screenResult, out int totalCount)
        {
            #region 初始化变量
            Func<ParameterExpression, BinaryExpression> whereLambda;
            IQueryable<BaseTemplet> templets;
            int pageIndex = screenResult.PageIndex;
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            #endregion

            #region 判断筛选选项，动态构造lambda表达式
            if (user == null)
                #region p=>p.Accessibility == Accessibility.Public
                whereLambda = (parameter) =>
                {
                    BinaryExpression b = Expression.Equal(Expression.PropertyOrField(parameter, "Accessibility"), Expression.Constant(Accessibility.Public));
                    return b;
                };
            #endregion
            else if (screenResult.Accessable == Accessibility.Private)
                #region p=>p.Accessibility == Accessibility.Private && p.User.ID == userInfo.ID
                whereLambda = (parameter) =>
                {
                    //p=>p.Accessibility == Accessibility.Private
                    BinaryExpression query1 = Expression.Equal(Expression.PropertyOrField(parameter, "Accessibility"), Expression.Constant(Accessibility.Private));
                    //p.User.ID == userInfo.ID
                    MemberExpression e = Expression.PropertyOrField(parameter, "User");
                    MemberExpression e2 = Expression.PropertyOrField(e, "ID");
                    BinaryExpression query2 = Expression.Equal(e2, Expression.Constant(user.ID));
                    return Expression.And(query1, query2);
                };
            #endregion
            else if (user.OrganizationID == null || user.OrganizationID == new Guid())
                #region p=>p.Accessibility == Accessibility.Public || (p.Accessibility == Accessibility.Private&&p.User.ID == userInfo.ID)
                whereLambda = (parameter) =>
                {
                    //p=>p.Accessibility == Accessibility.Public
                    BinaryExpression query1 = Expression.Equal(Expression.PropertyOrField(parameter, "Accessibility"), Expression.Constant(Accessibility.Public));
                    //p.Accessibility == Accessibility.Private
                    BinaryExpression query2_1 = Expression.Equal(Expression.PropertyOrField(parameter, "Accessibility"), Expression.Constant(Accessibility.Private));
                    MemberExpression e = Expression.PropertyOrField(parameter, "User");
                    MemberExpression e2 = Expression.PropertyOrField(e, "ID");
                    //p.User.ID == userInfo.ID
                    BinaryExpression query2_2 = Expression.Equal(e2, Expression.Constant(user.ID));
                    //p.Accessibility == Accessibility.Private&&p.User.ID == userInfo.ID
                    BinaryExpression query2 = Expression.And(query2_1, query2_2);
                    return Expression.Or(query1, query2);
                };
            #endregion
            else if (screenResult.Accessable == Accessibility.Protected)
                #region p=>p.Accessibility == Accessibility.Protected && p.Organization.ID == userInfo.Organization.ID
                whereLambda = (parameter) =>
                {
                    //p=>p.Accessibility == Accessibility.Protected
                    BinaryExpression query1 = Expression.Equal(Expression.PropertyOrField(parameter, "Accessibility"), Expression.Constant(Accessibility.Protected));
                    MemberExpression e = Expression.PropertyOrField(parameter, "Organization");
                    MemberExpression e2 = Expression.PropertyOrField(e, "ID");
                    //p.Organization.ID == userInfo.Organization.ID
                    BinaryExpression query2 = Expression.Equal(e2, Expression.Constant(user.OrganizationID));
                    return Expression.And(query1, query2);
                };
            #endregion
            else
                #region p.Accessibility == Accessibility.Public || (p.Accessibility == Accessibility.Private && p.User.ID == userInfo.ID) || (p.Accessibility == Accessibility.Protected &&p.Organization.ID == userInfo.Organization.ID )
                whereLambda = (parameter) =>
                {
                    //p=>p.Accessibility == Accessibility.Public
                    BinaryExpression query1 = Expression.Equal(Expression.PropertyOrField(parameter, "Accessibility"), Expression.Constant(Accessibility.Public));
                    //p.Accessibility == Accessibility.Private
                    BinaryExpression query2_1 = Expression.Equal(Expression.PropertyOrField(parameter, "Accessibility"), Expression.Constant(Accessibility.Private));
                    MemberExpression e = Expression.PropertyOrField(parameter, "User");
                    MemberExpression e2 = Expression.PropertyOrField(e, "ID");
                    //p.User.ID == userInfo.ID
                    BinaryExpression query2_2 = Expression.Equal(e2, Expression.Constant(user.ID));
                    //p.Accessibility == Accessibility.Private && p.User.ID == userInfo.ID
                    BinaryExpression query2 = Expression.And(query2_1, query2_2);
                    //p.Accessibility == Accessibility.Protected
                    BinaryExpression query3_1 = Expression.Equal(Expression.PropertyOrField(parameter, "Accessibility"), Expression.Constant(Accessibility.Protected));
                    e = Expression.PropertyOrField(parameter, "Organization");
                    e2 = Expression.PropertyOrField(e, "ID");
                    //p.Organization.ID == userInfo.Organization.ID
                    BinaryExpression query3_2 = Expression.Equal(e2, Expression.Constant(user.OrganizationID));
                    //p.Accessibility == Accessibility.Protected &&p.Organization.ID == userInfo.Organization.ID 
                    BinaryExpression query3 = Expression.And(query3_1, query3_2);
                    //p.Accessibility == Accessibility.Public || (p.Accessibility == Accessibility.Private && p.User.ID == userInfo.ID)
                    BinaryExpression b = Expression.Or(query1, query2);
                    return Expression.Or(b, query3);
                };
            #endregion

            #endregion

            #region 判断模板类型并取值
            if (screenResult.TempletType == TempletType.PPTTemplet)
                templets = ServiceSessionFactory.ServiceSession.PPTService.LoadEntityPage(pageIndex, 6, out totalCount, MakeWhereLambda<PPTTemplet>(whereLambda), w => w.TempletName, true);
            else if (screenResult.TempletType == TempletType.ExcelTemplet)
                templets = ServiceSessionFactory.ServiceSession.ExcelService.LoadEntityPage(pageIndex, 6, out totalCount, MakeWhereLambda<ExcelTemplet>(whereLambda), w => w.TempletName, true);
            else if (screenResult.TempletType == TempletType.ImageTemplet)
                templets = ServiceSessionFactory.ServiceSession.ImageService.LoadEntityPage(pageIndex, 6, out totalCount, MakeWhereLambda<ImageTemplet>(whereLambda), w => w.TempletName, true);
            else if (screenResult.TempletType == TempletType.AudioTemplet)
                templets = ServiceSessionFactory.ServiceSession.AudioService.LoadEntityPage(pageIndex, 6, out totalCount, MakeWhereLambda<AudioTemplet>(whereLambda), w => w.TempletName, true);
            else if (screenResult.TempletType == TempletType.VideoTemplet)
                templets = ServiceSessionFactory.ServiceSession.VideoService.LoadEntityPage(pageIndex, 6, out totalCount, MakeWhereLambda<VideoTemplet>(whereLambda), w => w.TempletName, true);
            else
                templets = ServiceSessionFactory.ServiceSession.WordTempletService.LoadEntityPage(pageIndex, 6, out totalCount, MakeWhereLambda<WordTemplet>(whereLambda), w => w.TempletName, true);
            #endregion

            #region 判断搜索选项
            if (!string.IsNullOrWhiteSpace(screenResult.Search))
            {
                templets = from t in templets
                           where (t.TempletName.Contains(screenResult.Search))
                           select t;
                totalCount = templets.Count();
            }
            #endregion

            return templets;
        }


        /// <summary>
        /// 从lambda动态条件创建泛型lambda的where表达式
        /// </summary>
        /// <typeparam name="T">where表达式的参数</typeparam>
        /// <param name="lambda">创建动态表达式的委托</param>
        /// <returns>where表达式</returns>
        private Expression<Func<T, bool>> MakeWhereLambda<T>(Func<ParameterExpression, BinaryExpression> lambda) where T : class, new()
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T));
            BinaryExpression b = lambda(parameter);
            return Expression.Lambda<Func<T, bool>>(b, parameter);
        }
    }
}