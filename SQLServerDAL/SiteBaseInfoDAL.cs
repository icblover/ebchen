using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZCJ.Utility;
using ZCJ.IDAL;
using ZCJ.Model;

namespace ZCJ.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:SiteBaseInfoDAL
    /// </summary>
    public partial class SiteBaseInfoDAL : ISiteBaseInfoDAL
    {
        public SiteBaseInfoDAL()
        { }
        #region  BasicMethod


        /// <summary> 更新一条数据 </summary>
        public bool Update(ZCJ.Model.SiteBaseInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SiteBaseInfo set ");
            strSql.Append("SiteName=@SiteName,");
            strSql.Append("SiteKeyWord=@SiteKeyWord,");
            strSql.Append("TelNo=@TelNo,");
            strSql.Append("Email=@Email,");
            strSql.Append("ZipCode=@ZipCode,");
            strSql.Append("Copyright=@Copyright,");
            strSql.Append("Address=@Address,");
            strSql.Append("CodeStatistics=@CodeStatistics,");
            strSql.Append("UpdateDate=GETDATE()");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@SiteName", SqlDbType.VarChar,200),
					new SqlParameter("@SiteKeyWord", SqlDbType.VarChar,1000),
					new SqlParameter("@TelNo", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,100),
					new SqlParameter("@ZipCode", SqlDbType.VarChar,20),
					new SqlParameter("@Copyright", SqlDbType.VarChar,200),
					new SqlParameter("@Address", SqlDbType.VarChar,500),
					new SqlParameter("@CodeStatistics", SqlDbType.VarChar,1000),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.SiteName ?? "";
            parameters[1].Value = model.SiteKeyWord ?? "";
            parameters[2].Value = model.TelNo ?? "";
            parameters[3].Value = model.Email ?? "";
            parameters[4].Value = model.ZipCode ?? "";
            parameters[5].Value = model.Copyright ?? "";
            parameters[6].Value = model.Address ?? "";
            parameters[7].Value = model.CodeStatistics ?? "";
            parameters[8].Value = model.id;

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }

        /// <summary> 得到一个对象实体 </summary>
        public ZCJ.Model.SiteBaseInfo GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,SiteName,SiteKeyWord,TelNo,Email,ZipCode,Copyright,Address,CodeStatistics from SiteBaseInfo ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            using (SqlDataReader reader = SqlHelper.ExecuteReader(strSql.ToString(), parameters))
            {
                while (reader.Read())
                {
                    return DataRowToModel(reader);
                }
            }

            return null;

        }

        /// <summary> 将DataReader转换为Model </summary>
        public ZCJ.Model.SiteBaseInfo DataRowToModel(SqlDataReader row)
        {
            return new SiteBaseInfo
                {
                    id = int.Parse(row["id"].ToString()),
                    SiteName = row["SiteName"].ToString(),
                    SiteKeyWord = row["SiteKeyWord"].ToString(),
                    TelNo = row["TelNo"].ToString(),
                    Email = row["Email"].ToString(),
                    ZipCode = row["ZipCode"].ToString(),
                    Copyright = row["Copyright"].ToString(),
                    Address = row["Address"].ToString(),
                    CodeStatistics = row["CodeStatistics"].ToString()
                };
        }


        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

