using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZCJ.IDAL;
using ZCJ.Model;
using ZCJ.Utility;

namespace ZCJ.SQLServerDAL
{
    public class ColumnNavigationDAL : IColumnNavigationDAL
    {
        public int Create(ColumnNavigation model)
        {
            const string SQL = "INSERT INTO [ColumnNavigation]([ColumnName],[ColumnUrl],[Remark])VALUES(@ColumnName,@ColumnUrl,@Remark)";
            SqlParameter[] parameter ={
                    new SqlParameter("@ColumnName",model.ColumnName),
                    new SqlParameter("@ColumnUrl",model.ColumnUrl??""),
                    new SqlParameter("@Remark",model.Remark??"")
                };

            return SqlHelper.ExecuteNonQuery(SQL, parameter);
        }
        public int Update(ColumnNavigation model)
        {
            const string SQL = "UPDATE [ColumnNavigation] SET [ColumnName] = @ColumnName,[ColumnUrl] = @ColumnUrl,[Remark] = @Remark WHERE id=@id";
            SqlParameter[] parameter =
                {
                    new SqlParameter("@ColumnName", model.ColumnName),
                    new SqlParameter("@ColumnUrl",model.ColumnUrl??""),
                    new SqlParameter("@Remark",model.Remark??""),
                    new SqlParameter("@id",model.id)
                };
            return SqlHelper.ExecuteNonQuery(SQL, parameter);
        }
        public bool Delete(int id)
        {
            const string SQL = "DELETE FROM [ColumnNavigation] WHERE id=@id";
            SqlParameter parameter = new SqlParameter("@id", id);
            return SqlHelper.ExecuteNonQuery(SQL, parameter) > 0;
        }

        public ColumnNavigation GetModel(int id)
        {
            const string SQL = "SELECT * FROM ColumnNavigation WHERE id={0}";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(string.Format(SQL, id)))
            {
                while (reader.Read())
                {
                    return DataReaderToModel(reader);
                }
            }
            return null;
        }

        public List<ColumnNavigation> GetList(string where)
        {
            List<ColumnNavigation> list = new List<ColumnNavigation>();
            const string SQL = "SELECT [id],[ColumnName],[ColumnUrl],[Remark] FROM [ColumnNavigation] WHERE {0} ORDER BY id DESC";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(string.Format(SQL, where == "" ? "1=1" : where)))
            {
                while (reader.Read())
                {
                    list.Add(DataReaderToModel(reader));
                }
            }
            return list;
        }

        public ColumnNavigation DataReaderToModel(SqlDataReader reader)
        {
            return new ColumnNavigation
                {
                    id = Convert.ToInt32(reader["id"]),
                    ColumnName = reader["ColumnName"].ToString(),
                    ColumnUrl = reader["ColumnUrl"].ToString(),
                    Remark = reader["Remark"].ToString()
                };
        }
    }

}
