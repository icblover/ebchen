using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZCJ.Model;

namespace ZCJ.IDAL
{
    public interface IVideoDAL
    {
        int Add(Video model);

        int Update(Video model);

        bool Delete(int id);

        Video GetModel(int id);

        List<Video> GetList(string where);

        SqlDataReader GetDataReader(string where);

        bool SecondAudit(int id, string firstAudit, string firstAuditReason);

        bool ThirdAudit(int id, string secondAudit, string secondAuditReason);
    }
}
