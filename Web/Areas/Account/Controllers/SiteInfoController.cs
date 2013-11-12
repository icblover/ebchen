using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZCJ.BLL;
using ZCJ.Model;

namespace Web.Areas.Account.Controllers
{
    /// <summary> 系统配置信息 </summary>
    public class SiteInfoController : Controller
    {
        /// <summary> 信息列表页面 </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(SiteBaseInfoBLL.GetModel(1));
        }

        // 修改
        // GET: /Account/SiteInfo/Edit/5
        public ActionResult Edit()
        {
            return View(SiteBaseInfoBLL.GetModel(1));
        }

        // 修改
        // POST: /Account/SiteInfo/Edit/5
        [HttpPost]
        public ActionResult Edit(SiteBaseInfo model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SiteBaseInfoBLL.Update(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception e)
            {
                log4net.LogManager.GetLogger(typeof(SiteInfoController)).Error("网站配置信息错误", e);
                return Content("修改错误，请重新登陆操作！");
            }
        }
    }
}
