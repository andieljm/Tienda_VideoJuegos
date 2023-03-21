using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Clases
{
    public class Marca
    {
        public IEnumerable<MARCA> Consultar()
        {
            using (TiendaVGEntities db = new TiendaVGEntities())
            {
                return db.MARCA.ToList();
            }
        }

        public void Guardar(MARCA modelo)
        {
            using (TiendaVGEntities db = new TiendaVGEntities())
            {
                db.MARCA.Add(modelo);
                db.SaveChanges();
            }
        }

        public void Modificar(MARCA modelo)
        {
            using (TiendaVGEntities db = new TiendaVGEntities())
            {
                db.Entry(modelo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }
        }

        public void Eliminar(MARCA modelo)
        {
            using (TiendaVGEntities db = new TiendaVGEntities())
            {
                db.Entry(modelo).State = System.Data.Entity.EntityState.Deleted;
                db.MARCA.Remove(modelo);
                db.SaveChanges();
            }
        }

        public MARCA Consultar(int id)
        {
            using (TiendaVGEntities db = new TiendaVGEntities())
            {
                return db.MARCA.FirstOrDefault(x => x.ID_MARCA == id);
            }

        }


    }
}
