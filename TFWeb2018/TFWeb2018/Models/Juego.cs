//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TFWeb2018.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Juego
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Juego()
        {
            this.Detalle_Venta = new HashSet<Detalle_Venta>();
        }
    
        public int Id_Juego { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public string Descripcion { get; set; }
        public string Foto { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalle_Venta> Detalle_Venta { get; set; }
    }
}
