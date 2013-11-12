using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;
using ZCJ.Utility;
using ZCJ.Model;
using ZCJ.DALFactory;
using ZCJ.IDAL;
namespace ZCJ.BLL
{
	/// <summary>
	/// SiteModuleBLL
	/// </summary>
	public partial class SiteModuleBLL
	{
		private readonly static ISiteModuleDAL dal=DataAccess.CreateSiteModuleDAL();
		
		#region  BasicMethod

		/// <summary> 增加一条数据 </summary>
		public static  int  Add(ZCJ.Model.SiteModule model)
		{
			return dal.Add(model);
		}

		/// <summary> 更新一条数据 </summary>
		public static  bool Update(ZCJ.Model.SiteModule model)
		{
			return dal.Update(model);
		}

		/// <summary> 删除一条数据 </summary>
		public static  bool Delete(int id)
		{
			
			return dal.Delete(id);
		}
        
		/// <summary> 得到一个对象实体 </summary>
		public static  ZCJ.Model.SiteModule GetModel(int id)
		{
			return dal.GetModel(id);
		}
        
        /// <summary> 获得数据列表 </summary>
        public static List<ZCJ.Model.SiteModule> GetList(string strWhere)
		{
            return dal.GetList(strWhere);
		}
		
		#endregion  BasicMethod

		#region  ExtensionMethod
        /// <summary> 取出所有模块（不含子栏目） </summary>
        /// <returns></returns>
	    public static List<ZCJ.Model.SiteModule> GetParentModuleList()
	    {
            return GetList(" ParentId=0 ");
	    }

        /// <summary> 取出权限对应所有父级模块 </summary>
        /// <returns></returns>
        public static List<ZCJ.Model.SiteModule> GetAuthorityParentModuleList(int roleId)
        {
            string moduleId = DataAccess.CreateManagerRoleDAL().GetModel(roleId).OperateList;
            return GetList(" IsClosed=0 AND ParentId=0 AND ID IN (" + moduleId + ")");
        }

        /// <summary> 取出模块的子模块 </summary>
        /// <param name="ParentId"></param>
        /// <returns></returns>
        public static List<ZCJ.Model.SiteModule> GetSonModuleList(int ParentId)
        {
            return GetList(string.Format("ParentId={0} ", ParentId));
        }

        /// <summary> 设置html.dropdownlist的数据源 </summary>
        /// <returns></returns>
	    public static List<SelectListItem> GetSelectListItem()
	    {
            return Utils.DataReaderToSelect(dal.GetDataReaderList(" ParentId=0 "), "id", "ModuleName","-- 根模块 --");
	    }

        /// <summary> 获取所有可以设定权限的列表 </summary>
        /// <returns></returns>
        public static List<ZCJ.Model.SiteModule> GetOperateListItem()
        {
            return dal.GetOperateListItem();
        }
        
	    #endregion  ExtensionMethod
	}
}