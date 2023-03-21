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
    public class VIDEOJUEGOesController : Controller
    {
        private TiendaVGEntities db = new TiendaVGEntities();

        // GET: VIDEOJUEGOes
        public ActionResult Index()
        {
            var vIDEOJUEGO = db.VIDEOJUEGO.Include(v => v.CONSOLA);
            return View(vIDEOJUEGO.ToList());
        }

        // GET: VIDEOJUEGOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VIDEOJUEGO vIDEOJUEGO = db.VIDEOJUEGO.Find(id);
            if (vIDEOJUEGO == null)
            {
                return HttpNotFound();
            }
            return View(vIDEOJUEGO);
        }

        // GET: VIDEOJUEGOes/Create
        public ActionResult Create()
        {
            ViewBag.ID_CONSOLA = new SelectList(db.CONSOLA, "ID_CONSOLA", "nombre_consola");
            return View();
        }

        // POST: VIDEOJUEGOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_VIDEOJUEGO,nombre_videojuego,cant_disp,precio,ID_CONSOLA")] VIDEOJUEGO vIDEOJUEGO)
        {
            if (ModelState.IsValid)
            {
                db.VIDEOJUEGO.Add(vIDEOJUEGO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CONSOLA = new SelectList(db.CONSOLA, "ID_CONSOLA", "nombre_consola", vIDEOJUEGO.ID_CONSOLA);
            return View(vIDEOJUEGO);
        }

        // GET: VIDEOJUEGOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VIDEOJUEGO vIDEOJUEGO = db.VIDEOJUEGO.Find(id);
            if (vIDEOJUEGO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CONSOLA = new SelectList(db.CONSOLA, "ID_CONSOLA", "nombre_consola", vIDEOJUEGO.ID_CONSOLA);
            return View(vIDEOJUEGO);
        }

        // POST: VIDEOJUEGOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_VIDEOJUEGO,nombre_videojuego,cant_disp,precio,ID_CONSOLA")] VIDEOJUEGO vIDEOJUEGO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vIDEOJUEGO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CONSOLA = new SelectList(db.CONSOLA, "ID_CONSOLA", "nombre_consola", vIDEOJUEGO.ID_CONSOLA);
            return View(vIDEOJUEGO);
        }

        // GET: VIDEOJUEGOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VIDEOJUEGO vIDEOJUEGO = db.VIDEOJUEGO.Find(id);
            if (vIDEOJUEGO == null)
            {
                return HttpNotFound();
            }
            return View(vIDEOJUEGO);
        }

        // POST: VIDEOJUEGOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VIDEOJUEGO vIDEOJUEGO = db.VIDEOJUEGO.Find(id);
            db.VIDEOJUEGO.Remove(vIDEOJUEGO);
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
