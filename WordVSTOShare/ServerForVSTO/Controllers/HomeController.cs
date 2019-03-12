using ModelAPI;
using ServerForVSTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Expressions;

namespace ServerForVSTO.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            #region 初始化变量
            ViewBag.Title = "Home Page";
            int pageIndex = 1;
            int totalCount;
            Func<ParameterExpression, BinaryExpression> whereLambda;
            IQueryable<BaseTemplet> templets;
            int.TryParse(Request["pageIndex"], out pageIndex);
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            screenResult.PageIndex = pageIndex;
            #endregion

            #region 判断筛选选项，动态构造lambda表达式
            if (userInfo == null)
                whereLambda = (parameter) =>
                {
                    BinaryExpression b = Expression.Equal(Expression.PropertyOrField(parameter, "Accessibility"), Expression.Constant(Accessibility.Public));
                    return b;
                };
            else if (screenResult.Accessable == Accessibility.Private)
                whereLambda = (parameter) =>
                {
                    BinaryExpression query1 = Expression.Equal(Expression.PropertyOrField(parameter, "Accessibility"), Expression.Constant(Accessibility.Private));
                    BinaryExpression query2 = Expression.Equal(Expression.PropertyOrField(parameter, "User"), Expression.Constant(userInfo));
                    return Expression.And(query1, query2);
                };
            else if (screenResult.Accessable == Accessibility.Protected)
                whereLambda = (parameter) =>
                {
                    BinaryExpression query1 = Expression.Equal(Expression.PropertyOrField(parameter, "Accessibility"), Expression.Constant(Accessibility.Protected));
                    BinaryExpression query2 = Expression.Equal(Expression.PropertyOrField(parameter, "Organization"), Expression.Constant(userInfo.Organization));
                    return Expression.And(query1, query2);
                };
            else
                whereLambda = (parameter) =>
                {
                    BinaryExpression query1 = Expression.Equal(Expression.PropertyOrField(parameter, "Accessibility"), Expression.Constant(Accessibility.Public));
                    BinaryExpression query2_1 = Expression.Equal(Expression.PropertyOrField(parameter, "Accessibility"), Expression.Constant(Accessibility.Private));
                    BinaryExpression query2_2 = Expression.Equal(Expression.PropertyOrField(parameter, "User"), Expression.Constant(userInfo));
                    BinaryExpression query2 = Expression.And(query2_1, query2_2);
                    BinaryExpression query3_1 = Expression.Equal(Expression.PropertyOrField(parameter, "Accessibility"), Expression.Constant(Accessibility.Protected));
                    BinaryExpression query3_2 = Expression.Equal(Expression.PropertyOrField(parameter, "Organization"), Expression.Constant(userInfo.Organization));
                    BinaryExpression query3 = Expression.And(query3_1, query3_2);
                    BinaryExpression b = Expression.Or(query1, query2);
                    return Expression.Or(b, query3);
                };

            #endregion

            #region 判断模板类型并取值
            if (screenResult.TempletType == TempletType.PPTTemplet)
                templets = ServiceSessionFactory.ServiceSession.PPTService.LoadEntityPage(pageIndex, 6, out totalCount, MakeWhereLambda<PPTTemplet>(whereLambda), w => w.TempletName, true);
            else if (screenResult.TempletType == TempletType.ExcelTemplet)
                templets = ServiceSessionFactory.ServiceSession.ExcelService.LoadEntityPage(pageIndex, 6, out totalCount, MakeWhereLambda<ExcelTemplet>(whereLambda), w => w.TempletName, true);
            else if (screenResult.TempletType == TempletType.ImageTemplet)
                templets = ServiceSessionFactory.ServiceSession.ImageService.LoadEntityPage(pageIndex, 6, out totalCount, MakeWhereLambda<ImageTemplet>(whereLambda), w => w.TempletName, true);
            else if(screenResult.TempletType == TempletType.AudioTemplet)
                templets = ServiceSessionFactory.ServiceSession.AudioService.LoadEntityPage(pageIndex, 6, out totalCount, MakeWhereLambda<AudioTemplet>(whereLambda), w => w.TempletName, true);
            else if(screenResult.TempletType == TempletType.VideoTemplet)
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

            #region 处理返回值
            ViewData["Templets"] = templets;
            int pageCount = Convert.ToInt32(Math.Ceiling((double)(totalCount / 6)));
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            ViewData["pageCount"] = pageCount;
            ViewData["pageIndex"] = pageIndex;
            #endregion

            return View();
        }

        public ActionResult OrganizationManager()
        {
            return View();
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
