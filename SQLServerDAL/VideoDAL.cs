using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZCJ.Utility;
using ZCJ.IDAL;
using ZCJ.Model;

namespace ZCJ.SQLServerDAL
{
    public class VideoDAL : IVideoDAL
    {
        public int Add(Video model)
        {
            const string sql = "INSERT  INTO [dbo].[Video] ( [ClassId] , [Title] , [Introduce] , [Keyword] , [Reporter] , [Context] , [VideoFrom] , [VideoImage] ,[VideoPath] , [Editor] , [CreateDate] )VALUES  ( @ClassId , @Title , @Introduce , @Keyword , @Reporter , @Context , @VideoFrom , @VideoImage , @VideoPath , @Editor , @CreateDate )";

            SqlParameter[] parameters =
                {
                    new SqlParameter("@ClassId", model.ClassId),
                    new SqlParameter("@Title", model.Title),
                    new SqlParameter("@Introduce", model.Introduce),
                    new SqlParameter("@Keyword", model.Keyword),
                    new SqlParameter("@Reporter", model.Reporter),
                    new SqlParameter("@Context", model.Context),
                    new SqlParameter("@VideoFrom", model.VideoFrom),
                    new SqlParameter("@VideoImage", model.VideoImage),
                    new SqlParameter("@VideoPath", model.VideoPath),
                    new SqlParameter("@Editor", model.Editor),
                    new SqlParameter("@CreateDate", model.CreateDate)
                };
            return SqlHelper.ExecuteNonQuery(sql, parameters);
        }

        public int Update(Video model)
        {
            const string sql = @"UPDATE [Video]
   SET [ClassId] = @ClassId
      ,[Title] = @Title
      ,[Introduce] = @Introduce
      ,[Keyword] = @Keyword
      ,[Reporter] = @Reporter
      ,[Context] = @Context
      ,[VideoFrom] = @VideoFrom
      ,[VideoImage] = @VideoImage
      ,[VideoPath] = @VideoPath
      ,[Editor] = @Editor
      ,[CreateDate] = @CreateDate
 WHERE id=@id";
            SqlParameter[] parameters =
                {
                    new SqlParameter("@ClassId", model.ClassId),
                    new SqlParameter("@Title", model.Title),
                    new SqlParameter("@Introduce", model.Introduce),
                    new SqlParameter("@Keyword", model.Keyword),
                    new SqlParameter("@Reporter", model.Reporter),
                    new SqlParameter("@Context", model.Context),
                    new SqlParameter("@VideoFrom", model.VideoFrom),
                    new SqlParameter("@VideoImage", model.VideoImage),
                    new SqlParameter("@VideoPath", model.VideoPath),
                    new SqlParameter("@Editor", model.Editor),
                    new SqlParameter("@CreateDate", model.CreateDate),
                    new SqlParameter("@id",model.id)
                };
            return SqlHelper.ExecuteNonQuery(sql, parameters);
        }

        public bool Delete(int id)
        {
            const string sql = "DELETE FROM [dbo].[Video] WHERE id=@id";
            SqlParameter parameter = new SqlParameter("@id", id);

            return SqlHelper.ExecuteNonQuery(sql, parameter) > 0;
        }

        public Video GetModel(int id)
        {
            const string sql = "SELECT [id],[ClassId],[Title],[Introduce],[Keyword],[Reporter],[Context],[VideoFrom],[VideoImage],[VideoPath],[Editor],[CreateDate],[FirstAuditReason],[SecondAuditReason] FROM [dbo].[Video] WHERE id=@id";
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

        public List<Video> GetList(string where)
        {
            const string sql = "SELECT [id],[ClassId],dbo.Fun_GetVideoClassName([ClassId]) 'ClassName',[Title],[Introduce],[Keyword],[Reporter],[Context],[VideoFrom],[VideoImage],[VideoPath],[Editor],[CreateDate],[FirstAudit],[FirstAuditReason],[FirstAuditDate],[SecondAudit],[SecondAuditReason],[SecondAuditDate],CASE WHEN FirstAudit is NULL  THEN '一审/'+ISNULL(dbo.Fun_GetUserName(Editor),'') WHEN SecondAudit is NULL THEN '二审/'+ISNULL(dbo.Fun_GetUserName(FirstAudit),'') ELSE '三审/'+ISNULL(dbo.Fun_GetUserName(SecondAudit),'') END 'VideoState' FROM [dbo].[Video]WHERE 1=1 {0} ORDER BY id DESC";
            List<Video> list = new List<Video>();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(string.Format(sql, where)))
            {
                while (reader.Read())
                {
                    list.Add(ListDataReaderToModel(reader));
                }
            }
            return list;
        }

        /// <summary> 修改视频信息项转换model </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public Video DataReaderToModel(SqlDataReader reader)
        {
            return new Video
            {
                id = Convert.ToInt32(reader["id"]),
                ClassId = Convert.ToInt32(reader["ClassId"]),
                Context = reader["Context"].ToString(),
                CreateDate = Convert.ToDateTime(reader["CreateDate"]),
                Editor = Convert.ToInt32(reader["Editor"]),

                Introduce = reader["Introduce"].ToString(),
                Keyword = reader["Keyword"].ToString(),
                Reporter = reader["Reporter"].ToString(),
                Title = reader["Title"].ToString(),
                VideoFrom = reader["VideoFrom"].ToString(),

                VideoImage = reader["VideoImage"].ToString(),
                VideoPath = reader["VideoPath"].ToString(),
                FirstAuditReason = reader["FirstAuditReason"].ToString(),
                SecondAuditReason = reader["SecondAuditReason"].ToString()
            };
        }

        /// <summary> 视频列表查询项转换model </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public Video ListDataReaderToModel(SqlDataReader reader)
        {
            return new Video
                {
                    id = Convert.ToInt32(reader["id"]),
                    ClassId = Convert.ToInt32(reader["ClassId"]),
                    Context = reader["Context"].ToString(),
                    CreateDate = Convert.ToDateTime(reader["CreateDate"]),
                    Editor = Convert.ToInt32(reader["Editor"]),

                    Introduce = reader["Introduce"].ToString(),
                    Keyword = reader["Keyword"].ToString(),
                    Reporter = reader["Reporter"].ToString(),
                    Title = reader["Title"].ToString(),
                    VideoFrom = reader["VideoFrom"].ToString(),

                    VideoImage = reader["VideoImage"].ToString(),
                    VideoPath = reader["VideoPath"].ToString(),

                    FirstAudit = reader["FirstAudit"] is DBNull ? (int?)null : Convert.ToInt32(reader["FirstAudit"]),
                    FirstAuditReason = reader["FirstAuditReason"].ToString(),
                    FirstAuditDate = reader["FirstAuditDate"] is DBNull ? (DateTime?)null : Convert.ToDateTime(reader["FirstAuditDate"]),

                    SecondAudit = reader["SecondAudit"] is DBNull ? (int?)null : Convert.ToInt32(reader["SecondAudit"]),
                    SecondAuditReason = reader["SecondAuditReason"].ToString(),
                    SecondAuditDate = reader["SecondAuditDate"] is DBNull ? (DateTime?)null : Convert.ToDateTime(reader["SecondAuditDate"]),

                    VideoState = reader["VideoState"].ToString(),
                    ClassName = reader["ClassName"].ToString()
                };
        }

        public SqlDataReader GetDataReader(string where)
        {
            const string sql = "SELECT [id],[ClassId],[Title],[Introduce],[Keyword],[Reporter],[Context],[VideoFrom],[VideoImage],[VideoPath],[Editor],[CreateDate] FROM [dbo].[Video] WHERE 1=1 {0} ORDER BY id DESC";
            return SqlHelper.ExecuteReader(string.Format(sql, where));
        }

        public bool SecondAudit(int id, string firstAudit, string firstAuditReason)
        {
            string sql = "";
            SqlParameter[] parameters;
            if (!string.IsNullOrEmpty(firstAudit)) //通过
            {
                sql = "UPDATE dbo.Video SET FirstAudit=@FirstAudit,FirstAuditDate=GETDATE() WHERE id=@id";
                parameters = new[]
                    {
                        new SqlParameter("@FirstAudit", firstAudit),
                        new SqlParameter("@id", id)
                    };
            }
            else
            {
                sql = "UPDATE dbo.Video SET FirstAuditReason = @FirstAuditReason WHERE id=@id";
                parameters = new[]
                    {
                        new SqlParameter("@FirstAuditReason", firstAuditReason),
                        new SqlParameter("@id", id)
                    };
            }

            return SqlHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool ThirdAudit(int id, string secondAudit, string secondAuditReason)
        {
            string sql = "";
            SqlParameter[] parameters;
            if (!string.IsNullOrEmpty(secondAudit)) //通过
            {
                sql = @"BEGIN 
	DECLARE @firstaudit VARCHAR(100)
	
	SELECT @firstaudit=FirstAudit FROM dbo.Video	
	IF @firstaudit IS NULL
		UPDATE dbo.Video SET FirstAudit=@SecondAudit,FirstAuditDate=GETDATE(),SecondAudit=@SecondAudit,SecondAuditDate=GETDATE() WHERE id=@id
	ELSE
		UPDATE dbo.Video SET SecondAudit=@SecondAudit,SecondAuditDate=GETDATE() WHERE id=@id		
END";
                parameters = new[]
                    {
                        new SqlParameter("@SecondAudit",secondAudit), 
                        new SqlParameter("@id",id)
                    };
            }
            else  //未通过
            {
                sql = @"BEGIN 
	DECLARE @firstauditReason VARCHAR(100)	
	SELECT @firstauditReason=FirstAuditReason FROM dbo.Video	
	IF @firstauditReason IS NULL
		UPDATE dbo.Video SET FirstAuditReason = @SecondAuditReason,SecondAuditReason = @SecondAuditReason WHERE id=@id
	ELSE
		UPDATE dbo.Video SET SecondAuditReason = @SecondAuditReason WHERE id=@id
END";
                parameters = new[]
                    {
                        new SqlParameter("@SecondAuditReason", secondAuditReason),
                        new SqlParameter("@id", id)
                    };
            }
            return SqlHelper.ExecuteNonQuery(sql, parameters) > 0;
        }
    }
}
