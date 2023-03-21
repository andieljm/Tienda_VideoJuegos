using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Clases
{
    public class Consola
    {
        public IEnumerable<CONSOLA> Consultar()
        {
            using (TiendaVGEntities db = new TiendaVGEntities())
            {
                return db.CONSOLA.ToList();
            }
        }

        public void Create(CONSOLA modelo)
        {
            using (TiendaVGEntities db = new TiendaVGEntities())
            {
                db.CONSOLA.Add(modelo);
                db.SaveChanges();
            }
        }

        public void Edit(CONSOLA modelo)
        {
            using (TiendaVGEntities db = new TiendaVGEntities())
            {
                db.Entry(modelo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }
        }

        public void Delete(CONSOLA modelo)
        {
            using (TiendaVGEntities db = new TiendaVGEntities())
            {
                db.Entry(modelo).State = System.Data.Entity.EntityState.Deleted;
                db.CONSOLA.Remove(modelo);
                db.SaveChanges();
            }
        }

        public CONSOLA Details(int id)
        {
            using (TiendaVGEntities db = new TiendaVGEntities())
            {
                return db.CONSOLA.FirstOrDefault(x => x.ID_CONSOLA == id);
            }

        }


    }
}