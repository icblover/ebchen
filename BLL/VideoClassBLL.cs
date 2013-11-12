using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;
using ZCJ.DALFactory;
using ZCJ.Utility;
using ZCJ.IDAL;
using ZCJ.Model;

namespace ZCJ.BLL
{
    public class VideoClassBLL
    {
        private static readonly IVideoClassDAL dal=DataAccess.CreateVideoClassDAL();

		/// <summary> 增加一条数据 </summary>
		public static int  Add(ZCJ.Model.VideoClass model)
		{
		    model.IsDelete = !model.IsDelete;
			return dal.Add(model);
		}

		/// <summary> 更新一条数据 </summary>
		public static int Update(ZCJ.Model.VideoClass model)
		{
		    model.IsDelete = !model.IsDelete;
			return dal.Update(model);
		}

		/// <summary> 删除一条数据 </summary>
		public static bool Delete(int id)
		{
			return dal.Delete(id);
		}
		
		/// <summary> 得到一个对象实体 </summary>
		public static ZCJ.Model.VideoClass GetModel(int id)
		{
			return dal.GetModel(id);
		}

		/// <summary> 获取一级文章分类 </summary>
		/// <returns></returns>
        public static PagedList<VideoClass> GetParentClass(int pageIndex)
        {
            return dal.GetList(" ParentId=0 ").ToPagedList(pageIndex,20);
        }

        /// <summary> 获取二级文章分类 </summary>
        /// <param name="id">父级文章分类</param>
        /// <returns></returns>
        public static List<VideoClass> GetSonClass(int id)
        {
            return dal.GetList("  ParentId=" + id.ToString());
        }

        /// <summary> 返回SelectListItem格式的父分类数据 </summary>
        /// <returns></returns>
        public static List<SelectListItem> GetParentClassSelectItem()
        {
            return Utils.DataReaderToSelect(dal.GetSelectListItem("0"), "id", "ClassName","根分类");
        }
        
        public static List<SelectListItem> GetAllArticleList()
        {
            List<SelectListItem>  list=new List<SelectListItem>();
            list.Add(new SelectListItem
                {
                    Text = "--请选择--",
                    Value = "0"
                });
            using (SqlDataReader reader =dal.GetSelectListItem("0"))
            {
                while (reader.Read())
                {
                    list.Add(new SelectListItem
                        {
                            Text = reader["ClassName"].ToString(),
                            Value = reader["id"].ToString()
                        });
                    using (SqlDataReader sonReader=dal.GetSelectListItem(reader["id"].ToString()))
                    {
                        while (sonReader.Read())
                        {
                            list.Add(new SelectListItem
                            {
                                Text = "└" + sonReader["ClassName"].ToString(),
                                Value = sonReader["id"].ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }
    }
}
