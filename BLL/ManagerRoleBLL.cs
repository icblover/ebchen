using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ZCJ.Model;
using ZCJ.DALFactory;
using ZCJ.IDAL;
using ZCJ.Model;
namespace ZCJ.BLL
{
	/// <summary>
	/// ManagerRoleBLL
	/// </summary>
	public partial class ManagerRoleBLL
	{
		private static readonly IManagerRoleDAL dal=DataAccess.CreateManagerRoleDAL();
		public ManagerRoleBLL()
		{}
		#region  BasicMethod
        
        /// <summary> 增加一条数据 </summary>
		public static int  Add(ZCJ.Model.ManagerRole model)
		{
			return dal.Add(model);
		}

		/// <summary> 更新一条数据 </summary>
		public static bool Update(ZCJ.Model.ManagerRole model)
		{
			return dal.Update(model);
		}

		/// <summary> 删除一条数据 </summary>
		public static bool Delete(int id)
		{
            return dal.Delete(Utility.Utils.SafeInt32(id));
		}
		
		/// <summary> 得到一个对象实体 </summary>
		public static ZCJ.Model.ManagerRole GetModel(int id)
		{
			return dal.GetModel(Utility.Utils.SafeInt32(id));
		}

		
		/// <summary> 获得数据列表 </summary>
        public static List<ZCJ.Model.ManagerRole> GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		
		/// <summary> 获得数据列表 </summary>
        public static List<ZCJ.Model.ManagerRole> GetAllList()
		{
			return GetList("");
		}
        #endregion  BasicMethod

		#region  ExtensionMethod
        /// <summary>
        /// 将操作对应id转换成中文
        /// </summary>
        /// <param name="list">id数据源</param>
        /// <param name="idlist">某个具体成员的权限id列表</param>
        /// <returns></returns>
        public static string ConvertOperateIdToName(List<SiteModule> list, object idlist)
        {
            List<string> id = idlist.ToString().Split(',').ToList();
            IEnumerable<string> queryNameList = from p in list where id.Contains(p.id.ToString()) select p.ModuleName;
            string nameList = "";
            foreach (var singleName in queryNameList)
            {
                nameList += singleName + ",";
            }
            if (nameList.Length>0)
            {
                nameList = nameList.Substring(0, nameList.Length - 1);
            }
            return nameList;
        }

        public static List<SelectListItem> GetManagerRoleList()
        {
            return Utility.Utils.DataReaderToSelect(dal.GetManagerRoleSource(""), "id", "name");
        }
		#endregion  ExtensionMethod
	}
}

