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
    public class meldingenTblsController : Controller
    {
        private SQLContext db = new SQLContext();

        // GET: meldingenTbls
        public ActionResult Index()
        {
            return View(db.meldingenTbls.ToList());
        }

        // GET: meldingenTbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            meldingenTbl meldingenTbl = db.meldingenTbls.Find(id);
            if (meldingenTbl == null)
            {
                return HttpNotFound();
            }
            return View(meldingenTbl);
        }

        // GET: meldingenTbls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: meldingenTbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,datum,tijd,type,beschrijving")] meldingenTbl meldingenTbl)
        {
            if (ModelState.IsValid)
            {
                db.meldingenTbls.Add(meldingenTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(meldingenTbl);
        }

        // GET: meldingenTbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            meldingenTbl meldingenTbl = db.meldingenTbls.Find(id);
            if (meldingenTbl == null)
            {
                return HttpNotFound();
            }
            return View(meldingenTbl);
        }

        // POST: meldingenTbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,datum,tijd,type,beschrijving")] meldingenTbl meldingenTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meldingenTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(meldingenTbl);
        }

        // GET: meldingenTbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            meldingenTbl meldingenTbl = db.meldingenTbls.Find(id);
            if (meldingenTbl == null)
            {
                return HttpNotFound();
            }
            return View(meldingenTbl);
        }

        // POST: meldingenTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            meldingenTbl meldingenTbl = db.meldingenTbls.Find(id);
            db.meldingenTbls.Remove(meldingenTbl);
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
