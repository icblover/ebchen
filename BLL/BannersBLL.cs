using System;
using System.Data;
using System.Collections.Generic;
using ZCJ.Model;
using ZCJ.DALFactory;
using ZCJ.IDAL;
namespace ZCJ.BLL
{
    /// <summary>
    /// BannersBLL
    /// </summary>
    public partial class BannersBLL
    {
        private readonly IBannersDAL dal = DataAccess.CreateBannersDAL();
        public BannersBLL()
        { }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ZCJ.Model.Banners model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ZCJ.Model.Banners model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            return dal.Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZCJ.Model.Banners GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Banners> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Banners> GetList(string Top, string strWhere)
        {
            return dal.GetList(Top, strWhere);
        }

    }
}

