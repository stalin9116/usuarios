//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Servicio.API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Color
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Color()
        {
            this.Vehiculo = new HashSet<Vehiculo>();
            this.Vehiculo1 = new HashSet<Vehiculo>();
        }
    
        public int col_id { get; set; }
        public string col_nombre { get; set; }
        public string col_status { get; set; }
        public System.DateTime col_add { get; set; }
        public Nullable<System.DateTime> col_update { get; set; }
        public Nullable<System.DateTime> col_delete { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vehiculo> Vehiculo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vehiculo> Vehiculo1 { get; set; }
    }
}