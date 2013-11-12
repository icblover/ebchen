using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;
using ZCJ.Utility;
using ZCJ.Model;
using ZCJ.DALFactory;
using ZCJ.IDAL;
using Webdiyer.WebControls.Mvc;
namespace ZCJ.BLL
{
	/// <summary>
	/// ArticleClassBLL
	/// </summary>
	public partial class ArticleClassBLL
	{
		private static readonly IArticleClassDAL dal=DataAccess.CreateArticleClassDAL();
		public ArticleClassBLL()
		{}

		/// <summary> 增加一条数据 </summary>
		public static int  Add(ZCJ.Model.ArticleClass model)
		{
		    model.IsDelete = !model.IsDelete;
			return dal.Add(model);
		}

		/// <summary> 更新一条数据 </summary>
		public static bool Update(ZCJ.Model.ArticleClass model)
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
		public static ZCJ.Model.ArticleClass GetModel(int id)
		{
			return dal.GetModel(id);
		}

		/// <summary> 获取一级文章分类 </summary>
		/// <returns></returns>
        public static PagedList<ArticleClass> GetParentClass(int pageIndex)
        {
            return dal.GetList(" ParentId=0 ").ToPagedList(pageIndex,20);
        }

        /// <summary> 获取二级文章分类 </summary>
        /// <param name="id">父级文章分类</param>
        /// <returns></returns>
        public static List<ArticleClass> GetSonClass(int id)
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

