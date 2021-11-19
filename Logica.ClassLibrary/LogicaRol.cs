using AccesoDatos.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.ClassLibrary
{
    public class LogicaRol
    {
        private static DcMantenimientoDataContext dc = new DcMantenimientoDataContext();

        public static List<Rol> getAllRol()
        {
            try
            {
                var lista = dc.Rol.Where(data => data.rol_status == 'A')
                                      .OrderBy(ord => ord.rol_descripcion);

                return lista.ToList();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener Usuario " + ex.Message);
            }
        }

    }
}
