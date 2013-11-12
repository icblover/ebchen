using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZCJ.IDAL;
using ZCJ.Model;
using ZCJ.Utility;


namespace ZCJ.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:BannersDAL
    /// </summary>
    public class BannersDAL : IBannersDAL
    {
        public BannersDAL()
        { }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ZCJ.Model.Banners model)
        {
            string strSql = "INSERT INTO [dbo].[Banners]([ImagePath],[ImageAlt],[ImageUrl],[Location],[CreateDate])VALUES(@ImagePath,@ImageAlt,@ImageUrl,@Location,GETDATE())";
            SqlParameter[] parameters =
		        {
		            new SqlParameter("@ImagePath", model.ImagePath),
		            new SqlParameter("@ImageAlt", model.ImageAlt),
		            new SqlParameter("@ImageUrl", model.ImageUrl),
		            new SqlParameter("@Location", model.Loacation)
		        };

            return SqlHelper.ExecuteNonQuery(strSql, parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ZCJ.Model.Banners model)
        {
            string strSql = "UPDATE [dbo].[Banners] SET [ImagePath] = @ImagePath,[ImageAlt] = @ImageAlt,[ImageUrl] = @ImageUrl,[Location] = @Location,[CreateDate] = GETDATE() WHERE id=@id";
            SqlParameter[] parameters =
		        {
		            new SqlParameter("@ImagePath", model.ImagePath),
		            new SqlParameter("@ImageAlt", model.ImageAlt),
		            new SqlParameter("@ImageUrl", model.ImageUrl),
		            new SqlParameter("@Location", model.Loacation)
		        };
            return SqlHelper.ExecuteNonQuery(strSql, parameters) > 0;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Banners ");
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
        public ZCJ.Model.Banners GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,ImgPath,ImgAlt,BannersPosition,CreateDate,UpdateDate from Banners ");
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
        public ZCJ.Model.Banners DataRowToModel(SqlDataReader row)
        {
            return new Banners
            {
                CreateDate = Convert.ToDateTime(row["CreateDate"]),
                id = Convert.ToInt32(row["id"]),
                ImageAlt = row["ImageAlt"].ToString(),
                ImagePath = row["ImagePath"].ToString(),
                ImageUrl = row["ImageUrl"].ToString(),
                Loacation = row["Location"].ToString()
            };
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Banners> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,ImgPath,ImgAlt,BannersPosition,CreateDate,UpdateDate  FROM Banners ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<Banners> list = new List<Banners>();
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
        public List<Banners> GetList(string Top, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top != "0")
            {
                strSql.Append(" top " + Top);
            }
            strSql.Append(" id,ImgPath,ImgAlt,BannersPosition,CreateDate,UpdateDate ");
            strSql.Append(" FROM Banners ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by id DESC");
            List<Banners> list = new List<Banners>();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(strSql.ToString()))
            {
                while (reader.Read())
                {
                    list.Add(DataRowToModel(reader));
                }
            }
            return list;
        }

    }
}
