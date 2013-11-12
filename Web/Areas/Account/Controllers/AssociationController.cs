using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZCJ.BLL;
using ZCJ.Model;

namespace Web.Areas.Account.Controllers
{
    public class AssociationController : Controller
    {
        //
        // GET: /Account/Association/

        public ActionResult Index(int id = 1)
        {
            return View(AssociationBLL.GetPagedList(id));
        }
        [HttpPost]
        public ActionResult Index(string keyword, string AssociationType, int id = 1)
        {
            return View(AssociationBLL.GetPagedList(keyword, AssociationType, id));
        }


        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Association model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AssociationBLL.Create(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception e)
            {
                log4net.LogManager.GetLogger(typeof(AssociationController)).Error("添加协会信息错误", e);
                return Content("添加协会信息错误");
            }
        }


        public ActionResult Edit(int id)
        {
            try
            {
                return View(AssociationBLL.GetModel(id));
            }
            catch (Exception e)
            {
                log4net.LogManager.GetLogger(typeof(AssociationController)).Error("初始化加载协会信息错误", e);
                return Content("加载修改错误，请重新进入!");
            }
        }
        [HttpPost]
        public ActionResult Edit(Association model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AssociationBLL.Update(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception e)
            {
                log4net.LogManager.GetLogger(typeof(AssociationController)).Error("修改协会信息错误", e);
                return Content("修改协会信息错误");
            }
        }


        public ActionResult Delete(int id)
        {
            try
            {
                AssociationBLL.Delete(id);
            }
            catch (Exception e)
            {
                log4net.LogManager.GetLogger(typeof(AssociationController)).Error("协会删除错误", e);
            }
            return RedirectToAction("Index");
        }
    }
}
