using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ZCJ.Model;
using ZCJ.BLL;

namespace Web.Areas.Account.Controllers
{
    public class ColumnNavigationController : Controller
    {
        public ActionResult Index()
        {
            return View(ColumnNavigationBLL.GetList());
        }


        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ColumnNavigation model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ColumnNavigationBLL.Create(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception e)
            {
                log4net.LogManager.GetLogger(typeof(ColumnNavigationController)).Error("添加导航栏目错误", e);
                return Content("添加导航栏目错误！");
            }
        }



        public ActionResult Edit(int id)
        {
            return View(ColumnNavigationBLL.GetModel(id));
        }
        [HttpPost]
        public ActionResult Edit(ColumnNavigation model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ColumnNavigationBLL.Update(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception e)
            {
                log4net.LogManager.GetLogger(typeof(ColumnNavigationController)).Error("修改栏目导航错误!", e);
                return Content("修改栏目导航错误！");
            }
        }


        public ActionResult Delete(int id)
        {
            ColumnNavigationBLL.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
