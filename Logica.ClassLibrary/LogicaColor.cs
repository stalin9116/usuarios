using AccesoDatos.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.ClassLibrary
{
    public class LogicaColor
    {
        private static DcMantenimientoDataContext dc = new DcMantenimientoDataContext();

        public static List<Color> getColorVehiculos()
        {
            try
            {
                var cvehiculo = dc.Color.Where(data => data.col_status == 'A');

                return cvehiculo.ToList();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener Color de Vehiculos " + ex.Message);
            }
        }


    }
}
