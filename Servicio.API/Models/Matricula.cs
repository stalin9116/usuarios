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
    
    public partial class Matricula
    {
        public long mat_id { get; set; }
        public System.DateTime mat_fechaemsion { get; set; }
        public System.DateTime mat_fechacaducidad { get; set; }
        public string mat_numeroespecie { get; set; }
        public decimal valor_matricula { get; set; }
        public int can_id { get; set; }
        public string per_identificacion { get; set; }
        public int veh_id { get; set; }
        public System.DateTime mat_add { get; set; }
        public string mat_status { get; set; }
    
        public virtual Canton Canton { get; set; }
        public virtual Persona Persona { get; set; }
        public virtual Vehiculo Vehiculo { get; set; }
    }
}
