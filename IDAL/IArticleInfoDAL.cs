using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZCJ.Model;

namespace ZCJ.IDAL
{
    public interface IArticleInfoDAL
    {
        int Create(ArticleInfo model);
        int Update(ArticleInfo model);
        bool Delete(int id);
        List<ArticleInfo> GetList(string where);
        List<ArticleInfo> GetList(string where,int id);
        ArticleInfo GetModel(int id);
        bool SecondAudit(int id, string firstAudit, string firstAuditReason);
        bool ThirdAudit(int id, string secondAudit, string secondAuditReason); 

    }
}
