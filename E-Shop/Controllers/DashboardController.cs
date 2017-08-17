using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Shop.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace E_Shop.Controllers
{
    public class DashboardController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: Dashboard
        public ActionResult Index()
        {
            if (isAdmin())
            {
                return View("Admin");
            }else if (isManager())
            {
                return View("Manager");
            }

            return View();
        }

        private Boolean isAdmin()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;  
        }

        private Boolean isManager()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Manager"))
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}