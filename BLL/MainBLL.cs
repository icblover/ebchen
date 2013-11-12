using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZCJ.Utility;
using ZCJ.Model;
using ZCJ.IDAL;
using ZCJ.DALFactory;
namespace ZCJ.BLL
{
    public class MainBLL
    {
        
        /// <summary> 检测验证码 </summary>
        /// <param name="sessionStr"></param>
        /// <param name="userInput"></param>
        /// <returns></returns>
        public static bool ValidateCodeIsOk(string sessionStr, string userInput)
        {
            if (sessionStr.ToLower() == userInput.ToLower())
                return true;
            return false;
        }


        /// <summary> 登陆验证 </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static SiteManager Login(string userName, string password)
        {
            return DataAccess.CreateSiteManagerDAL().LoginValidate(Utils.SafeSQL(userName), Utils.MD5(Utils.SafeSQL(password)));
        }
    }
}
