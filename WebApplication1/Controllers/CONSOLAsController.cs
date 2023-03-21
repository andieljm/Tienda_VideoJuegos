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
    public class CONSOLAsController : Controller
    {
        private TiendaVGEntities db = new TiendaVGEntities();

        // GET: CONSOLAs
        public ActionResult Index()
        {
            var cONSOLA = db.CONSOLA.Include(c => c.MARCA);
            return View(cONSOLA.ToList());
        }

        // GET: CONSOLAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONSOLA cONSOLA = db.CONSOLA.Find(id);
            if (cONSOLA == null)
            {
                return HttpNotFound();
            }
            return View(cONSOLA);
        }

        // GET: CONSOLAs/Create
        public ActionResult Create()
        {
            ViewBag.ID_MARCA = new SelectList(db.MARCA, "ID_MARCA", "nombre_marca");
            return View();
        }

        // POST: CONSOLAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_CONSOLA,nombre_consola,cant_disp,precio,ID_MARCA")] CONSOLA cONSOLA)
        {
            if (ModelState.IsValid)
            {
                db.CONSOLA.Add(cONSOLA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_MARCA = new SelectList(db.MARCA, "ID_MARCA", "nombre_marca", cONSOLA.ID_MARCA);
            return View(cONSOLA);
        }

        // GET: CONSOLAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONSOLA cONSOLA = db.CONSOLA.Find(id);
            if (cONSOLA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_MARCA = new SelectList(db.MARCA, "ID_MARCA", "nombre_marca", cONSOLA.ID_MARCA);
            return View(cONSOLA);
        }

        // POST: CONSOLAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_CONSOLA,nombre_consola,cant_disp,precio,ID_MARCA")] CONSOLA cONSOLA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cONSOLA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_MARCA = new SelectList(db.MARCA, "ID_MARCA", "nombre_marca", cONSOLA.ID_MARCA);
            return View(cONSOLA);
        }

        // GET: CONSOLAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONSOLA cONSOLA = db.CONSOLA.Find(id);
            if (cONSOLA == null)
            {
                return HttpNotFound();
            }
            return View(cONSOLA);
        }

        // POST: CONSOLAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CONSOLA cONSOLA = db.CONSOLA.Find(id);
            db.CONSOLA.Remove(cONSOLA);
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
