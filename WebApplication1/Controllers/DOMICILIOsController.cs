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
    public class DOMICILIOsController : Controller
    {
        private TiendaVGEntities db = new TiendaVGEntities();

        // GET: DOMICILIOs
        public ActionResult Index()
        {
            var dOMICILIO = db.DOMICILIO.Include(d => d.AspNetUsers);
            return View(dOMICILIO.ToList());
        }

        // GET: DOMICILIOs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOMICILIO dOMICILIO = db.DOMICILIO.Find(id);
            if (dOMICILIO == null)
            {
                return HttpNotFound();
            }
            return View(dOMICILIO);
        }

        // GET: DOMICILIOs/Create
        public ActionResult Create()
        {
            ViewBag.ID_USUARIO = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: DOMICILIOs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_DOMICILIO,provincia,ciudad,canton,direccion,ID_USUARIO")] DOMICILIO dOMICILIO)
        {
            if (ModelState.IsValid)
            {
                db.DOMICILIO.Add(dOMICILIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_USUARIO = new SelectList(db.AspNetUsers, "Id", "Email", dOMICILIO.ID_USUARIO);
            return View(dOMICILIO);
        }

        // GET: DOMICILIOs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOMICILIO dOMICILIO = db.DOMICILIO.Find(id);
            if (dOMICILIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_USUARIO = new SelectList(db.AspNetUsers, "Id", "Email", dOMICILIO.ID_USUARIO);
            return View(dOMICILIO);
        }

        // POST: DOMICILIOs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_DOMICILIO,provincia,ciudad,canton,direccion,ID_USUARIO")] DOMICILIO dOMICILIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dOMICILIO).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_USUARIO = new SelectList(db.AspNetUsers, "Id", "Email", dOMICILIO.ID_USUARIO);
            return View(dOMICILIO);
        }

        // GET: DOMICILIOs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOMICILIO dOMICILIO = db.DOMICILIO.Find(id);
            if (dOMICILIO == null)
            {
                return HttpNotFound();
            }
            return View(dOMICILIO);
        }

        // POST: DOMICILIOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DOMICILIO dOMICILIO = db.DOMICILIO.Find(id);
            db.DOMICILIO.Remove(dOMICILIO);
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
