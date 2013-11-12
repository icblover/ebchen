using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZCJ.Model;

namespace ZCJ.IDAL
{
    public interface IAssociationDAL
    {
        int Create(Association model);

        int Update(Association model);

        bool Delete(int id);

        Association GetModel(int id);

        List<Association> GetList(string where);

        SqlDataReader GetAssociationType();
    }
}
