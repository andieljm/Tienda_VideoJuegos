using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Helpers
{
    public static class Herlpes_T_principales
    {
       public static MvcHtmlString Titulos(this HtmlHelper helper, String titulo)
        {
            string html = "<h2>" + titulo + "</h2>";
            return new MvcHtmlString(html);
        }
    }
}