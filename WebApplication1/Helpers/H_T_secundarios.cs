using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Helpers
{
    public static class H_T_secundarios
    {
        public static MvcHtmlString secundarios(this HtmlHelper helper, String titulo)
        {
            string html = "<h2 style= text - align:center> " + titulo + "</h2>";
            return new MvcHtmlString(html);
        }

    }
}