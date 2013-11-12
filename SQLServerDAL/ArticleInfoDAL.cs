using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZCJ.Utility;
using ZCJ.Model;
using ZCJ.IDAL;
namespace ZCJ.SQLServerDAL
{
    public class ArticleInfoDAL : IArticleInfoDAL
    {
        public int Create(ArticleInfo model)
        {
            const string sql = "InsertArticle";

            SqlParameter[] parameters = {
					new SqlParameter("@ClassId", model.ClassId),
                    new SqlParameter("@Title", model.Title),
					new SqlParameter("@AttributionArea",model.AttributionArea),
					new SqlParameter("@HotFlag", model.HotFlag),
					new SqlParameter("@HasImage", model.HasImage),
					new SqlParameter("@SmallImgPath", model.SmallImgPath??""),
                    new SqlParameter("@CreateDate",model.CreateDate), 

					new SqlParameter("@ArticleIntroduce", model.ArticleIntroduce??""),
					new SqlParameter("@Keyword", model.Keyword??""),
					new SqlParameter("@ArticleContent",model.ArticleContent??""),
					new SqlParameter("@Author", model.Author??""),
					new SqlParameter("@ArticleFrom", model.ArticleFrom??"")};

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, sql, parameters);
        }

        public int Update(ArticleInfo model)
        {
            const string sql = "UpdateArticle";

            SqlParameter[] parameters = {
                    new SqlParameter("@id", model.id),
					new SqlParameter("@ClassId", model.ClassId),
                    new SqlParameter("@Title", model.Title),
					new SqlParameter("@AttributionArea",model.AttributionArea),
					new SqlParameter("@HotFlag", model.HotFlag),
					new SqlParameter("@HasImage", model.HasImage),
					new SqlParameter("@SmallImgPath", model.SmallImgPath??""),
                    new SqlParameter("@CreateDate",model.CreateDate), 

					new SqlParameter("@ArticleIntroduce", model.ArticleIntroduce??""),
					new SqlParameter("@Keyword", model.Keyword??""),
					new SqlParameter("@ArticleContent",model.ArticleContent??""),
					new SqlParameter("@Author", model.Author??""),
					new SqlParameter("@ArticleFrom", model.ArticleFrom??"")};

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, sql, parameters);
        }

        public bool Delete(int id)
        {
            const string sql = "DeleteAritcle";
            SqlParameter parameter = new SqlParameter("@id", id);
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, sql, parameter) > 0;
        }

        public List<ArticleInfo> GetList(string where)
        {
            List<ArticleInfo> list = new List<ArticleInfo>();
            const string sql = "SELECT  a.id ,dbo.Fun_GetArticleClassName(ClassId) 'ArticleClassName' , Title , HotFlag , HasImage ,        CreateDate , CASE WHEN SecondAudit IS NOT NULL THEN '三审/' + ISNULL(dbo.Fun_GetUserName(SecondAudit), '') WHEN FirstAudit IS NOT NULL THEN '二审/' + ISNULL(dbo.Fun_GetUserName(FirstAudit), '') ELSE '一审/' + ISNULL(dbo.Fun_GetUserName(dbo.Fun_GetAuthor(a.id)), '') END ArticleState,  SecondAudit, FirstAudit, Author, FirstAuditReason, SecondAuditReason FROM dbo.ArticleIntro a INNER JOIN dbo.ArticleDetail b ON a.id=b.ArticleId WHERE   IsDeleted = 0 {0} ORDER BY a.id DESC";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(string.Format(sql, where)))
            {
                while (reader.Read())
                {
                    list.Add(DataReaderToPartModel(reader));
                }
            }
            return list;
        }
        public List<ArticleInfo> GetList(string where, int id)
        {
            List<ArticleInfo> list = new List<ArticleInfo>();
            const string sql = "GetArticleListByManager";
            SqlParameter[] parameters =
                {
                    new SqlParameter("@ManagerId", id),
                    new SqlParameter("@where", where)
                };
            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, sql, parameters))
            {
                while (reader.Read())
                {
                    list.Add(DataReaderToPartModel(reader));
                }
            }
            return list;
        }


        /// <summary> Reader To Model </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private ArticleInfo DataReaderToPartModel(SqlDataReader reader)
        {
            return new ArticleInfo
                {
                    ArticleClassName = reader["ArticleClassName"].ToString(),
                    CreateDate = Convert.ToDateTime(reader["CreateDate"]),
                    HasImage = Convert.ToBoolean(reader["HasImage"]),
                    HotFlag = Convert.ToBoolean(reader["HotFlag"]),
                    id = Convert.ToInt32(reader["id"]),
                    Title = reader["Title"].ToString(),
                    FirstAudit = reader["FirstAudit"] is DBNull ? (int?)null : Convert.ToInt32(reader["FirstAudit"]),
                    FirstAuditReason = reader["FirstAuditReason"].ToString(),
                    SecondAudit = reader["SecondAudit"] is DBNull ? (int?)null : Convert.ToInt32(reader["SecondAudit"]),
                    SecondAuditReason = reader["SecondAuditReason"].ToString(),
                    Author = reader["Author"].ToString(),
                    ArticleSatate = reader["ArticleState"].ToString()
                };
        }

        private ArticleInfo DataReaderToModel(SqlDataReader reader)
        {
            return new ArticleInfo
                {
                    ArticleContent = reader["ArticleContent"].ToString(),
                    ArticleFrom = reader["ArticleFrom"].ToString(),
                    ArticleIntroduce = reader["ArticleIntroduce"].ToString(),
                    Keyword = reader["KeyWord"].ToString(),
                    Author = reader["Author"].ToString(),

                    AttributionArea = Convert.ToInt32(reader["AttributionArea"]),
                    ClassId = Convert.ToInt32(reader["ClassId"]),
                    CreateDate = Convert.ToDateTime(reader["CreateDate"]),
                    HasImage = Convert.ToBoolean(reader["HasImage"]),
                    HotFlag = Convert.ToBoolean(reader["HotFlag"]),
                    Title = reader["Title"].ToString(),
                    id = Convert.ToInt32(reader["id"]),
                    FirstAuditReason = reader["FirstAuditReason"].ToString(),
                    SecondAuditReason = reader["SecondAuditReason"].ToString()
                };
        }

        public ArticleInfo GetModel(int id)
        {
            const string sql = "SELECT  a.id ,a.ClassId ,  a.Title , a.AttributionArea ,a.HotFlag ,a.HasImage ,a.CreateDate ,b.ArticleIntroduce ,b.Keyword ,b.ArticleContent ,b.Author ,b.ArticleFrom,a.FirstAuditReason,a.SecondAuditReason FROM  dbo.ArticleIntro a INNER JOIN dbo.ArticleDetail b ON a.id = b.ArticleId WHERE a.id=@id";
            SqlParameter parameter = new SqlParameter("@id", id);
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, parameter))
            {
                while (reader.Read())
                {
                    return DataReaderToModel(reader);
                }
            }
            return null;
        }

        public bool SecondAudit(int id, string firstAudit, string firstAuditReason)
        {
            string sql = "";
            SqlParameter[] parameters;

            if (!string.IsNullOrEmpty(firstAudit))    //通过
            {
                sql = "UPDATE [ArticleIntro] SET [FirstAudit] = @FirstAudit,[FirstAuditDate] = GETDATE() WHERE id=@id";
                parameters = new[]{
                    new SqlParameter("@FirstAudit", firstAudit),
                    new SqlParameter("@id",id)
                };
            }
            else  //未通过
            {
                sql = "UPDATE [ArticleIntro] SET [FirstAudit] = NULL,[FirstAuditDate] = NULL,[FirstAuditReason] = @FirstAuditReason WHERE id=@id";
                parameters = new[]{
                    new SqlParameter("@FirstAuditReason", firstAuditReason),
                    new SqlParameter("@id",id)
                };
            }
            return SqlHelper.ExecuteNonQuery(sql, parameters) > 0;

        }

        public bool ThirdAudit(int id, string secondAudit, string secondAuditReason)
        {
            string sql;
            SqlParameter[] parameters = null;


            if (!string.IsNullOrEmpty(secondAudit))    //通过
            {
                sql = @"BEGIN 
    DECLARE @sql VARCHAR(1000)= ''
    DECLARE @firstaudit VARCHAR(100)
	
    SELECT  @firstaudit = FirstAudit    FROM    dbo.ArticleIntro;
	--三审时，判断有没有二审，没有，则一并更新
    IF @firstaudit IS NULL 
        UPDATE dbo.ArticleIntro SET FirstAudit=@SecondAudit,FirstAuditDate=GETDATE(),SecondAudit=@SecondAudit ,SecondAuditDate=GETDATE() WHERE id=@id
    ELSE 
        UPDATE dbo.ArticleIntro SET SecondAudit=@SecondAudit ,SecondAuditDate=GETDATE() WHERE id=@id
END";
                parameters = new[]{
                    new SqlParameter("@SecondAudit", secondAudit),
                    new SqlParameter("@id",id)
                };
            }
            else  //未通过
            {
                sql = @"UPDATE dbo.ArticleIntro SET SecondAuditReason=@SecondAuditReason WHERE id=@id";
                parameters = new[]{
                    new SqlParameter("@SecondAuditReason", secondAuditReason),
                    new SqlParameter("@id",id)
                };
            }
            return SqlHelper.ExecuteNonQuery(sql, parameters) > 0;

        }
    }
}

