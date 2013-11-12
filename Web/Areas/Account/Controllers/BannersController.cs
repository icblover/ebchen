using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZCJ.Model;
using ZCJ.BLL;

namespace Web.Areas.Account.Controllers
{
    public class BannersController : Controller
    {
        //
        // GET: /Account/Banners/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(Banners model)
        {
            return View();
        }
    }
}
