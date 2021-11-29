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
    public class detalle_facturaController : Controller
    {
        private SPEED_RACEREntities db = new SPEED_RACEREntities();

        // GET: detalle_factura
        public ActionResult Index()
        {
            var detalle_factura = db.detalle_factura.Include(d => d.Cliente).Include(d => d.Vehiculo).Include(d => d.Venta);
            return View(detalle_factura.ToList());
        }

        // GET: detalle_factura/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalle_factura detalle_factura = db.detalle_factura.Find(id);
            if (detalle_factura == null)
            {
                return HttpNotFound();
            }
            return View(detalle_factura);
        }

        // GET: detalle_factura/Create
        public ActionResult Create()
        {
            ViewBag.idPersona = new SelectList(db.Cliente, "id_Cliente", "nombres");
            ViewBag.idArticulo = new SelectList(db.Vehiculo, "IdVehiculo", "Marca");
            ViewBag.idVenta = new SelectList(db.Venta, "idVenta", "num_comprobante");
            return View();
        }

        // POST: detalle_factura/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idDetalle_venta,idVenta,idArticulo,idPersona,cantidad,precio,descuento")] detalle_factura detalle_factura)
        {
            if (ModelState.IsValid)
            {
                db.detalle_factura.Add(detalle_factura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPersona = new SelectList(db.Cliente, "id_Cliente", "nombres", detalle_factura.idPersona);
            ViewBag.idArticulo = new SelectList(db.Vehiculo, "IdVehiculo", "Marca", detalle_factura.idArticulo);
            ViewBag.idVenta = new SelectList(db.Venta, "idVenta", "num_comprobante", detalle_factura.idVenta);
            return View(detalle_factura);
        }

        // GET: detalle_factura/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalle_factura detalle_factura = db.detalle_factura.Find(id);
            if (detalle_factura == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPersona = new SelectList(db.Cliente, "id_Cliente", "nombres", detalle_factura.idPersona);
            ViewBag.idArticulo = new SelectList(db.Vehiculo, "IdVehiculo", "Marca", detalle_factura.idArticulo);
            ViewBag.idVenta = new SelectList(db.Venta, "idVenta", "num_comprobante", detalle_factura.idVenta);
            return View(detalle_factura);
        }

        // POST: detalle_factura/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idDetalle_venta,idVenta,idArticulo,idPersona,cantidad,precio,descuento")] detalle_factura detalle_factura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalle_factura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPersona = new SelectList(db.Cliente, "id_Cliente", "nombres", detalle_factura.idPersona);
            ViewBag.idArticulo = new SelectList(db.Vehiculo, "IdVehiculo", "Marca", detalle_factura.idArticulo);
            ViewBag.idVenta = new SelectList(db.Venta, "idVenta", "num_comprobante", detalle_factura.idVenta);
            return View(detalle_factura);
        }

        // GET: detalle_factura/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalle_factura detalle_factura = db.detalle_factura.Find(id);
            if (detalle_factura == null)
            {
                return HttpNotFound();
            }
            return View(detalle_factura);
        }

        // POST: detalle_factura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            detalle_factura detalle_factura = db.detalle_factura.Find(id);
            db.detalle_factura.Remove(detalle_factura);
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
