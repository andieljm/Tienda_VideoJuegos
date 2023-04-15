using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WebApplication1.Controllers;
using WebApplication1.Models;

namespace WebApplication1.Filtros
{
    public class VerificarRol : ActionFilterAttribute
    {
        

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var controller = filterContext.Controller as Controller;
            if (controller != null)
            {
                var usuarioActual = controller.User.Identity;
                if (usuarioActual != null && usuarioActual.IsAuthenticated && usuarioActual.Name.Equals("admin@gmail.com"))
                {
                    
                }
                else
                {
                    controller.TempData["Error"] = "No eres administrador o no te has registrado";
                    filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary {            
                    { "controller", "Home" },
                    { "action", "Index" }
                        });
                    
                }
            }
        }

    }
}