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
    public class AssociationDAL:IAssociationDAL
    {
        public int Create(Association model)
        {
            const string sql ="INSERT  INTO dbo.Association( AssociationName ,AssociationUrl ,AssociationType ,ShowOrder) VALUES  ( @AssociationName ,@AssociationUrl ,@AssociationType ,@ShowOrder )";
            SqlParameter[] parameters =
                {
                    new SqlParameter("@AssociationName", model.AssociationName),
                    new SqlParameter("@AssociationUrl", model.AssociationUrl),
                    new SqlParameter("@AssociationType", model.AssociationType),
                    new SqlParameter("@ShowOrder", model.ShowOrder)
                };
            return SqlHelper.ExecuteNonQuery(sql, parameters);
        }

        public int Update(Association model)
        {
            const string sql ="UPDATE  [Association] SET [AssociationName] = @AssociationName ,[AssociationUrl] = @AssociationUrl ,[AssociationType] = @AssociationType ,[ShowOrder] = @ShowOrder WHERE id = @id";
            SqlParameter[] parameters =
                {
                    new SqlParameter("@AssociationName", model.AssociationName),
                    new SqlParameter("@AssociationUrl", model.AssociationUrl),
                    new SqlParameter("@AssociationType", model.AssociationType),
                    new SqlParameter("@ShowOrder", model.ShowOrder),
                    new SqlParameter("@id",model.id)
                };
            return SqlHelper.ExecuteNonQuery(sql, parameters);
        }

        public bool Delete(int id)
        {
            const string sql = "DELETE FROM [Association] WHERE id=@id";
            SqlParameter parameter=new SqlParameter("@id",Utils.SafeInt32(id));

            return SqlHelper.ExecuteNonQuery(sql, parameter) > 0;
        }
            
        public Association GetModel(int id)
        {
            const string sql = "SELECT * FROM dbo.Association WHERE id=@id";
            SqlParameter parameter =new SqlParameter("@id",Utils.SafeInt32(id));
            using (SqlDataReader reader=SqlHelper.ExecuteReader(sql,parameter))
            {
                while (reader.Read())
                {
                    return DataReaderToModel(reader);
                }
            }
            return null;
        }
        public Association DataReaderToModel(SqlDataReader reader)
        {
            return new Association
            {
                id = Convert.ToInt32(reader["id"]),
                AssociationName = reader["AssociationName"].ToString(),
                AssociationType = Convert.ToInt32(reader["AssociationType"]),
                AssociationUrl = reader["AssociationUrl"].ToString(),
                ShowOrder = Convert.ToInt32(reader["ShowOrder"])
            };
        }
        public Association DataReaderToExtendModel(SqlDataReader reader)
        {
            return new Association
                {
                    id = Convert.ToInt32(reader["id"]),
                    AssociationName = reader["AssociationName"].ToString(),
                    AssociationType = Convert.ToInt32(reader["AssociationType"]),
                    AssociationUrl = reader["AssociationUrl"].ToString(),
                    AssociationTypeName = reader["AssociationTypeName"].ToString()
                };
        }

        public List<Association> GetList(string where)
        {
            List<Association> list=new List<Association>();
            const string sql = "SELECT a.id,a.AssociationName,a.AssociationType,a.AssociationUrl,b.ParameterName AS AssociationTypeName FROM dbo.Association a INNER JOIN SiteParameter b ON a.AssociationType=b.id WHERE 1=1 {0} ORDER BY a.id DESC";
            using (SqlDataReader reader=SqlHelper.ExecuteReader(string.Format(sql,where)))
            {
                while (reader.Read())
                {
                    list.Add(DataReaderToExtendModel(reader));
                }
            }
            return list;
        }

        public SqlDataReader GetAssociationType()
        {
            const string sql = "SELECT * FROM SiteParameter WHERE ParameterType='Association' ORDER BY id DESC";
            return SqlHelper.ExecuteReader(sql);
        }
        
    }
}
