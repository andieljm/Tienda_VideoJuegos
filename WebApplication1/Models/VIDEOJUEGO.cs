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
    
    public partial class VIDEOJUEGO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VIDEOJUEGO()
        {
            this.CARRRITO = new HashSet<CARRRITO>();
        }
    
        public int ID_VIDEOJUEGO { get; set; }
        public string nombre_videojuego { get; set; }
        public int cant_disp { get; set; }
        public decimal precio { get; set; }
        public int ID_CONSOLA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CARRRITO> CARRRITO { get; set; }
        public virtual CONSOLA CONSOLA { get; set; }
    }
}
