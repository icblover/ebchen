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
	/// 数据访问类:ArticleClassDAL
	/// </summary>
	public partial class ArticleClassDAL:IArticleClassDAL
	{
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ArticleClass model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ArticleClass(");
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
			parameters[3].Value = model.remark??"";
			

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters);
			
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ArticleClass model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ArticleClass set ");
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
			parameters[3].Value = model.remark??"";
			parameters[4].Value = model.id;

		    return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ArticleClass ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return SqlHelper.ExecuteNonQuery(strSql.ToString(),parameters)>0;
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZCJ.Model.ArticleClass GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,ClassName,ParentId,IsDelete,remark,CreateDate from ArticleClass ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

		    using (SqlDataReader reader=SqlHelper.ExecuteReader(strSql.ToString(),parameters))
		    {
		        while (reader.Read())
		        {
		            return DataReaderToModel(reader);
		        }
		    }
		    return null;
		}


		/// <summary> 得到一个对象实体 </summary>
		public ZCJ.Model.ArticleClass DataReaderToModel(SqlDataReader row)
		{
		    return new ArticleClass
		        {
		            id = int.Parse(row["id"].ToString()),
		            ClassName = row["ClassName"].ToString(),
		            ParentId = int.Parse(row["ParentId"].ToString()),
		            IsDelete = Convert.ToBoolean(row["IsDelete"]),
		            remark = row["remark"].ToString(),
		            CreateDate = DateTime.Parse(row["CreateDate"].ToString())
		        };
		}

		/// <summary> 获得数据列表 </summary>
		public List<ArticleClass> GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,ClassName,ParentId,IsDelete,remark,CreateDate ");
			strSql.Append(" FROM ArticleClass ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
		    strSql.Append(" ORDER BY id DESC");
            List<ArticleClass> list=new List<ArticleClass>();
		    using (SqlDataReader reader=SqlHelper.ExecuteReader(strSql.ToString()))
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
            const string sql ="select id,ClassName FROM ArticleClass WHERE ParentId={0}";
            return SqlHelper.ExecuteReader(string.Format(sql, parentId));
        }
        
	}
}

