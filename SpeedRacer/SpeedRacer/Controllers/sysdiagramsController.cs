using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SpeedRacer.Models;

namespace SpeedRacer.Controllers
{
    public class sysdiagramsController : Controller
    {
        private SPEED_RACEREntities db = new SPEED_RACEREntities();

        // GET: sysdiagrams
        public ActionResult Index()
        {
            return View(db.sysdiagrams.ToList());
        }

        // GET: sysdiagrams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sysdiagrams sysdiagrams = db.sysdiagrams.Find(id);
            if (sysdiagrams == null)
            {
                return HttpNotFound();
            }
            return View(sysdiagrams);
        }

        // GET: sysdiagrams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: sysdiagrams/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "name,principal_id,diagram_id,version,definition")] sysdiagrams sysdiagrams)
        {
            if (ModelState.IsValid)
            {
                db.sysdiagrams.Add(sysdiagrams);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sysdiagrams);
        }

        // GET: sysdiagrams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sysdiagrams sysdiagrams = db.sysdiagrams.Find(id);
            if (sysdiagrams == null)
            {
                return HttpNotFound();
            }
            return View(sysdiagrams);
        }

        // POST: sysdiagrams/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "name,principal_id,diagram_id,version,definition")] sysdiagrams sysdiagrams)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sysdiagrams).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sysdiagrams);
        }

        // GET: sysdiagrams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sysdiagrams sysdiagrams = db.sysdiagrams.Find(id);
            if (sysdiagrams == null)
            {
                return HttpNotFound();
            }
            return View(sysdiagrams);
        }

        // POST: sysdiagrams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sysdiagrams sysdiagrams = db.sysdiagrams.Find(id);
            db.sysdiagrams.Remove(sysdiagrams);
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
