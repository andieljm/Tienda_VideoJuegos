using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Clases
{
    public class Periferico
    {
        public IEnumerable<PERIFERICO> Consultar()
        {
            using (TiendaVGEntities db = new TiendaVGEntities())
            {
                return db.PERIFERICO.ToList();
            }
        }

        public void Create(PERIFERICO modelo)
        {
            using (TiendaVGEntities db = new TiendaVGEntities())
            {
                db.PERIFERICO.Add(modelo);
                db.SaveChanges();
            }
        }

        public void Edit(PERIFERICO modelo)
        {
            using (TiendaVGEntities db = new TiendaVGEntities())
            {
                db.Entry(modelo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }
        }

        public void Delete(PERIFERICO modelo)
        {
            using (TiendaVGEntities db = new TiendaVGEntities())
            {
                db.Entry(modelo).State = System.Data.Entity.EntityState.Deleted;
                db.PERIFERICO.Remove(modelo);
                db.SaveChanges();
            }
        }

        public PERIFERICO Details(int id)
        {
            using (TiendaVGEntities db = new TiendaVGEntities())
            {
                return db.PERIFERICO.FirstOrDefault(x => x.ID_PERIFERICO == id);
            }

        }


    }
}
