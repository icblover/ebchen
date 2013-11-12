using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZCJ.BLL;

namespace Web.Areas.Account.Controllers
{
    public class ArticleCommentController : Controller
    {
        public ActionResult Index(int id = 0)
        {
            return View(ArticleCommentBLL.PagedList("", id));
        }

        /// <summary> 删除 </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            try
            {
                ArticleCommentBLL.Delete(id);
            }
            catch (Exception e)
            {
                log4net.LogManager.GetLogger(typeof(ArticleCommentController)).Error("删除文章评论错误", e);
            }
            return RedirectToAction("Index");
        }
    }
}
