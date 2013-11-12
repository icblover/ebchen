using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using ZCJ.Utility;
using ZCJ.IDAL;
using ZCJ.Model;

namespace ZCJ.SQLServerDAL
{
    /// <summary> 数据访问类:ManagerRoleDAL </summary>
    public partial class ManagerRoleDAL : IManagerRoleDAL
    {
        public ManagerRoleDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ZCJ.Model.ManagerRole model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ManagerRole(");
            strSql.Append("name,OperateList,CreateDate)");
            strSql.Append(" values (");
            strSql.Append("@name,@OperateList,GETDATE())");

            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,100),
                    new SqlParameter("@OperateList", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.name;
            parameters[1].Value = model.OperateList;

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ZCJ.Model.ManagerRole model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ManagerRole set ");
            strSql.Append("name=@name,");
            strSql.Append("OperateList=@OperateList,");
            strSql.Append("CreateDate=GETDATE()");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,100),
                    new SqlParameter("@OperateList",SqlDbType.NVarChar,500), 
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.name;
            parameters[1].Value = model.OperateList;
            parameters[2].Value = model.id;

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ManagerRole ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ManagerRole ");
            strSql.Append(" where id in (" + idlist + ")  ");
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZCJ.Model.ManagerRole GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,name,CreateDate,OperateList from ManagerRole ");
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


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZCJ.Model.ManagerRole DataRowToModel(SqlDataReader row)
        {
            return new ManagerRole
                {
                    id = int.Parse(row["id"].ToString()),
                    name = row["name"].ToString(),
                    OperateList = row["OperateList"].ToString(),
                    CreateDate = DateTime.Parse(row["CreateDate"].ToString())
                };
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ManagerRole> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,name,OperateList,CreateDate ");
            strSql.Append(" FROM ManagerRole ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" ORDER BY id DESC ");
            List<ManagerRole> list = new List<ManagerRole>();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(strSql.ToString()))
            {
                while (reader.Read())
                {
                    list.Add(DataRowToModel(reader));
                }
            }
            return list;
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<ManagerRole> GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,name,CreateDate,OperateList ");
            strSql.Append(" FROM ManagerRole ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            List<ManagerRole> list = new List<ManagerRole>();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(strSql.ToString()))
            {
                while (reader.Read())
                {
                    list.Add(DataRowToModel(reader));
                }
            }
            return list;
        }

        #endregion  BasicMethod

        #region  ExtensionMethod
        public SqlDataReader GetManagerRoleSource(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,name");
            strSql.Append(" FROM ManagerRole ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" ORDER BY id DESC ");
            return SqlHelper.ExecuteReader(strSql.ToString());
        }
        #endregion  ExtensionMethod
    }
}

