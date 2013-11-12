using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZCJ.Model;
namespace ZCJ.IDAL
{
    /// <summary>
    /// 网站详细配置参数信息
    /// </summary>
    public interface ISiteParameterDAL
    {
        int Create(SiteParameter model);
        int Update(SiteParameter model);
        bool Delete(int id);
        SiteParameter GetModel(int id);
        List<SiteParameter> GetList(string where);
        SiteParameter DataReaderToModel(SqlDataReader reader);
        SqlDataReader GetParameterTypeList();
        SqlDataReader GetParameterList(string parameterType);
    }
}
