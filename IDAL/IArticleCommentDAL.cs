using System;
using System.Collections.Generic;
using ZCJ.Model;

namespace ZCJ.IDAL
{
    public interface IArticleCommentDAL
    {
        int Create(ArticleComment model);

        bool Delete(int id);

        List<ArticleComment> GetList(string where);
    }
}
