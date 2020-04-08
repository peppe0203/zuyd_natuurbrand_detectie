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
    public class metingTblsController : Controller
    {
        private SQLContext db = new SQLContext();

        // GET: metingTbls
        public ActionResult Index()
        {
            var metingTbls = db.metingTbls.Include(m => m.nodeTbl);
            return View(metingTbls.ToList());
        }

        // GET: metingTbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            metingTbl metingTbl = db.metingTbls.Find(id);
            if (metingTbl == null)
            {
                return HttpNotFound();
            }
            return View(metingTbl);
        }

        // GET: metingTbls/Create
        public ActionResult Create()
        {
            ViewBag.nodeId = new SelectList(db.nodeTbls, "id", "locatie");
            return View();
        }

        // POST: metingTbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nodeId,datum,tijd,luchtVochtigheidSensor,grondSensor,diepGrondSensor,temperatuurSensor")] metingTbl metingTbl)
        {
            if (ModelState.IsValid)
            {
                db.metingTbls.Add(metingTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.nodeId = new SelectList(db.nodeTbls, "id", "locatie", metingTbl.nodeId);
            return View(metingTbl);
        }

        // GET: metingTbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            metingTbl metingTbl = db.metingTbls.Find(id);
            if (metingTbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.nodeId = new SelectList(db.nodeTbls, "id", "locatie", metingTbl.nodeId);
            return View(metingTbl);
        }

        // POST: metingTbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nodeId,datum,tijd,luchtVochtigheidSensor,grondSensor,diepGrondSensor,temperatuurSensor")] metingTbl metingTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(metingTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.nodeId = new SelectList(db.nodeTbls, "id", "locatie", metingTbl.nodeId);
            return View(metingTbl);
        }

        // GET: metingTbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            metingTbl metingTbl = db.metingTbls.Find(id);
            if (metingTbl == null)
            {
                return HttpNotFound();
            }
            return View(metingTbl);
        }

        // POST: metingTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            metingTbl metingTbl = db.metingTbls.Find(id);
            db.metingTbls.Remove(metingTbl);
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
