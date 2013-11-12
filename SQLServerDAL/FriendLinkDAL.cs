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
    /// 数据访问类:FriendLinkDAL
    /// </summary>
    public partial class FriendLinkDAL : IFriendLinkDAL
    {
        public FriendLinkDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ZCJ.Model.FriendLink model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into FriendLink(");
            strSql.Append("LinkName,LinkUrl,LinkType,LinkLogo,HasLogo,CreateDate,ShowOrder)");
            strSql.Append(" values (");
            strSql.Append("@LinkName,@LinkUrl,@LinkType,@LinkLogo,@HasLogo,GETDATE(),@ShowOrder)");
            SqlParameter[] parameters = {
					new SqlParameter("@LinkName", SqlDbType.VarChar,200),
					new SqlParameter("@LinkUrl", SqlDbType.VarChar,300),
					new SqlParameter("@LinkType", SqlDbType.Int,4),
					new SqlParameter("@LinkLogo", SqlDbType.VarChar,100),
					new SqlParameter("@HasLogo", SqlDbType.TinyInt,1),
                    new SqlParameter("@ShowOrder",SqlDbType.Int,4)};
            parameters[0].Value = model.LinkName;
            parameters[1].Value = model.LinkUrl ?? "";
            parameters[2].Value = model.LinkType;
            parameters[3].Value = model.LinkLogo ?? "";
            parameters[4].Value = model.HasLogo;
            parameters[5].Value = model.ShowOrder ?? 0;

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters);

        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ZCJ.Model.FriendLink model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update FriendLink set ");
            strSql.Append("LinkName=@LinkName,");
            strSql.Append("LinkUrl=@LinkUrl,");
            strSql.Append("LinkType=@LinkType,");
            strSql.Append("LinkLogo=@LinkLogo,");
            strSql.Append("HasLogo=@HasLogo,");
            strSql.Append("CreateDate=GETDATE(),");
            strSql.Append("ShowOrder=@ShowOrder");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@LinkName", SqlDbType.VarChar,200),
					new SqlParameter("@LinkUrl", SqlDbType.VarChar,300),
					new SqlParameter("@LinkType", SqlDbType.Int,4),
					new SqlParameter("@LinkLogo", SqlDbType.VarChar,100),
					new SqlParameter("@HasLogo", SqlDbType.TinyInt,1),
                    new SqlParameter("@ShowOrder",SqlDbType.Int,4), 
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.LinkName;
            parameters[1].Value = model.LinkUrl;
            parameters[2].Value = model.LinkType;
            parameters[3].Value = model.LinkLogo;
            parameters[4].Value = model.HasLogo;
            parameters[5].Value = model.ShowOrder;
            parameters[6].Value = model.id;

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from FriendLink ");
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
            strSql.Append("delete from FriendLink ");
            strSql.Append(" where id in (" + idlist + ")  ");
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }


        /// <summary> 得到一个对象实体 </summary>
        public ZCJ.Model.FriendLink GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,LinkName,LinkUrl,LinkType,LinkLogo,HasLogo,ShowOrder,CreateDate from FriendLink ");
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
        public ZCJ.Model.FriendLink DataRowToModel(SqlDataReader row)
        {
            return new FriendLink
                {
                    id = int.Parse(row["id"].ToString()),
                    LinkName = row["LinkName"].ToString(),
                    LinkUrl = row["LinkUrl"].ToString(),
                    LinkType = int.Parse(row["LinkType"].ToString()),
                    LinkLogo = row["LinkLogo"].ToString(),
                    HasLogo = int.Parse(row["HasLogo"].ToString()),
                    ShowOrder = int.Parse(row["ShowOrder"].ToString()),
                    CreateDate = DateTime.Parse(row["CreateDate"].ToString())
                };
        }

        /// <summary> 得到一个对象实体 </summary>
        public ZCJ.Model.FriendLink DataRowToPartialModel(SqlDataReader row)
        {
            return new FriendLink
            {
                id = int.Parse(row["id"].ToString()),
                LinkName = row["LinkName"].ToString(),
                LinkUrl = row["LinkUrl"].ToString(),
                LinkLogo = row["LinkLogo"].ToString(),
                HasLogo = int.Parse(row["HasLogo"].ToString()),
                ShowOrder = int.Parse(row["ShowOrder"].ToString()),
                LinkTypeName = row["TypeName"].ToString()
            };
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<FriendLink> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  id ,LinkName ,LinkUrl ,LinkLogo ,HasLogo ,ShowOrder,ISNULL(dbo.Fun_GetFriendLinkType(LinkType),'') TypeName FROM dbo.FriendLink  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" ORDER BY id DESC");
            List<FriendLink> list = new List<FriendLink>();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(strSql.ToString()))
            {
                while (reader.Read())
                {
                    list.Add(DataRowToPartialModel(reader));
                }
            }
            return list;
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<FriendLink> GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,LinkName,LinkUrl,LinkType,LinkLogo,ShowOrder,HasLogo,CreateDate ");
            strSql.Append(" FROM FriendLink ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            List<FriendLink> list = new List<FriendLink>();
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
        /// <summary> 获得友情链接类型 </summary>
        /// <returns></returns>
        public SqlDataReader GetFriendLinkTypeList()
        {
            const string SQL = "SELECT * FROM dbo.SiteParameter WHERE ParameterType='FriendLinkType' ORDER BY id DESC";
            return SqlHelper.ExecuteReader(SQL);
        }

        #endregion  ExtensionMethod
    }
}

