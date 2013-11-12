using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ZCJ.Model;

namespace ZCJ.IDAL
{
	/// <summary>
	/// 接口层ArticleClassBLL
	/// </summary>
	public interface IArticleClassDAL
	{
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(ZCJ.Model.ArticleClass model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(ZCJ.Model.ArticleClass model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int id);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		ZCJ.Model.ArticleClass GetModel(int id);
		/// <summary>
		/// 获得数据列表
		/// </summary>
        List<ArticleClass> GetList(string strWhere);

	    /// <summary>
	    /// 返回SqlDataReader格式的数据源
	    /// </summary>
	    /// <param name="parentId"></param>
	    /// <returns></returns>
	    SqlDataReader GetSelectListItem(string parentId);
	} 
}
