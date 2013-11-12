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
    public class SiteModuleController : Controller
    {
        /// <summary> 列表页面 </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(SiteModuleBLL.GetParentModuleList());
        }


        /// <summary> 添加新模块 </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(SiteModule collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    collection.IsClosed = (bool)collection.IsClosed ? false : true;
                    SiteModuleBLL.Add(collection);
                    return RedirectToAction("Index");
                }
                return View(collection);
            }
            catch (Exception e)
            {
                log4net.LogManager.GetLogger(typeof(SiteModuleController)).Error("网站模块添加错误", e);
                return Content("出错了！请联系开发人员");
            }
        }


        /// <summary> 修改 </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            try
            {
                return View(SiteModuleBLL.GetModel(Utils.SafeInt32(id)));
            }
            catch (Exception e)
            {
                log4net.LogManager.GetLogger(typeof(SiteModuleController)).Error("网站模块加载修改" + id.ToString() + "错误", e);
                return Content("修改加载错误，请重新进入！");
            }
        }
        [HttpPost]
        public ActionResult Edit(SiteModule model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.IsClosed != null)
                    {
                        model.IsClosed = !((bool)model.IsClosed);
                    }
                    else
                    {
                        model.IsClosed = false;
                    }
                    SiteModuleBLL.Update(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception e)
            {
                log4net.LogManager.GetLogger(typeof(SiteModuleController)).Error("网站模块修改错误", e);
                return Content("修改加载错误，请重新进入！");
            }
        }


        /// <summary> 删除 </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            try
            {
                SiteModuleBLL.Delete(Utils.SafeInt32(id));
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                log4net.LogManager.GetLogger(typeof(SiteModuleController)).Error("网站模块删除错误", e);
                return Content("修改加载错误，请重新进入！");
            }

        }
    }
}
