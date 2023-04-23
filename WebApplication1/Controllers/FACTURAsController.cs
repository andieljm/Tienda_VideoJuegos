using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class FACTURAsController : Controller
    {
        private TiendaVGEntities db = new TiendaVGEntities();

        // GET: FACTURAs
        public ActionResult Facturas()
        {
            return View(db.FACTURA.ToList());
        }

        // GET: FACTURAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FACTURA fACTURA = db.FACTURA.Find(id);
            if (fACTURA == null)
            {
                return HttpNotFound();
            }
            return View(fACTURA);
        }

        // GET: FACTURAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FACTURAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_FACTURA,nombre_dispositivo,detalle,fecha_ingreso,NOMBRE_CLIENTE,TELEFONO")] FACTURA fACTURA)
        {
            if (ModelState.IsValid)
            {
                db.FACTURA.Add(fACTURA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fACTURA);
        }

        // GET: FACTURAs/Edit/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FACTURA fACTURA = db.FACTURA.Find(id);
            if (fACTURA == null)
            {
                return HttpNotFound();
            }
            return View(fACTURA);
        }

        // POST: FACTURAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "ID_FACTURA,nombre_dispositivo,detalle,fecha_ingreso,NOMBRE_CLIENTE,TELEFONO")] FACTURA fACTURA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fACTURA).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fACTURA);
        }

        // GET: FACTURAs/Delete/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FACTURA fACTURA = db.FACTURA.Find(id);
            if (fACTURA == null)
            {
                return HttpNotFound();
            }
            return View(fACTURA);
        }

        // POST: FACTURAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FACTURA fACTURA = db.FACTURA.Find(id);
            db.FACTURA.Remove(fACTURA);
            db.SaveChanges();
            return RedirectToAction("Facturas");
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
