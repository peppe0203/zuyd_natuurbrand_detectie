using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZuydNatuurBrandDetectie.Models;

namespace ZuydNatuurBrandDetectie.Controllers
{
    public class HomeController : Controller
    {
        private SQLContext db = new SQLContext();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Help()
        {
            return View();
        }

        public ActionResult Over()
        {
            return View();
        }

        public ActionResult Overzicht()
        {
            var nodes = db.nodeTbls.ToList();
            var metingen = db.metingTbls.ToList();
            var meldingen = db.meldingenTbls.ToList();

            IndexVm model = new IndexVm();
            model.nodes = nodes;
            model.metingen = metingen;
            model.meldingen = meldingen;

            return View(model);
        }

        public ActionResult Mainpage()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

    }
}