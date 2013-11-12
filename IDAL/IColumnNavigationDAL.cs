using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZCJ.Model;

namespace ZCJ.IDAL
{
    public interface IColumnNavigationDAL
    {
        int Create(ColumnNavigation model);
        int Update(ColumnNavigation model);
        bool Delete(int id);
        List<ColumnNavigation> GetList(string where);
        ColumnNavigation GetModel(int id);
    }
}
