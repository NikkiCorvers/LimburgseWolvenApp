using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LimburgseWolvenApp.Models;
using LimburgseWolvenApp.DAL;

namespace LimburgseWolvenApp.Controllers
{
    public class MaakDorpController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: /MaakDorp/
        public ActionResult Index()
        {
            return View(db.Dorpen.ToList());
        }

        // GET: /MaakDorp/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dorp dorp = db.Dorpen.Find(id);
            if (dorp == null)
            {
                return HttpNotFound();
            }

            return View(dorp);
        }

        // GET: /MaakDorp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /MaakDorp/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="DorpID,Naam")] Dorp dorp)
        {
            if (ModelState.IsValid)
            {
                db.Dorpen.Add(dorp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dorp);
        }

        // GET: /MaakDorp/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dorp dorp = db.Dorpen.Find(id);
            if (dorp == null)
            {
                return HttpNotFound();
            }
            return View(dorp);
        }

        // POST: /MaakDorp/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="DorpID,Naam")] Dorp dorp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dorp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dorp);
        }

        // GET: /MaakDorp/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dorp dorp = db.Dorpen.Find(id);
            if (dorp == null)
            {
                return HttpNotFound();
            }
            return View(dorp);
        }

        // POST: /MaakDorp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dorp dorp = db.Dorpen.Find(id);
            db.Dorpen.Remove(dorp);
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
