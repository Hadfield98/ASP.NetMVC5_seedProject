using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SmartAdminMvc.Models;

namespace SmartAdminMvc.Controllers
{
    public class TenderersController : Controller
    {
        private SmartAdminMvcContext db = new SmartAdminMvcContext();

        // GET: Tenderers
        public async Task<ActionResult> Index()
        {
            return View(await db.Tenderers.ToListAsync());
        }

        // GET: Tenderers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tenderers tenderers = await db.Tenderers.FindAsync(id);
            if (tenderers == null)
            {
                return HttpNotFound();
            }
            return View(tenderers);
        }

        // GET: Tenderers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tenderers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TenderersId,Name")] Tenderers tenderers)
        {
            if (ModelState.IsValid)
            {
                db.Tenderers.Add(tenderers);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tenderers);
        }

        // GET: Tenderers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tenderers tenderers = await db.Tenderers.FindAsync(id);
            if (tenderers == null)
            {
                return HttpNotFound();
            }
            return View(tenderers);
        }

        // POST: Tenderers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TenderersId,Name")] Tenderers tenderers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tenderers).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tenderers);
        }

        // GET: Tenderers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tenderers tenderers = await db.Tenderers.FindAsync(id);
            if (tenderers == null)
            {
                return HttpNotFound();
            }
            return View(tenderers);
        }

        // POST: Tenderers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Tenderers tenderers = await db.Tenderers.FindAsync(id);
            db.Tenderers.Remove(tenderers);
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
