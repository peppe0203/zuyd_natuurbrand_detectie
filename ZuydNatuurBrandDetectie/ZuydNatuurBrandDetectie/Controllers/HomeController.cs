using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nodeTbl nodeTbl = db.nodeTbls.Find(id);
            if (nodeTbl == null)
            {
                return HttpNotFound();
            }

         
            var metingen = db.metingTbls.ToList();
            var meldingen = db.meldingenTbls.ToList();
            var koppeltbl = db.koppelmeldingTbls.ToList();
            List<metingTbl> gevondenMetingen = new List<metingTbl>();
            List<meldingenTbl> gevondenMeldingen = new List<meldingenTbl>();
            List<int> koppeling = new List<int>();

            foreach (var item in metingen)
            {
                if (item.nodeId == id)
                {
                    gevondenMetingen.Add(item);
                }
            }

            foreach (var item in koppeltbl)
            {
                if (item.nodeId == id)
                {
                    koppeling.Add(item.meldingId);
                }
            }

            foreach (var item in koppeling)
            {
                foreach (var melding in meldingen)
                {
                    if (item == melding.id)
                    {
                        gevondenMeldingen.Add(melding);
                    }
                }
            }

            NodeVm model = new NodeVm
            {
                node = nodeTbl,
                metingen = gevondenMetingen,
                meldingen = gevondenMeldingen
            };







            return View(model);
        }

    }
}