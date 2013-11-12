using System;
using System.Data;
using System.Collections.Generic;

using ZCJ.Model;
using ZCJ.DALFactory;
using ZCJ.IDAL;
namespace ZCJ.BLL
{
	/// <summary>
	/// SiteBaseInfoBLL
	/// </summary>
	public partial class SiteBaseInfoBLL
	{
		private static ISiteBaseInfoDAL dal=DataAccess.CreateSiteBaseInfoDAL();
		public SiteBaseInfoBLL()
		{}
		#region  BasicMethod
        
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(ZCJ.Model.SiteBaseInfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static ZCJ.Model.SiteBaseInfo GetModel(int id)
		{
			return dal.GetModel(id);
		}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

