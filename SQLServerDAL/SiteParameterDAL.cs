using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZCJ.Model;
using ZCJ.Utility;
using ZCJ.IDAL;
namespace ZCJ.SQLServerDAL
{
    public class SiteParameterDAL:ISiteParameterDAL
    {
        public int Create(SiteParameter model)
        {
            const string sql = "INSERT INTO [SiteParameter]([ParameterName],[ParameterType],[Remark]) VALUES(@ParameterName,@ParameterType,@Remark)";
            SqlParameter[] parameters =
                {
                    new SqlParameter("@ParameterName", model.ParameterName),
                    new SqlParameter("@ParameterType", model.ParameterType),
                    new SqlParameter("@Remark", model.Remark ?? "")
                };
            return SqlHelper.ExecuteNonQuery(sql, parameters);
        }

        public int Update(SiteParameter model)
        {
            const string sql = "UPDATE [SiteParameter] SET [ParameterName] = @ParameterName,[ParameterType] = @ParameterType,[Remark] = @Remark WHERE id=@id";
            SqlParameter[] parameters =
                {
                    new SqlParameter("@ParameterName", model.ParameterName),
                    new SqlParameter("@ParameterType", model.ParameterType),
                    new SqlParameter("@Remark", model.Remark ?? ""),
                    new SqlParameter("@id",model.id)
                };
            return SqlHelper.ExecuteNonQuery(sql, parameters);
        }

        public bool Delete(int id)
        {
            const string sql = "DELETE FROM dbo.SiteParameter WHERE id=@id";
            SqlParameter parameter = new SqlParameter("@id", id);
            return SqlHelper.ExecuteNonQuery(sql, parameter) > 0;
        }

        public SiteParameter GetModel(int id)
        {
            const string sql = "SELECT * FROM dbo.SiteParameter WHERE id=@id";
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

        public SiteParameter DataReaderToModel(SqlDataReader reader)
        {
            return new SiteParameter
                {
                    id = Convert.ToInt32(reader["id"]),
                    ParameterName = reader["ParameterName"].ToString(),
                    ParameterType = reader["ParameterType"].ToString(),
                    Remark = reader["Remark"].ToString()
                };
        }

        public List<SiteParameter> GetList(string where)
        {
            List<SiteParameter> list=new List<SiteParameter>();
            const string sql = "SELECT * FROM dbo.SiteParameter WHERE 1=1 {0} ORDER BY id DESC";
            using (SqlDataReader reader=SqlHelper.ExecuteReader(string.Format(sql,where)))
            {
                while (reader.Read())
                {
                    list.Add(DataReaderToModel(reader));
                }
            }
            return list;
        }

        public SqlDataReader GetParameterTypeList()
        {
            const string sql = "SELECT ParameterType FROM dbo.SiteParameter GROUP BY ParameterType";
            return SqlHelper.ExecuteReader(sql);
        }
        /// <summary>
        /// 根据参数类型调用参数
        /// </summary>
        /// <param name="paramterType">参数类型</param>
        /// <returns></returns>
        public SqlDataReader GetParameterList(string paramterType)
        {
            const string sql = "SELECT * FROM dbo.SiteParameter WHERE  ParameterType=@ParameterType ORDER BY id DESC";
            SqlParameter parameter = new SqlParameter("@ParameterType", paramterType);
            return SqlHelper.ExecuteReader(sql, parameter);
        }
    }
}
