using System;
using System.Data;
using System.Collections.Generic;
using ZCJ.Utility;
using ZCJ.Model;
using ZCJ.DALFactory;
using ZCJ.IDAL;
namespace ZCJ.BLL
{
	/// <summary>
	/// SiteManagerBLL
	/// </summary>
	public partial class SiteManagerBLL
	{
		private static readonly ISiteManagerDAL dal=DataAccess.CreateSiteManagerDAL();
		public SiteManagerBLL()
		{}

		#region  BasicMethod

		/// <summary> 是否存在该记录 </summary>
		public static bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary> 增加一条数据 </summary>
		public static int  Add(ZCJ.Model.SiteManager model)
		{
		    model.PassWord = Utils.MD5(model.PassWord);
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(ZCJ.Model.SiteManager model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int id)
		{
			
			return dal.Delete(id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static ZCJ.Model.SiteManager GetModel(object id)
		{

            return dal.GetModel(Utils.SafeInt32(id));
		}
        
		/// <summary> 获得数据列表 </summary>
        public static List<SiteManager> GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

		/// <summary> 获得数据列表 </summary>
        public static List<SiteManager> GetAllList()
		{
			return GetList("");
		}

		#endregion  BasicMethod
		#region  ExtensionMethod
        public static List<SiteManager> GetAllManagerList()
        {
            return dal.GetList("");
        }

        /// <summary> 检验原密码是否正确 </summary>
        /// <param name="userProvideStr">用户输入密码</param>
        /// <param name="oldPassword">原密码md5加密后字符串</param>
        /// <returns></returns>
        public static bool IsOldPassword(string userProvideStr,string oldPassword)
        {
            if(Utils.MD5(userProvideStr)==oldPassword)
            {
                return true;
            }
            return false;
        }
		#endregion  ExtensionMethod
	}
}

