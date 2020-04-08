using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZuydNatuurBrandDetectie.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(ZuydNatuurBrandDetectie.Models.user userModel)
        {
            Session["Function"] = userModel.name;
            return RedirectToAction("Index", "home");
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "home");
        }
    }
}