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
    
    public partial class CITA_REPARACION
    {
        public int ID_CITA { get; set; }
        public string nombre_empleado { get; set; }
        public System.DateTime fecha_asignada { get; set; }
        public int ID_REPARACION { get; set; }
    
        public virtual TALLER TALLER { get; set; }
    }
}
