using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZCJ.Utility;
using System.IO;
using ZCJ.BLL;
using ZCJ.Model;

namespace Web.Areas.Account.Controllers
{
    public class MainController : Controller
    {

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username="admin",string password="admin",string validatecode="")
        {
            //if (MainBLL.ValidateCodeIsOk(Session["validatecode"].ToString(),validatecode))
            //{
                if (!string.IsNullOrEmpty(username)&&!string.IsNullOrEmpty(password))
                {
                    SiteManager model = MainBLL.Login(username, password);
                    if (model!=null)
                    {
                        Session["userid"] = model.id;
                        Session["nickname"] = model.NickName;
                        Session["role"] = model.Role;
                        return RedirectToAction("Index", "SiteInfo");
                    }
                    return RedirectToAction("Login");
                }
                return RedirectToAction("Login");
            //}
            //return RedirectToAction("Login");
        }


        /// <summary> 验证码 </summary>
        /// <returns></returns>
        public ActionResult ValidateCode()
        {
            YZMHelper yzm=new YZMHelper();
            Session["validatecode"] = yzm.Text;
            MemoryStream stream=new MemoryStream();
            yzm.Image.Save(stream,ImageFormat.Jpeg);
            return File(stream.ToArray(), @"image/jpeg");
        }
    }
}
