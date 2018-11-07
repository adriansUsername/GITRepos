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
                UserModel userLoggedIn = 
            }
        }
    }
}