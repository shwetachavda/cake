using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cake_assignment1.Models;

namespace cake_assignment1.Controllers
{
    public class CakeDescsController : Controller
    {
        private CakeModel db = new CakeModel();

        // GET: CakeDescs
        public async Task<ActionResult> Index()
        {
            var cakeDescs = db.CakeDescs.Include(c => c.Cake);
            return View(await cakeDescs.ToListAsync());
        }

        // GET: CakeDescs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CakeDesc cakeDesc = await db.CakeDescs.FindAsync(id);
            if (cakeDesc == null)
            {
                return HttpNotFound();
            }
            return View(cakeDesc);
        }

        // GET: CakeDescs/Create
        public ActionResult Create()
        {
            ViewBag.CakeID = new SelectList(db.Cakes, "CakeID", "CakeName");
            return View();
        }

        // POST: CakeDescs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CakeID,CakeName,CakesDesc,Rate")] CakeDesc cakeDesc)
        {
            if (ModelState.IsValid)
            {
                db.CakeDescs.Add(cakeDesc);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CakeID = new SelectList(db.Cakes, "CakeID", "CakeName", cakeDesc.CakeID);
            return View(cakeDesc);
        }

        // GET: CakeDescs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CakeDesc cakeDesc = await db.CakeDescs.FindAsync(id);
            if (cakeDesc == null)
            {
                return HttpNotFound();
            }
            ViewBag.CakeID = new SelectList(db.Cakes, "CakeID", "CakeName", cakeDesc.CakeID);
            return View(cakeDesc);
        }

        // POST: CakeDescs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CakeID,CakeName,CakesDesc,Rate")] CakeDesc cakeDesc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cakeDesc).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CakeID = new SelectList(db.Cakes, "CakeID", "CakeName", cakeDesc.CakeID);
            return View(cakeDesc);
        }

        // GET: CakeDescs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CakeDesc cakeDesc = await db.CakeDescs.FindAsync(id);
            if (cakeDesc == null)
            {
                return HttpNotFound();
            }
            return View(cakeDesc);
        }

        // POST: CakeDescs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CakeDesc cakeDesc = await db.CakeDescs.FindAsync(id);
            db.CakeDescs.Remove(cakeDesc);
            await db.SaveChangesAsync();
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
