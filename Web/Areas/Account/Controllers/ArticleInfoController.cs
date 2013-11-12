using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZCJ.Model;
using ZCJ.BLL;
namespace Web.Areas.Account.Controllers
{
    public class ArticleInfoController : Controller
    {
        
        public ActionResult Index(int pageIndex=0)
        {
            return View(ArticleInfoBLL.Index(pageIndex, Session["ClassId"] != null ? Session["ClassId"].ToString() : "0",
                                          Session["keyword"] != null ? Session["keyword"].ToString() : ""));
            ;
        }
        [HttpPost]
        public ActionResult Index(string classId,string keyword)
        {
            Session["ClassId"] = classId;
            Session["keyword"] = keyword;
            return View(ArticleInfoBLL.Index(1, classId, keyword));
        }


        /// <summary> 新增  </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ArticleIntro model,ArticleDetail model2,bool shuiyin)
        {
            try
            {
                ArticleInfoBLL.Create(ArticleInfoBLL.ToTotalModel(model,model2), shuiyin);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                log4net.LogManager.GetLogger(typeof (ArticleInfoController)).Error("添加新闻错误", e);
                return Content("添加新闻错误");
            }
        }


        /// <summary> 修改 </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            try
            {
                return View(ArticleInfoBLL.GetModel(id));
            }
            catch (Exception e)
            {
                log4net.LogManager.GetLogger(typeof(ArticleInfoController)).Error("加载修改文章出错",e);
                return Content("加载修改文章出错！");
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(ArticleIntro model,ArticleDetail model2,bool shuiyin)
        {
            try
            {
                ArticleInfoBLL.Update(ArticleInfoBLL.ToTotalModel(model, model2), shuiyin);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                log4net.LogManager.GetLogger(typeof(ArticleInfoController)).Error("修改文章出错！",e);
                throw;
            }
        }


        /// <summary> 删除 </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            try
            {
                ArticleInfoBLL.Delete(id);
            }
            catch (Exception e)
            {
                log4net.LogManager.GetLogger(typeof (ArticleInfoController)).Error("删除新闻错误", e);
            }
            return RedirectToAction("Index");
        }


        /// <summary> 二审 </summary>
        /// <returns></returns>
        public ActionResult SecondAudit(int id,string powerlist, string state)
        {
            if (ArticleInfoBLL.HasSecondTrial(powerlist, state))
            {
                try
                {
                    return View(ArticleInfoBLL.GetModel(id));
                }
                catch (Exception e)
                {
                    log4net.LogManager.GetLogger(typeof(ArticleInfoController)).Error("加载二审文章" + id + "出错", e);
                    return Content("加载二审文章" + id + "出错！");
                }
            }
            return Content("您没有查看权限！");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SecondAudit(ArticleIntro model, ArticleDetail model2, bool shuiyin, int secondAudit, string secondAuditReason)
        {
            try
            {
                string aduitId = "";
                if (secondAudit == 1)
                {
                    aduitId = Session["userid"].ToString();
                }
                ArticleInfoBLL.SecondAudit(ArticleInfoBLL.ToTotalModel(model, model2), shuiyin, aduitId, secondAuditReason);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                log4net.LogManager.GetLogger(typeof (ArticleInfoController)).Error("二审错误！", e);
                return Content("二审出现错误，请重新进入");
            }
        }



        /// <summary> 三审 </summary>
        /// <returns></returns>
        public ActionResult ThirdAudit(int id ,string powerlist,string state)
        {
            if (ArticleInfoBLL.HasThirdTrail(powerlist,state))
            {
                try
                {
                    return View(ArticleInfoBLL.GetModel(id));
                }
                catch (Exception e)
                {
                    log4net.LogManager.GetLogger(typeof (ArticleInfoController)).Error("加载三审信息错误", e);
                }
            }
            return Content("你没有查看权限！");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThirdAudit(ArticleIntro model, ArticleDetail model2, bool shuiyin, int thirdAudit,string thirdAuditReason)
        {
            try
            {
                string aduitId = "";
                if (thirdAudit == 1)
                {
                    aduitId = Session["userid"].ToString();
                }
                ArticleInfoBLL.ThirdAudit(ArticleInfoBLL.ToTotalModel(model, model2), shuiyin, aduitId, thirdAuditReason);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                log4net.LogManager.GetLogger(typeof(ArticleInfoController)).Error("三审错误！", e);
                return Content("三审出现错误，请重新进入");
            }
        }

    }
}
