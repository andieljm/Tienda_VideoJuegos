using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Clases
{
    public class Videojuego
    {
        public IEnumerable<VIDEOJUEGO> Consultar()
        {
            using (TiendaVGEntities db = new TiendaVGEntities())
            {
                return db.VIDEOJUEGO.ToList();
            }
        }

        public void Create(VIDEOJUEGO modelo)
        {
            using (TiendaVGEntities db = new TiendaVGEntities())
            {
                db.VIDEOJUEGO.Add(modelo);
                db.SaveChanges();
            }
        }

        public void Edit(VIDEOJUEGO modelo)
        {
            using (TiendaVGEntities db = new TiendaVGEntities())
            {
                db.Entry(modelo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }
        }

        public void Delete(VIDEOJUEGO modelo)
        {
            using (TiendaVGEntities db = new TiendaVGEntities())
            {
                db.Entry(modelo).State = System.Data.Entity.EntityState.Deleted;
                db.VIDEOJUEGO.Remove(modelo);
                db.SaveChanges();
            }
        }

        public VIDEOJUEGO Details(int id)
        {
            using (TiendaVGEntities db = new TiendaVGEntities())
            {
                return db.VIDEOJUEGO.FirstOrDefault(x => x.ID_VIDEOJUEGO == id);
            }

        }


    }
}