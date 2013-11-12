using System;
using System.Web.Mvc;
using ZCJ.Model;
using ZCJ.BLL;

namespace Web.Areas.Account.Controllers
{
    public class VideoController : Controller
    {
        public ActionResult Index(int pageIndex=0)
        {
            return View(VideoBLL.IndexNoQuery(pageIndex));
        }

        
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Video model)
        {
            try
            {
                if (VideoBLL.ExistFile(model.VideoPath))
                {
                    model.Editor = Convert.ToInt32(Session["userid"]);
                    VideoBLL.Create(model);
                }
                else
                {
                    return Content("视频文件不存在，请检查");
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                log4net.LogManager.GetLogger(typeof(VideoController)).Error("添加视频错误", e);
                return Content("添加视频错误");
            }
        }

        
        /// <summary> 检测文件是否存在 </summary>
        /// <param name="file">文件名（含拓展名）</param>
        /// <returns>1表示存在，0表示不存在</returns>
        public ActionResult ValidateFileExist(string file)
        {
            if (VideoBLL.ExistFile(file))
            {
                return Content("1");
            }
            return Content("0");
        }


        public ActionResult Edit(int id)
        {
            return View(VideoBLL.GetModel(id));
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Video model)
        {
            try
            {
                if (VideoBLL.ExistFile(model.VideoPath))
                {
                    model.VideoImage = Request.Form["oldVideoPath"]!=model.VideoPath ? "" : Request.Form["oldVideoImage"];
                    VideoBLL.Update(model);
                }
                else
                {
                    return Content("视频文件不存在，请检查");
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                log4net.LogManager.GetLogger(typeof(VideoController)).Error("添加视频错误", e);
                return Content("添加视频错误");
            }
        }


        public ActionResult Delete(int id)
        {
            try
            {
                VideoBLL.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                log4net.LogManager.GetLogger(typeof (VideoController)).Error("删除视频错误", e);
                return Content("视频删除错误！");
            }
            
        }


        /// <summary> 二审 </summary>
        /// <returns></returns>
        public ActionResult SecondAudit(int id, string powerlist, string state)
        {
            if (VideoBLL.HasSecondTrial(powerlist, state))
            {
                try
                {
                    return View(VideoBLL.GetModel(id));
                }
                catch (Exception e)
                {
                    log4net.LogManager.GetLogger(typeof(VideoController)).Error("加载二审视频" + id + "出错", e);
                    return Content("加载二审视频" + id + "出错！");
                }
            }
            return Content("您没有查看权限！");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SecondAudit(Video model, int secondAudit, string secondAuditReason)
        {
            try
            {
                string aduitId = "";
                if (secondAudit == 1)
                {
                    aduitId = Session["userid"].ToString();
                }
                VideoBLL.SecondAudit(model, aduitId, secondAuditReason);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                log4net.LogManager.GetLogger(typeof(VideoController)).Error("二审错误！", e);
                return Content("二审出现错误，请重新进入");
            }
        }



        /// <summary> 三审 </summary>
        /// <returns></returns>
        public ActionResult ThirdAudit(int id, string powerlist, string state)
        {
            if (VideoBLL.HasThirdTrail(powerlist, state))
            {
                try
                {
                    return View(VideoBLL.GetModel(id));
                }
                catch (Exception e)
                {
                    log4net.LogManager.GetLogger(typeof(VideoController)).Error("加载三审信息错误", e);
                }
            }
            return Content("你没有查看权限！");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThirdAudit(Video model, int thirdAudit, string thirdAuditReason)
        {
            try
            {
                string aduitId = "";
                if (thirdAudit == 1)
                {
                    aduitId = Session["userid"].ToString();
                }
                VideoBLL.ThirdAudit(model, aduitId, thirdAuditReason);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                log4net.LogManager.GetLogger(typeof(VideoController)).Error("三审错误！", e);
                return Content("三审出现错误，请重新进入");
            }
        }

    }
}
