//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CARRRITO
    {
        public int ID_CARRITO { get; set; }
        public int cantidad { get; set; }
        public string ID_USUARIO { get; set; }
        public int ID_CONSOLA { get; set; }
        public Nullable<int> ID_VIDEOJUEGO { get; set; }
        public Nullable<int> ID_PERIFERICO { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual CONSOLA CONSOLA { get; set; }
        public virtual PERIFERICO PERIFERICO { get; set; }
        public virtual VIDEOJUEGO VIDEOJUEGO { get; set; }
    }
}
