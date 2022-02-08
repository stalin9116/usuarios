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
    
    public partial class Vehiculo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehiculo()
        {
            this.Matricula = new HashSet<Matricula>();
        }
    
        public int veh_id { get; set; }
        public string veh_placaanterior { get; set; }
        public string veh_placaactual { get; set; }
        public string veh_chasis { get; set; }
        public string veh_motor { get; set; }
        public System.DateTime veh_fechacompra { get; set; }
        public byte veh_pasajeros { get; set; }
        public decimal veh_tonelaje { get; set; }
        public string veh_carroceria { get; set; }
        public string veh_combustible { get; set; }
        public string veh_observacion { get; set; }
        public short veh_anio { get; set; }
        public short veh_cilindraje { get; set; }
        public string veh_status { get; set; }
        public System.DateTime veh_add { get; set; }
        public Nullable<System.DateTime> veh_update { get; set; }
        public Nullable<System.DateTime> veh_delete { get; set; }
        public Nullable<int> tip_id { get; set; }
        public Nullable<int> col_id { get; set; }
        public Nullable<int> mod_id { get; set; }
        public Nullable<short> pai_id { get; set; }
        public Nullable<int> cla_id { get; set; }
    
        public virtual Clase Clase { get; set; }
        public virtual Color Color { get; set; }
        public virtual Color Color1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Matricula> Matricula { get; set; }
        public virtual Modelo Modelo { get; set; }
        public virtual Pais Pais { get; set; }
        public virtual Tipo Tipo { get; set; }
    }
}
