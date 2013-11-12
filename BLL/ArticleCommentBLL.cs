using System;
using System.Collections.Generic;
using ZCJ.IDAL;
using ZCJ.DALFactory;
using ZCJ.Model;
using Webdiyer.WebControls.Mvc;

namespace ZCJ.BLL
{
    public class ArticleCommentBLL
    {
        private static readonly IArticleCommentDAL dal = DataAccess.CreateArticleCommentDAL();

        public static int Create(ArticleComment model)
        {
            return dal.Create(model);
        }

        public static bool Delete(int id)
        {
            return dal.Delete(id);
        }

        public static List<ArticleComment> GetList(string where)
        {
            return dal.GetList(where);
        }

        public static PagedList<ArticleComment> PagedList(string where, int pageIndex)
        {
            return GetList(where).ToPagedList(pageIndex, 20);
        }
    }
}
