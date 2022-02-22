using AccesoDatos.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.ClassLibrary
{
    public class LogicaTipo
    {
        private static DcMantenimientoDataContext dc = new DcMantenimientoDataContext();

        public static List<Tipo> getTipoVehiculos()
        {
            try
            {
                var tvehiculo = dc.Tipo.Where(data => data.tip_status == 'A');

                return tvehiculo.ToList();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener Tipo de Vehiculos " + ex.Message);
            }
        }

    }
}
