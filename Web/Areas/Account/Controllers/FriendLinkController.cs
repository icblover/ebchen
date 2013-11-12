using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZCJ.Model;
using ZCJ.BLL;

namespace Web.Areas.Account.Controllers
{
    public class FriendLinkController : Controller
    {
        //
        // GET: /Account/FriendLink/
        public ActionResult Index()
        {
            return View(FriendLinkBLL.GetAllList());
        }


        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FriendLink model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Request.Files.Count > 0)
                    {
                        string ImagePath = FriendLinkBLL.UploadImg(Request.Files[0]);
                        if (ImagePath != "")
                        {
                            model.LinkLogo = ImagePath;
                        }
                    }
                    else
                    {
                        model.LinkLogo = "";
                    }
                    FriendLinkBLL.Add(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception e)
            {
                log4net.LogManager.GetLogger(typeof(FriendLinkController)).Error("添加友情链接出错！", e);
                return View();
            }
        }


        public ActionResult Edit(int id)
        {
            return View(FriendLinkBLL.GetModel(id));
        }
        [HttpPost]
        public ActionResult Edit(FriendLink model)
        {
            try
            {
                if (Request.Files.Count > 0)
                {
                    string ImagePath = FriendLinkBLL.UploadImg(Request.Files[0]);
                    if (ImagePath != "")
                    {
                        model.LinkLogo = ImagePath;
                    }
                }
                else if (model.LinkLogo == null)
                {
                    model.LinkLogo = Request.Form["HideLinkLogo"];
                }
                FriendLinkBLL.Update(model);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                log4net.LogManager.GetLogger(typeof(FriendLinkController)).Error("友情链接修改错误！", e);
                return RedirectToAction("Index");
            }
        }

        
        public ActionResult Delete(int id)
        {
            FriendLinkBLL.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
