using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ZCJ.IDAL
{
	/// <summary>
	/// 接口层SiteModuleBLL
	/// </summary>
	public interface ISiteModuleDAL
	{
		#region  成员方法
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(ZCJ.Model.SiteModule model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(ZCJ.Model.SiteModule model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int id);
		bool DeleteList(string idlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		ZCJ.Model.SiteModule GetModel(int id);
		ZCJ.Model.SiteModule DataRowToModel(DataRow row);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		List<ZCJ.Model.SiteModule> GetList(string strWhere);
        /// <summary>
        /// 返回SqlDataReader形式的数据流
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
	    SqlDataReader GetDataReaderList(string strWhere);
		/// <summary>
		/// 获得前几行数据
		/// </summary>
        List<ZCJ.Model.SiteModule> GetList(int Top, string strWhere, string filedOrder);

		int GetRecordCount(string strWhere);

		#endregion  成员方法
		#region  MethodEx
        /// <summary> 获取所有可以设定权限的列表 </summary>
        /// <returns></returns>
	    List<ZCJ.Model.SiteModule> GetOperateListItem();

	    #endregion  MethodEx
	} 
}
