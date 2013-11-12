using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZCJ.Model;
using ZCJ.BLL;

namespace Web.Areas.Account.Controllers
{
    public class ManagerRoleController : Controller
    {
        /// <summary> 列表 </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(ManagerRoleBLL.GetAllList());
        }

        /// <summary> 新增 </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ManagerRole model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ManagerRoleBLL.Add(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception e)
            {
                log4net.LogManager.GetLogger(typeof(ManagerRoleController)).Error("添加角色", e);
                return Content("添加角色出错，请重新进入操作！");
            }
        }


        /// <summary> 修改 </summary>
        /// <param name="id">修改id</param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            return View(ManagerRoleBLL.GetModel(id));
        }
        [HttpPost]
        public ActionResult Edit(ManagerRole model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ManagerRoleBLL.Update(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception e)
            {
                log4net.LogManager.GetLogger(typeof(ManagerRoleController)).Error("修改角色信息错误", e);
                return Content("修改角色信息错误,请重新进入！");
            }
        }


        public ActionResult Delete(int id)
        {
            try
            {
                ManagerRoleBLL.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                log4net.LogManager.GetLogger(typeof(ManagerRoleController)).Error("删除角色信息错误", e);
                return Content("删除角色信息错误,请联系管理员！");
            }
        }

    }
}
