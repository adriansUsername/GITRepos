using DataAccessLayer;
using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
    public class UserController : Controller
    {
        UserDataAccess userDA = new UserDataAccess();
        ErrorDataAccess errorDA = new ErrorDataAccess();

        // GET: User
        public ActionResult Login()
        {
            UserViewModel model = new UserViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(UserViewModel model)
        {
            ActionResult result = View(model);

            try
            {
                // log the user in and if works it will return the user
                UserModel userLoggedIn = MapperModel.map(userDA.login(model.singleUser.userName, model.singleUser.userPassword));

                if (userLoggedIn != null)
                {
                    Session["UserName"] = userLoggedIn.userName;
                    Session["UserRoleID"] = userLoggedIn.userRoleID;
                    result = RedirectToAction("Index", "Home");
                }
            }
            catch (Exception error)
            {
                // log the error to the error data access
                errorDA.addError(error);
            }

            return result;
        }

        public ActionResult Register()
        {
            UserViewModel model = new UserViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(UserViewModel model)
        {
            ActionResult result = View(model);

            try
            {
                // Automatically log a user in if they register
                result = Login(model);
            }
            catch (Exception error)
            {
                // log the error to the error data access
                errorDA.addError(error);
            }

            return result;
        }
    }
}