using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZuydNatuurBrandDetectie.Models;

namespace ZuydNatuurBrandDetectie.Controllers
{
    public class nodeTblsController : Controller
    {
        private SQLContext db = new SQLContext();

        // GET: nodeTbls
        public ActionResult Index()
        {
            return View(db.nodeTbls.ToList());
        }

        // GET: nodeTbls/Details/5
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
            return View(nodeTbl);
        }

        // GET: nodeTbls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: nodeTbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,locatie,natuurgebied,actief,batterijVervangen")] nodeTbl nodeTbl)
        {
            if (ModelState.IsValid)
            {
                db.nodeTbls.Add(nodeTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nodeTbl);
        }

        // GET: nodeTbls/Edit/5
        public ActionResult Edit(int? id)
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
            return View(nodeTbl);
        }

        // POST: nodeTbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,locatie,natuurgebied,actief,batterijVervangen")] nodeTbl nodeTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nodeTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nodeTbl);
        }

        // GET: nodeTbls/Delete/5
        public ActionResult Delete(int? id)
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
            return View(nodeTbl);
        }

        // POST: nodeTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            nodeTbl nodeTbl = db.nodeTbls.Find(id);
            db.nodeTbls.Remove(nodeTbl);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
