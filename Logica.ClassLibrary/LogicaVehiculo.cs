using AccesoDatos.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.ClassLibrary
{
    public class LogicaVehiculo
    {
        private static DcMantenimientoDataContext dc = new DcMantenimientoDataContext();

        public static Vehiculo getVehiculoXPlaca(string placa)
        {
            try
            {
                var vehiculo = dc.Vehiculo.FirstOrDefault(data => data.veh_status == 'A'
                                                       && data.veh_placaactual.Equals(placa));

                return vehiculo;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener Usuario " + ex.Message);
            }
        }


    }
}
