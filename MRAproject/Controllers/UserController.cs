using MRAproject.Models;
using MRAproject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRAproject.Controllers
{
    public class UserController : Controller
    {
        [SessionBasedAuthorizeAttribute(Role=Role.Type.Admin)]
        public ActionResult LoadRegisterUser(string name)
        {
            LoadRegisterUserViewModel vm = new LoadRegisterUserViewModel();

            if (TempData["msg"] != null)
                vm.resultMessage = TempData["msg"].ToString();

            if (TempData["IsEditMode"] != null)
            {
                vm.IsEditMode = true;
                User u = UserService.GetByID(id: System.Convert.ToInt32(TempData["UserID"]));

                vm.ID = u.ID;
                vm.Name = u.Name;
                vm.LastName = u.LastName;
                vm.Phone = u.Phone;
                vm.EmailAddress = u.EmailAddress;
                vm.Caption = u.Caption;
            }

            vm.Users = UserService.Get(name: name);

            return View(vm);
        }
        public ActionResult GetAll(string name)
        {
            LoadRegisterUserViewModel vm = new LoadRegisterUserViewModel();

            if (TempData["msg"] != null)
                vm.resultMessage = TempData["msg"].ToString();

            if (TempData["IsEditMode"] != null)
            {
                vm.IsEditMode = true;
                User U = UserService.GetByID(id: System.Convert.ToInt32(TempData["UserID"]));

                vm.ID = U.ID;
                vm.Name = U.Name;
                vm.LastName = U.LastName;
                vm.Phone = U.Phone;
                vm.EmailAddress = U.EmailAddress;
                vm.Caption = U.Caption;
            }

            vm.Users = UserService.Get(name: name);

            return View(UserService.Get());
        }
        [HttpPost]
        public ActionResult RegisterUser(LoadRegisterUserViewModel vm)
        {
            if (vm != null)
            {
                User U = new User()
                {
                    Name = vm.Name,
                    LastName = vm.LastName,
                    Phone = vm.Phone,
                    EmailAddress = vm.EmailAddress,
                    Caption = vm.Caption
                };

                string message = UserService.Register(U);
                TempData["msg"] = message;
            }
            else
            {
                TempData["msg"] = "اطلاعات ناقص است";
            }
            return RedirectToAction("LoadRegisterUser");
        }


        [HttpPost]
        public ActionResult EditPerson(LoadRegisterUserViewModel vm)
        {
            if (vm != null)
            {
                User u = new User()
                {
                    Name = vm.Name,
                    LastName = vm.LastName,
                    Phone = vm.Phone,
                    EmailAddress = vm.EmailAddress,
                    Caption = vm.Caption,
                    ID = vm.ID
                };

                string message = UserService.Edit(u);
                TempData["msg"] = message;
            }
            else
            {
                TempData["msg"] = "اطلاعات ناقص است";
            }
            return RedirectToAction("LoadRegisterPerson");
        }

        public ActionResult ChangeToEditPersonMode(int id)
        {
            TempData["IsEditMode"] = true;
            TempData["UserID"] = id;
            return RedirectToAction("LoadRegisterPerson");
        }

        [HttpGet]
        public ActionResult Search(string name)
        {
            return RedirectToAction("LoadRegisterPerson", new { name = name });
        }
    }
}