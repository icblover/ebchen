using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZCJ.Utility;
using ZCJ.IDAL;
using ZCJ.Model;

namespace ZCJ.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:SiteModuleDAL
    /// </summary>
    public partial class SiteModuleDAL : ISiteModuleDAL
    {
        public SiteModuleDAL()
        { }
        #region  BasicMethod
        
        /// <summary> 增加一条数据 </summary>
        public int Add(ZCJ.Model.SiteModule model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SiteModule(");
            strSql.Append("ModuleName,ModuleUrl,ParentId,IsClosed,remark,CreateDate)");
            strSql.Append(" values (");
            strSql.Append("@ModuleName,@ModuleUrl,@ParentId,@IsClosed,@remark,GETDATE())");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleName", SqlDbType.VarChar,100),
					new SqlParameter("@ModuleUrl", SqlDbType.VarChar,200),
					new SqlParameter("@ParentId", SqlDbType.Int,4),
					new SqlParameter("@IsClosed", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,100)};
            parameters[0].Value = model.ModuleName;
            parameters[1].Value = model.ModuleUrl ?? "";
            parameters[2].Value = model.ParentId;
            parameters[3].Value = model.IsClosed;
            parameters[4].Value = model.remark ?? "";

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters);
        }

        /// <summary> 更新一条数据 </summary>
        public bool Update(ZCJ.Model.SiteModule model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SiteModule set ");
            strSql.Append("ModuleName=@ModuleName,");
            strSql.Append("ModuleUrl=@ModuleUrl,");
            strSql.Append("ParentId=@ParentId,");
            strSql.Append("IsClosed=@IsClosed,");
            strSql.Append("remark=@remark,");
            strSql.Append("CreateDate=GETDATE()");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleName", SqlDbType.VarChar,100),
					new SqlParameter("@ModuleUrl", SqlDbType.VarChar,200),
					new SqlParameter("@ParentId", SqlDbType.Int,4),
					new SqlParameter("@IsClosed", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,100),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.ModuleName;
            parameters[1].Value = model.ModuleUrl ?? "";
            parameters[2].Value = model.ParentId;
            parameters[3].Value = model.IsClosed;
            parameters[4].Value = model.remark ?? "";
            parameters[5].Value = model.id;

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }

        /// <summary> 删除一条数据 </summary>
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SiteModule ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }

        /// <summary> 批量删除数据 </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SiteModule ");
            strSql.Append(" where id in (" + idlist + ")  ");
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }


        /// <summary> 得到一个对象实体 </summary>
        public ZCJ.Model.SiteModule GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,ModuleName,ModuleUrl,ParentId,IsClosed,remark,CreateDate from SiteModule ");
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

        /// <summary> 得到一个对象实体 </summary>
        public ZCJ.Model.SiteModule DataRowToModel(SqlDataReader row)
        {
            return new SiteModule
            {
                id = int.Parse(row["id"].ToString()),
                ModuleName = row["ModuleName"].ToString(),
                ModuleUrl = row["ModuleUrl"].ToString(),
                ParentId = int.Parse(row["ParentId"].ToString()),
                IsClosed = Convert.ToBoolean(row["IsClosed"]),
                remark = row["remark"].ToString(),
                CreateDate = DateTime.Parse(row["CreateDate"].ToString())
            };
        }

        /// <summary> 得到一个对象实体 </summary>
        public ZCJ.Model.SiteModule DataRowToModel(DataRow row)
        {
            return new SiteModule
            {
                id = int.Parse(row["id"].ToString()),
                ModuleName = row["ModuleName"].ToString(),
                ModuleUrl = row["ModuleUrl"].ToString(),
                ParentId = int.Parse(row["ParentId"].ToString()),
                IsClosed = Convert.ToBoolean(row["IsClosed"]),
                remark = row["remark"].ToString(),
                CreateDate = DateTime.Parse(row["CreateDate"].ToString())
            };
        }

        /// <summary> 获得数据列表 </summary>
        public List<SiteModule> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,ModuleName,ModuleUrl,ParentId,IsClosed,remark,CreateDate ");
            strSql.Append(" FROM SiteModule ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where ");
                strSql.Append(strWhere);
            }
            List<SiteModule> list=new List<SiteModule>();
            using (SqlDataReader reader=SqlHelper.ExecuteReader(strSql.ToString()))
            {
                while (reader.Read())
                {
                    list.Add(DataRowToModel(reader));
                }
            }
            return list;
        }

        /// <summary> 获得数据列表 </summary>
        public SqlDataReader GetDataReaderList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,ModuleName,ModuleUrl,ParentId,IsClosed,remark,CreateDate ");
            strSql.Append(" FROM SiteModule ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where ");
                strSql.Append(strWhere);
                //仅对没有删除的模块操作
                strSql.Append(" AND IsClosed=0");
            }
            List<SiteModule> list = new List<SiteModule>();
            return SqlHelper.ExecuteReader(strSql.ToString());

        }
        /// <summary> 获得前几行数据 </summary>
        public List<SiteModule> GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,ModuleName,ModuleUrl,ParentId,IsClosed,remark,CreateDate ");
            strSql.Append(" FROM SiteModule ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            List<SiteModule> list = new List<SiteModule>();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(strSql.ToString()))
            {
                while (reader.Read())
                {
                    list.Add(DataRowToModel(reader));
                }
            }
            return list;
        }

        /// <summary> 获取记录总数 </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM SiteModule ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return (int)SqlHelper.ExecuteScalar(strSql.ToString());
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        /// <summary> 获取所有可以设定权限的列表 </summary>
        /// <returns></returns>
        public List<SiteModule> GetOperateListItem()
        {
            StringBuilder str = new StringBuilder("SELECT * FROM dbo.SiteModule");
            List<SiteModule> list=new List<SiteModule>();

            using (SqlDataReader reader=SqlHelper.ExecuteReader(str.ToString()))
            {
                while (reader.Read())
                {
                    list.Add(DataRowToModel(reader));
                }
            }
            return list;
        }

        #endregion  ExtensionMethod
    }
}

