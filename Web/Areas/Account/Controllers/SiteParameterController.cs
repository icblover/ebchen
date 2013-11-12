using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZCJ.BLL;
using ZCJ.Model;

namespace Web.Areas.Account.Controllers
{
    public class SiteParameterController : Controller
    {
        public static string ParameterTypeRemark = "";
        public ActionResult Index(int pageIndex = 1)
        {
            ViewBag.select = ParameterTypeRemark == "" ? "0" : ParameterTypeRemark;
            return View(SiteParameterBLL.GetPagedList(ParameterTypeRemark == "" ? "0" : ParameterTypeRemark, pageIndex));
        }
        [HttpPost]
        public ActionResult Index(string ParameterType = "0")
        {
            ParameterTypeRemark = ParameterType;
            return View(SiteParameterBLL.GetPagedList(ParameterType, 1));
        }


        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(SiteParameter model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SiteParameterBLL.Create(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception e)
            {
                log4net.LogManager.GetLogger(typeof(SiteParameterController)).Error("添加配置参数错误", e);
                return Content("添加配置参数错误");
            }
        }


        public ActionResult Edit(int id)
        {
            try
            {
                return View(SiteParameterBLL.GetModel(id));
            }
            catch (Exception e)
            {
                log4net.LogManager.GetLogger(typeof(SiteParameter)).Error("初始化配置参数错误", e);
                return Content("初始化配置参数错误");
            }
        }
        [HttpPost]
        public ActionResult Edit(SiteParameter model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SiteParameterBLL.Update(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception e)
            {
                log4net.LogManager.GetLogger(typeof(SiteParameterController)).Error("修改配置参数错误", e);
                return Content("修改配置参数错误");
            }
        }


        public ActionResult Delete(int id)
        {
            SiteParameterBLL.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
