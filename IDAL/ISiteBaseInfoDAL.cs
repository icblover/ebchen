using System;
using System.Data;
namespace ZCJ.IDAL
{
    /// <summary>
    /// 接口层SiteBaseInfoBLL
    /// </summary>
    public interface ISiteBaseInfoDAL
    {
        #region  成员方法

        /// <summary> 更新一条数据 </summary>
        bool Update(ZCJ.Model.SiteBaseInfo model);

        /// <summary> 得到一个对象实体 </summary>
        ZCJ.Model.SiteBaseInfo GetModel(int id);

        /// <summary> 将DataReader转换为Model </summary>
        ZCJ.Model.SiteBaseInfo DataRowToModel(System.Data.SqlClient.SqlDataReader row);

        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    }
}
