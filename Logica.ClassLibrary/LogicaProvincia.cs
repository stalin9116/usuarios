using AccesoDatos.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.ClassLibrary
{
    public class LogicaProvincia
    {

        private static DcMantenimientoDataContext dc = new DcMantenimientoDataContext();

        public static List<Provincia> getAllProvincias()
        {
            try
            {
                var lista = dc.Provincia.Where(data => data.pro_status == 'A')
                                      .OrderBy(ord => ord.pro_nombre);

                return lista.ToList();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener Provincias " + ex.Message);
            }
        }
    }
}
