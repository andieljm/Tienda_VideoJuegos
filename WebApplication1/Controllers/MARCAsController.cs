﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Filtros;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MARCAsController : Controller
    {
        private TiendaVGEntities db = new TiendaVGEntities();
        [VerificarRol]
        // GET: MARCAs
        public ActionResult Index()
        {
            return View(db.MARCA.ToList());
        }

        // GET: MARCAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MARCA mARCA = db.MARCA.Find(id);
            if (mARCA == null)
            {
                return HttpNotFound();
            }
            return View(mARCA);
        }

        // GET: MARCAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MARCAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_MARCA,nombre_marca")] MARCA mARCA)
        {
            if (ModelState.IsValid)
            {
                db.MARCA.Add(mARCA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mARCA);
        }

        // GET: MARCAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MARCA mARCA = db.MARCA.Find(id);
            if (mARCA == null)
            {
                return HttpNotFound();
            }
            return View(mARCA);
        }

        // POST: MARCAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_MARCA,nombre_marca")] MARCA mARCA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mARCA).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mARCA);
        }

        // GET: MARCAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MARCA mARCA = db.MARCA.Find(id);
            if (mARCA == null)
            {
                return HttpNotFound();
            }
            return View(mARCA);
        }

        // POST: MARCAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MARCA mARCA = db.MARCA.Find(id);
            db.MARCA.Remove(mARCA);
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
