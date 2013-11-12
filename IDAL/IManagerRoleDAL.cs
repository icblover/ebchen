using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ZCJ.IDAL
{
	/// <summary>
	/// 接口层ManagerRoleBLL
	/// </summary>
	public interface IManagerRoleDAL
	{
		#region  成员方法
		/// <summary> 增加一条数据 </summary>
		int Add(ZCJ.Model.ManagerRole model);
		/// <summary> 更新一条数据 </summary>
		bool Update(ZCJ.Model.ManagerRole model);
		/// <summary> 删除一条数据 </summary>
		bool Delete(int id);
		/// <summary> 得到一个对象实体 </summary>
		ZCJ.Model.ManagerRole GetModel(int id);
		ZCJ.Model.ManagerRole DataRowToModel(System.Data.SqlClient.SqlDataReader row);
		/// <summary> 获得数据列表 </summary>
		List<ZCJ.Model.ManagerRole> GetList(string strWhere);
		/// <summary> 获得前几行数据 </summary>
        List<ZCJ.Model.ManagerRole> GetList(int Top, string strWhere, string filedOrder);

	    SqlDataReader GetManagerRoleSource(string strWhere);

	    #endregion  成员方法

	    #region  MethodEx

	    #endregion  MethodEx
	} 
}
