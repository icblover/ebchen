using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZCJ.Utility;
using ZCJ.IDAL;
using ZCJ.Model;

namespace ZCJ.SQLServerDAL
{
    /// <summary>
    /// 视频类型
    /// </summary>
    public class VideoClassDAL : IVideoClassDAL
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(VideoClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into VideoClass(");
            strSql.Append("ClassName,ParentId,IsDelete,remark,CreateDate)");
            strSql.Append(" values (");
            strSql.Append("@ClassName,@ParentId,@IsDelete,@remark,GETDATE())");
            SqlParameter[] parameters = {
					new SqlParameter("@ClassName", SqlDbType.NVarChar,100),
					new SqlParameter("@ParentId", SqlDbType.Int,4),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@remark", SqlDbType.VarChar,50)};
            parameters[0].Value = model.ClassName;
            parameters[1].Value = model.ParentId;
            parameters[2].Value = model.IsDelete;
            parameters[3].Value = model.Remark ?? "";


            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters);

        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(VideoClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update VideoClass set ");
            strSql.Append("ClassName=@ClassName,");
            strSql.Append("ParentId=@ParentId,");
            strSql.Append("IsDelete=@IsDelete,");
            strSql.Append("remark=@remark,");
            strSql.Append("CreateDate=GETDATE()");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@ClassName", SqlDbType.NVarChar,100),
					new SqlParameter("@ParentId", SqlDbType.Int,4),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@remark", SqlDbType.VarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.ClassName;
            parameters[1].Value = model.ParentId;
            parameters[2].Value = model.IsDelete;
            parameters[3].Value = model.Remark ?? "";
            parameters[4].Value = model.id;

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from VideoClass ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public VideoClass GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,ClassName,ParentId,IsDelete,remark,CreateDate from VideoClass ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            using (SqlDataReader reader = SqlHelper.ExecuteReader(strSql.ToString(), parameters))
            {
                while (reader.Read())
                {
                    return DataReaderToModel(reader);
                }
            }
            return null;
        }


        /// <summary> 得到一个对象实体 </summary>
        public VideoClass DataReaderToModel(SqlDataReader row)
        {
            return new VideoClass
            {
                id = int.Parse(row["id"].ToString()),
                ClassName = row["ClassName"].ToString(),
                ParentId = int.Parse(row["ParentId"].ToString()),
                IsDelete = Convert.ToBoolean(row["IsDelete"]),
                Remark = row["remark"].ToString(),
                CreateDate = DateTime.Parse(row["CreateDate"].ToString())
            };
        }

        /// <summary> 获得数据列表 </summary>
        public List<VideoClass> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,ClassName,ParentId,IsDelete,remark,CreateDate ");
            strSql.Append(" FROM VideoClass ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" ORDER BY id DESC");
            List<VideoClass> list = new List<VideoClass>();
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
        /// 返回SqlDataReader格式的数据源
        /// </summary>
        /// <returns></returns>
        public SqlDataReader GetSelectListItem(string parentId)
        {
            const string sql = "select id,ClassName FROM VideoClass WHERE ParentId={0}";
            return SqlHelper.ExecuteReader(string.Format(sql, parentId));
        }
    }

}
