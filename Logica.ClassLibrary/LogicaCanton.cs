using AccesoDatos.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.ClassLibrary
{
    public class LogicaCanton
    {
        private static DcMantenimientoDataContext dc = new DcMantenimientoDataContext();

        public static List<Canton> getAllCantonesXProvincia(int codigoProvincia)
        {
            try
            {
                var lista = dc.Canton.Where(data => data.can_status == 'A'
                                            && data.pro_id.Equals(codigoProvincia))
                                      .OrderBy(ord => ord.can_nombre);

                return lista.ToList();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener Cantones " + ex.Message);
            }
        }

    }
}
