using MRAproject.Models;
using MRAproject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRAproject.Controllers
{
    public class AdminController : Controller
    {
        [SessionBasedAuthorizeAttribute(Role = Role.Type.Admin)]
        // GET: Admin
        public ActionResult LoadLogin(string msg)
        {
            LoadLoginViewModel vm = new LoadLoginViewModel();
            vm.Message = msg;
            return View(vm);
        }

        [HttpPost]
        public ActionResult Login(LoadLoginViewModel vm)
        {
            Admin A = null;
            if (AdminService.Login(vm.Id,vm.UserName, vm.Password, out A))
            {
                Session[StaticS.UserSession] = A;
                return RedirectToAction("LoadRegisterUserViewModel", "User");
            }
            return RedirectToAction("LoadLogin", new { msg = "نام کاربری یا رمز عیور اشنباه است" });
        }

        public ActionResult LogOut()
        {
            Session[StaticS.UserSession] = null;
            return RedirectToAction("LoadLogin");
        }
    }
}