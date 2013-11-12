using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZCJ.Model;
using ZCJ.BLL;
using ZCJ.Utility;
namespace Web.Areas.Account.Controllers
{
    public class SiteManagerController : Controller
    {
        //
        // GET: /Account/SiteManager/

        public ActionResult Index()
        {
            return View(SiteManagerBLL.GetAllManagerList());
        }


        /// <summary> 新增 </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(SiteManager model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.PassWord != model.RePassWord)
                    {
                        return Content("两次密码不一致，请重新进入添加");
                    }
                    SiteManagerBLL.Add(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception e)
            {
                log4net.LogManager.GetLogger(typeof(SiteManagerController)).Error("添加新管理员出错！", e);
                return Content("添加管理员出错");
            }
        }


        /// <summary> 修改 </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            return View(SiteManagerBLL.GetModel(id));
        }
        [HttpPost]
        public ActionResult Edit(SiteManager model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //如果原密码正确，且新密码不为空，则换密码
                    if (SiteManagerBLL.IsOldPassword(Request.Form["OldPassWord"], model.PassWord) && Request.Form["NewPassWord"] != null)
                    {
                        model.PassWord = Utils.MD5(Request.Form["NewPassWord"]);
                    }
                    SiteManagerBLL.Update(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception e)
            {
                log4net.LogManager.GetLogger(typeof(SiteManagerController)).Error("修改管理员信息出错", e);
                return Content("修改管理员信息出错");
            }
        }


        /// <summary> 删除 </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            try
            {
                SiteManagerBLL.Delete(id);
            }
            catch (Exception e)
            {
                log4net.LogManager.GetLogger(typeof(SiteManagerController)).Error("删除管理员错误", e);
            }
            return RedirectToAction("Index");
        }

    }
}
