using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cake_assignment1.Models;

namespace cake_assignment1.Controllers
{
    public class CakesController : Controller
    {
        private CakeModel db = new CakeModel();

        // GET: Cakes
        public ActionResult Index()
        {
            var cakes = db.Cakes.Include(c => c.CakeDesc);
            return View(cakes.ToList());
        }

        // GET: Cakes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cake cake = db.Cakes.Find(id);
            if (cake == null)
            {
                return HttpNotFound();
            }
            return View(cake);
        }

        // GET: Cakes/Create
        public ActionResult Create()
        {
            ViewBag.CakeID = new SelectList(db.CakeDescs, "CakeID", "CakeName");
            return View();
        }

        // POST: Cakes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CakeID,CakeName")] Cake cake)
        {
            if (ModelState.IsValid)
            {
                db.Cakes.Add(cake);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CakeID = new SelectList(db.CakeDescs, "CakeID", "CakeName", cake.CakeID);
            return View(cake);
        }

        // GET: Cakes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cake cake = db.Cakes.Find(id);
            if (cake == null)
            {
                return HttpNotFound();
            }
            ViewBag.CakeID = new SelectList(db.CakeDescs, "CakeID", "CakeName", cake.CakeID);
            return View(cake);
        }

        // POST: Cakes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CakeID,CakeName")] Cake cake)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cake).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CakeID = new SelectList(db.CakeDescs, "CakeID", "CakeName", cake.CakeID);
            return View(cake);
        }

        // GET: Cakes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cake cake = db.Cakes.Find(id);
            if (cake == null)
            {
                return HttpNotFound();
            }
            return View(cake);
        }

        // POST: Cakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cake cake = db.Cakes.Find(id);
            db.Cakes.Remove(cake);
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
