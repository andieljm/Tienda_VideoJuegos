using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Filtros;

namespace WebApplication1.Controllers
{
    public class TALLERsController : Controller
    {
        private TiendaVGEntities db = new TiendaVGEntities();

        // GET: TALLERs
        
        public ActionResult Index()
        {
         
            return View(db.TALLER.ToList());
        }

        // GET: TALLERs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TALLER tALLER = db.TALLER.Find(id);
            if (tALLER == null)
            {
                return HttpNotFound();
            }
            return View(tALLER);
        }
        [VerificarRol]
        // GET: TALLERs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TALLERs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_REPARACION,nombre_dispositivo,detalle,fecha_ingreso,telefono,Nombre_cliente")] TALLER tALLER)
        {
            if (ModelState.IsValid)
            {
                db.TALLER.Add(tALLER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tALLER);
        }
        [VerificarRol]
        // GET: TALLERs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TALLER tALLER = db.TALLER.Find(id);
            if (tALLER == null)
            {
                return HttpNotFound();
            }
            return View(tALLER);
        }

        // POST: TALLERs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_REPARACION,nombre_dispositivo,detalle,fecha_ingreso,telefono,Nombre_cliente")] TALLER tALLER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tALLER).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tALLER);
        }
        [VerificarRol]
        // GET: TALLERs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TALLER tALLER = db.TALLER.Find(id);
            if (tALLER == null)
            {
                return HttpNotFound();
            }
            return View(tALLER);
        }

        // POST: TALLERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TALLER tALLER = db.TALLER.Find(id);
            db.TALLER.Remove(tALLER);
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
