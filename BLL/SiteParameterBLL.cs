using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ZCJ.Model;
using ZCJ.IDAL;
using ZCJ.DALFactory;
using ZCJ.Utility;
using Webdiyer.WebControls.Mvc;

namespace ZCJ.BLL
{
    public class SiteParameterBLL
    {
        private static readonly ISiteParameterDAL dal = DataAccess.CreateSiteParameterDAL();
        
        public static int Create(SiteParameter model)
        {
            return dal.Create(model);
        }

        public static int Update(SiteParameter model)
        {
            return dal.Update(model);
        }

        public static bool Delete(int id)
        {
            return dal.Delete(Utils.SafeInt32(id));
        }

        public static SiteParameter GetModel(int id)
        {
            return dal.GetModel(id);
        }

        public static List<SiteParameter> GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary> 分页数据列表 </summary>
        /// <param name="paramterType">类型筛选条件</param>
        /// <param name="pageIndex">当前页数索引</param>
        /// <returns></returns>
        public static PagedList<SiteParameter> GetPagedList(string paramterType,int pageIndex)
        {
            StringBuilder where=new StringBuilder();
            if (paramterType!="0")
            {
                where.Append(" AND ParameterType='");
                where.Append(paramterType);
                where.Append("' ");
            }
            return dal.GetList(where.ToString()).ToPagedList(pageIndex, 15);
        }

        /// <summary> 参数类型列表 </summary>
        /// <returns></returns>
        public static List<SelectListItem> GetParameterTypeList()
        {
            return Utils.DataReaderToSelect(dal.GetParameterTypeList(), "ParameterType", "ParameterType");
        }

        /// <summary>
        /// 根据参数类型，加载相应的列表
        /// </summary>
        /// <param name="parameterType"></param>
        /// <returns></returns>
        public static List<SelectListItem> GetParameterList(string parameterType)
        {
            return Utils.DataReaderToSelect(dal.GetParameterList(parameterType), "id", "ParameterName");
        }
    }
}
