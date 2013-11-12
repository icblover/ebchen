using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ZCJ.IDAL
{
	/// <summary>
	/// 接口层FriendLinkBLL
	/// </summary>
	public interface IFriendLinkDAL
	{
		#region  成员方法
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(ZCJ.Model.FriendLink model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(ZCJ.Model.FriendLink model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int id);
		bool DeleteList(string idlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		ZCJ.Model.FriendLink GetModel(int id);
		ZCJ.Model.FriendLink DataRowToModel(System.Data.SqlClient.SqlDataReader row);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		List<ZCJ.Model.FriendLink> GetList(string strWhere);
		/// <summary>
		/// 获得前几行数据
		/// </summary>
        List<ZCJ.Model.FriendLink> GetList(int Top, string strWhere, string filedOrder);

		#endregion  成员方法
		#region  MethodEx
        /// <summary> 获得友情链接类型  </summary>
        /// <returns></returns>
	    SqlDataReader GetFriendLinkTypeList();

	    #endregion  MethodEx
	} 
}
