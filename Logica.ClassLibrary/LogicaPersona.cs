using AccesoDatos.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.ClassLibrary
{
    public class LogicaPersona
    {
        private static DcMantenimientoDataContext dc = new DcMantenimientoDataContext();

        public static Persona getPersonXIdentificacion(string identificacion)
        {
            try
            {
                var person = dc.Persona.FirstOrDefault(data => data.per_status == 'A'
                                                       && data.per_identificacion.Equals(identificacion));

                return person;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener Usuario " + ex.Message);
            }
        }


    }
}
