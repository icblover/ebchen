using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZCJ.IDAL;
using ZCJ.Model;
using ZCJ.Utility;

namespace ZCJ.SQLServerDAL
{
    public class ArticleCommentDAL : IArticleCommentDAL
    {
        /// <summary>
        /// 文章添加评论
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Create(ArticleComment model)
        {
            const string sql = "INSERT INTO [ArticleComment]([CommentType],[ArticleId],[CommentText],[Commenter],[Ip],[CreateDate])VALUES(@CommentType,@ArticleId,@CommentText,@Commenter,@Ip,GETDATE())";
            SqlParameter[] parameters =
                {
                    new SqlParameter("@CommentType", model.CommentType),
                    new SqlParameter("@ArticleId", model.ArticleId),
                    new SqlParameter("@CommentText", model.CommentText),
                    new SqlParameter("@Commenter", model.Commenter),
                    new SqlParameter("@Ip", model.Ip)
                };
            return 1;
        }

        public bool Delete(int id)
        {
            const string sql = "DELETE FROM dbo.ArticleComment WHERE id=@id";
            SqlParameter parameter = new SqlParameter("@id", id);
            return SqlHelper.ExecuteNonQuery(sql, parameter) > 0;
        }

        public List<ArticleComment> GetList(string where)
        {
            const string sql = "SELECT a.*,b.Title FROM dbo.ArticleComment a INNER JOIN dbo.ArticleIntro b ON a.ArticleId=b.id WHERE 1=1 ORDER BY ArticleId,id DESC";
            List<ArticleComment> list = new List<ArticleComment>();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(string.Format(sql, where)))
            {
                while (reader.Read())
                {
                    list.Add(DataReaderToModel(reader));
                }
            }
            return list;
        }

        private ArticleComment DataReaderToModel(SqlDataReader reader)
        {
            return new ArticleComment
                {
                    ArticleId = Convert.ToInt32(reader["ArticleId"]),
                    Commenter = reader["Commenter"].ToString(),
                    CommentText = reader["CommentText"].ToString(),
                    CommentType = Convert.ToInt32(reader["CommentType"]),
                    CreateDate = Convert.ToDateTime(reader["CreateDate"]),
                    id = Convert.ToInt32(reader["id"]),
                    Ip = reader["Ip"].ToString(),
                    Title = reader["Title"].ToString()
                };
        }
    }
}
