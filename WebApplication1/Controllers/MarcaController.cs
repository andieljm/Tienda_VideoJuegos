using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Clases;

namespace WebApplication1.Controllers
{
    public class MarcaController : Controller
    {
        Marca instanciaMarca = new Marca();
        // GET: Marca

        public ActionResult Index()
        {
            IEnumerable<MARCA> lst = instanciaMarca.Consultar();
            return View(lst);
        }

        public ActionResult Guardar(MARCA modelo)
        {
            ViewBag.Mensaje = "";
            return View(modelo);
        }
        public ActionResult Nuevo(MARCA modelo)
        {
            instanciaMarca.Guardar(modelo);
            ViewBag.Mensaje = "El alumno se guardo correctamente.";
            return View("Guardar", modelo);
        }

        public ActionResult Modificar(int id)
        {
            MARCA modelo = instanciaMarca.Consultar(id);
            ViewBag.Mensaje = "";
            return View(modelo);
        }
        public ActionResult Cambiar(MARCA modelo)
        {
            instanciaMarca.Modificar(modelo);
            ViewBag.Mensaje = "El alumno se modifico correctamente.";
            return View("Modificar", modelo);
        }

        public ActionResult Detalle(int id)
        {
            MARCA modelo = instanciaMarca.Consultar(id);
            return View(modelo);
        }

        public ActionResult Eliminar(int id)
        {
            MARCA modelo = new MARCA()
            {
                ID_MARCA = id
            };
            instanciaMarca.Eliminar(modelo);
            ViewBag.Mensaje = "El alumno se elimino correctamente ";
            IEnumerable<MARCA> lst = instanciaMarca.Consultar();
            return View("Index", lst);
        }

    }
}