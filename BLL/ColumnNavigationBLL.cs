using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZCJ.DALFactory;
using ZCJ.IDAL;
using ZCJ.Model;
namespace ZCJ.BLL
{
    public class ColumnNavigationBLL
    {
        private static readonly IColumnNavigationDAL dal = DataAccess.CreateNavigationDAL();

        public static int Create(ColumnNavigation model)
        {
            return dal.Create(model);
        }
        
        public static int Update(ColumnNavigation model)
        {
            return dal.Update(model);
        }

        public static bool Delete(int id)
        {
            return dal.Delete(id);
        }

        public static List<ColumnNavigation> GetList()
        {
            return dal.GetList("");
        }

        public static ColumnNavigation GetModel(int id)
        {
            return dal.GetModel(Utility.Utils.SafeInt32(id));
        }
    }
}
