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
    public class koppelmeldingTblsController : Controller
    {
        private SQLContext db = new SQLContext();

        // GET: koppelmeldingTbls
        public ActionResult Index()
        {
            var koppelmeldingTbls = db.koppelmeldingTbls.Include(k => k.meldingenTbl).Include(k => k.nodeTbl);
            return View(koppelmeldingTbls.ToList());
        }

        // GET: koppelmeldingTbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            koppelmeldingTbl koppelmeldingTbl = db.koppelmeldingTbls.Find(id);
            if (koppelmeldingTbl == null)
            {
                return HttpNotFound();
            }
            return View(koppelmeldingTbl);
        }

        // GET: koppelmeldingTbls/Create
        public ActionResult Create()
        {
            ViewBag.meldingId = new SelectList(db.meldingenTbls, "id", "type");
            ViewBag.nodeId = new SelectList(db.nodeTbls, "id", "locatie");
            return View();
        }

        // POST: koppelmeldingTbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nodeId,meldingId")] koppelmeldingTbl koppelmeldingTbl)
        {
            if (ModelState.IsValid)
            {
                db.koppelmeldingTbls.Add(koppelmeldingTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.meldingId = new SelectList(db.meldingenTbls, "id", "type", koppelmeldingTbl.meldingId);
            ViewBag.nodeId = new SelectList(db.nodeTbls, "id", "locatie", koppelmeldingTbl.nodeId);
            return View(koppelmeldingTbl);
        }

        // GET: koppelmeldingTbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            koppelmeldingTbl koppelmeldingTbl = db.koppelmeldingTbls.Find(id);
            if (koppelmeldingTbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.meldingId = new SelectList(db.meldingenTbls, "id", "type", koppelmeldingTbl.meldingId);
            ViewBag.nodeId = new SelectList(db.nodeTbls, "id", "locatie", koppelmeldingTbl.nodeId);
            return View(koppelmeldingTbl);
        }

        // POST: koppelmeldingTbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nodeId,meldingId")] koppelmeldingTbl koppelmeldingTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(koppelmeldingTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.meldingId = new SelectList(db.meldingenTbls, "id", "type", koppelmeldingTbl.meldingId);
            ViewBag.nodeId = new SelectList(db.nodeTbls, "id", "locatie", koppelmeldingTbl.nodeId);
            return View(koppelmeldingTbl);
        }

        // GET: koppelmeldingTbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            koppelmeldingTbl koppelmeldingTbl = db.koppelmeldingTbls.Find(id);
            if (koppelmeldingTbl == null)
            {
                return HttpNotFound();
            }
            return View(koppelmeldingTbl);
        }

        // POST: koppelmeldingTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            koppelmeldingTbl koppelmeldingTbl = db.koppelmeldingTbls.Find(id);
            db.koppelmeldingTbls.Remove(koppelmeldingTbl);
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
