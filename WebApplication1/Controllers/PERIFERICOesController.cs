using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Filtros;
using WebApplication1.Models;

namespace WebApplication1.Views.Home
{
    public class PERIFERICOesController : Controller
    {
        private TiendaVGEntities db = new TiendaVGEntities();

        // GET: PERIFERICOes
        public ActionResult Index()
        {
            var pERIFERICO = db.PERIFERICO.Include(p => p.MARCA);
            return View(pERIFERICO.ToList());
        }

        // GET: PERIFERICOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERIFERICO pERIFERICO = db.PERIFERICO.Find(id);
            if (pERIFERICO == null)
            {
                return HttpNotFound();
            }
            return View(pERIFERICO);
        }
        [VerificarRol]
        // GET: PERIFERICOes/Create
        public ActionResult Create()
        {
            ViewBag.ID_MARCA = new SelectList(db.MARCA, "ID_MARCA", "nombre_marca");
            return View();
        }

        // POST: PERIFERICOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PERIFERICO,nombre_periferico,cant_disp,precio,ID_MARCA")] PERIFERICO pERIFERICO)
        {
            if (ModelState.IsValid)
            {
                db.PERIFERICO.Add(pERIFERICO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_MARCA = new SelectList(db.MARCA, "ID_MARCA", "nombre_marca", pERIFERICO.ID_MARCA);
            return View(pERIFERICO);
        }
        [VerificarRol]
        // GET: PERIFERICOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERIFERICO pERIFERICO = db.PERIFERICO.Find(id);
            if (pERIFERICO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_MARCA = new SelectList(db.MARCA, "ID_MARCA", "nombre_marca", pERIFERICO.ID_MARCA);
            return View(pERIFERICO);
        }

        // POST: PERIFERICOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PERIFERICO,nombre_periferico,cant_disp,precio,ID_MARCA")] PERIFERICO pERIFERICO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pERIFERICO).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_MARCA = new SelectList(db.MARCA, "ID_MARCA", "nombre_marca", pERIFERICO.ID_MARCA);
            return View(pERIFERICO);
        }
        [VerificarRol]
        // GET: PERIFERICOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERIFERICO pERIFERICO = db.PERIFERICO.Find(id);
            if (pERIFERICO == null)
            {
                return HttpNotFound();
            }
            return View(pERIFERICO);
        }

        // POST: PERIFERICOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PERIFERICO pERIFERICO = db.PERIFERICO.Find(id);
            db.PERIFERICO.Remove(pERIFERICO);
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
