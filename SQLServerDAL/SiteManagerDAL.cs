using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZCJ.Utility;
using ZCJ.IDAL;
using ZCJ.Model;
using System.Collections.Generic;

namespace ZCJ.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:SiteManagerDAL
    /// </summary>
    public partial class SiteManagerDAL : ISiteManagerDAL
    {
        public SiteManagerDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SiteManager");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }


        /// <summary> 增加一条数据 </summary>
        public int Add(ZCJ.Model.SiteManager model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SiteManager(");
            strSql.Append("UserName,PassWord,NickName,role,Is_Deleted,CreateDate)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@PassWord,@NickName,@role,@Is_Deleted,GETDATE())");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@PassWord", SqlDbType.VarChar,100),
                    new SqlParameter("@NickName", SqlDbType.VarChar,50), 
					new SqlParameter("@role", SqlDbType.VarChar,20),
					new SqlParameter("@Is_Deleted", SqlDbType.Bit,1)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.PassWord;
            parameters[2].Value = model.NickName;
            parameters[3].Value = model.Role;
            parameters[4].Value = model.Is_Deleted;

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters);
        }
        /// <summary> 更新一条数据 </summary>
        public bool Update(ZCJ.Model.SiteManager model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SiteManager set ");
            strSql.Append("UserName=@UserName,");
            strSql.Append("PassWord=@PassWord,");
            strSql.Append("role=@role,");
            strSql.Append("NickName=@NickName,");
            strSql.Append("Is_Deleted=@Is_Deleted,");
            strSql.Append("CreateDate=GETDATE()");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@PassWord", SqlDbType.VarChar,100),
					new SqlParameter("@role", SqlDbType.VarChar,20),
                    new SqlParameter("@NickName", SqlDbType.VarChar,50), 
					new SqlParameter("@Is_Deleted", SqlDbType.Bit,1),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.PassWord;
            parameters[2].Value = model.Role;
            parameters[3].Value = model.NickName;
            parameters[4].Value = model.Is_Deleted;
            parameters[5].Value = model.id;

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }

        /// <summary> 删除一条数据 </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SiteManager ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }


        /// <summary> 得到一个对象实体 </summary>
        public ZCJ.Model.SiteManager GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,UserName,PassWord,NickName,role,Is_Deleted,CreateDate from SiteManager ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            List<SiteManager> list = new List<SiteManager>();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(strSql.ToString(), parameters))
            {
                while (reader.Read())
                {
                    return DataReaderToModel(reader);
                }
            }
            return null;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZCJ.Model.SiteManager DataReaderToModel(SqlDataReader row)
        {
            return new SiteManager
                {
                    id = int.Parse(row["id"].ToString()),
                    UserName = row["UserName"].ToString(),
                    PassWord = row["PassWord"].ToString(),
                    NickName = row["NickName"].ToString(),
                    Role = row["role"].ToString(),
                    Is_Deleted = row["Is_Deleted"].ToString() == "1",
                    CreateDate = DateTime.Parse(row["CreateDate"].ToString())
                };
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<SiteManager> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select ");
            strSql.Append("a.id ,a.UserName ,a.PassWord ,a.NickName ,b.name 'role' ,a.Is_Deleted,a.CreateDate ");
            strSql.Append(" FROM    dbo.SiteManager a INNER JOIN dbo.ManagerRole b ON a.role = b.id ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append("ORDER BY a.id");
            
            List<SiteManager> list = new List<SiteManager>();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(strSql.ToString()))
            {
                while (reader.Read())
                {
                    list.Add(DataReaderToModel(reader));
                }
            }
            return list;
        }

        /// <summary>
        /// 登陆验证
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public SiteManager LoginValidate(string username, string password)
        {
            const string sql ="SELECT * FROM dbo.SiteManager WHERE UserName=@username AND [PassWord]=@password AND Is_Deleted=0";
            SqlParameter[] parameters =
                {
                    new SqlParameter("@username", username),
                    new SqlParameter("@password", password)
                };
            using (SqlDataReader reader=SqlHelper.ExecuteReader(sql,parameters))
            {
                while (reader.Read())
                {
                    return DataReaderToModel(reader);
                }
            }
            return null;
        }

        #endregion  BasicMethod
        
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

