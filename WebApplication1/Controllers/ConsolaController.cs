using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Clases;

namespace WebApplication1.Controllers
{
    public class ConsolaController : Controller
    {
        Consola instanciaConsola = new Consola();
        // GET: Consola

        public ActionResult Index()
        {
            IEnumerable<CONSOLA> lst = instanciaConsola.Consultar();
            return View(lst);
        }

        public ActionResult Guardar(CONSOLA modelo)
        {
            ViewBag.Mensaje = "";
            return View(modelo);
        }
        public ActionResult Nuevo(CONSOLA modelo)
        {
            instanciaConsola.Guardar(modelo);
            ViewBag.Mensaje = "El alumno se guardo correctamente.";
            return View("Guardar", modelo);
        }

        public ActionResult Modificar(int id)
        {
            CONSOLA modelo = instanciaConsola.Consultar(id);
            ViewBag.Mensaje = "";
            return View(modelo);
        }
        public ActionResult Cambiar(CONSOLA modelo)
        {
            instanciaConsola.Modificar(modelo);
            ViewBag.Mensaje = "El alumno se modifico correctamente.";
            return View("Modificar", modelo);
        }

        public ActionResult Detalle(int id)
        {
            CONSOLA modelo = instanciaConsola.Consultar(id);
            return View(modelo);
        }

        public ActionResult Eliminar(int id)
        {
            CONSOLA modelo = new CONSOLA()
            {
                ID_CONSOLA = id
            };
            instanciaConsola.Eliminar(modelo);
            ViewBag.Mensaje = "El alumno se elimino correctamente ";
            IEnumerable<CONSOLA> lst = instanciaConsola.Consultar();
            return View("Index", lst);
        }

    }

}
