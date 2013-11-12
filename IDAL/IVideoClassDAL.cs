using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZCJ.Model;

namespace ZCJ.IDAL
{
    public interface IVideoClassDAL
    {
        int Add(VideoClass model);

        int Update(VideoClass model);

        bool Delete(int id);

        VideoClass GetModel(int id);

        List<VideoClass> GetList(string where);

        SqlDataReader GetSelectListItem(string parentId);
    }
}
