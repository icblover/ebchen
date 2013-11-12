using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using ZCJ.Utility;
using ZCJ.IDAL;
using ZCJ.DALFactory;
using ZCJ.Model;
using Webdiyer.WebControls.Mvc;

namespace ZCJ.BLL
{
    /// <summary>
    /// 协会信息
    /// </summary>
    public class AssociationBLL
    {
        private static readonly IAssociationDAL dal = DataAccess.CreateAssociationDAL();

        public static int Create(Association model)
        {
            return dal.Create(model);
        }
        public static int Update(Association model)
        {
            return dal.Update(model);
        }

        public static bool Delete(int id)
        {
            return dal.Delete(id);
        }

        public static Association GetModel(int id)
        {
            return dal.GetModel(id);
        }

        public static List<Association> GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary> 进入查询界面显示数据 </summary>
        /// <returns></returns>
        public static PagedList<Association> GetPagedList(int id)
        {
            return GetPagedList("", "0", id);
        }
        /// <summary> 查询结果页面  </summary>
        /// <param name="keyword">学校名称</param>
        /// <param name="AssociationType">学校类型</param>
        /// <param name="pageIndex">页数</param>
        /// <returns></returns>
        public static PagedList<Association> GetPagedList(string keyword,string AssociationType,int pageIndex)
        {
            StringBuilder where=new StringBuilder();
            if (keyword!="")
            {
                where.Append(" AND AssociationName LIKE '%");
                where.Append(keyword);
                where.Append("%' ");
            }
            if (AssociationType!="0")
            {
                where.Append(" AND AssociationType=");
                where.Append(AssociationType);
            }
            return GetList(where.ToString()).ToPagedList(pageIndex, 20);
        }

        /// <summary> 获取协会类型 </summary>
        /// <returns></returns>
        public static List<SelectListItem> GetAssociationType()
        {
            return Utils.DataReaderToSelect(dal.GetAssociationType(), "id", "ParameterName");
        }
    }
}
