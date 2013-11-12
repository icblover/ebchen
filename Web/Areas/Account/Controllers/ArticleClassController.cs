using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZCJ.BLL;
using ZCJ.Model;

namespace Web.Areas.Account.Controllers
{
    public class ArticleClassController : Controller
    {
        public ActionResult Index(int id=1)
        {
            return View(ArticleClassBLL.GetParentClass(id));
        }

        
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ArticleClass model)
        {
            try
            {
                ArticleClassBLL.Add(model);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                log4net.LogManager.GetLogger(typeof (ArticleClassController)).Error("添加文章分类错误", e);
                return Content("添加文章分类错误");
            }
        }


        public ActionResult Edit(int id)
        {
            try
            {
                return View(ArticleClassBLL.GetModel(id));
            }
            catch (Exception e)
            {
                log4net.LogManager.GetLogger(typeof(ArticleClassController)).Error("加载修改文章分类错误");
                throw;
            }
            
        }
        [HttpPost]
        public ActionResult Edit(ArticleClass model)
        {
            try
            {
                ArticleClassBLL.Update(model);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                log4net.LogManager.GetLogger(typeof(ArticleClassController)).Error("修改文章分类错误");
                return Content("修改文章分类错误");
            }
            return View();
        }
    }
}
