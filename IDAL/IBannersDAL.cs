using System;
using System.Collections.Generic;
using System.Data;
namespace ZCJ.IDAL
{
    /// <summary>
    /// 接口层BannersBLL
    /// </summary>
    public interface IBannersDAL
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(ZCJ.Model.Banners model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(ZCJ.Model.Banners model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ZCJ.Model.Banners GetModel(int id);

        List<Model.Banners> GetList(string where);

        List<Model.Banners> GetList(string top, string where);

        #endregion  成员方法

    }
}
