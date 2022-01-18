using AccesoDatos.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.ClassLibrary
{
    public class LogicaEmail
    {

        private static DcMantenimientoDataContext dc = new DcMantenimientoDataContext();

        public static Smtp getVehiculoXPlaca()
        {
            try
            {
                var stmpData = dc.Smtp.FirstOrDefault(data => data.smtp_status == 'A'
                                                       && data.smtp_codigo.Equals(1));

                return stmpData;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener Usuario " + ex.Message);
            }
        }


    }
}
