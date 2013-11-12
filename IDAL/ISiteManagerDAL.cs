using System;
using System.Collections.Generic;
using System.Data;
using ZCJ.Model;

namespace ZCJ.IDAL
{
	/// <summary>
	/// 接口层SiteManagerBLL
	/// </summary>
	public interface ISiteManagerDAL
	{
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int id);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(ZCJ.Model.SiteManager model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(ZCJ.Model.SiteManager model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int id);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		ZCJ.Model.SiteManager GetModel(int id);
		ZCJ.Model.SiteManager DataReaderToModel(System.Data.SqlClient.SqlDataReader row);
		/// <summary>
		/// 获得数据列表
		/// </summary>
        List<ZCJ.Model.SiteManager> GetList(string strWhere);
		
		#endregion  成员方法
		#region  MethodEx

	    SiteManager LoginValidate(string username, string password);

	    #endregion  MethodEx
	} 
}
