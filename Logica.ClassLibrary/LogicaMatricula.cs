using AccesoDatos.ClassLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.ClassLibrary
{
    public class LogicaMatricula
    {
        private static DcMantenimientoDataContext dc = new DcMantenimientoDataContext();

        public static bool saveMatricula(Matricula dataMatricula)
        {
            try
            {
                bool result = false;
                dataMatricula.mat_add = DateTime.Now;
                dataMatricula.mat_status = 'A';

                dc.Matricula.InsertOnSubmit(dataMatricula);
                //Commit a la base
                dc.SubmitChanges();

                result = true;
                return result;

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al guardar Matricula " + ex.Message);
            }
        }


        private static string convertHtmlToString(string cliente, DateTime fecha)
        {
            string body = string.Empty;

            using (StreamReader reader= new StreamReader(@"C:\Plantilla\plantilla.html"))
            {
                body = reader.ReadToEnd();
                body = body.Replace("@Cliente", cliente);
                body = body.Replace("@Fecha", fecha.ToLongDateString());
            }

            return body;
        }

        public static bool sendEmail(string correo, string persona, DateTime fecha)
        {
            try
            {
                var serverConfig = LogicaEmail.getConfigEmailServer();
                string asunto = "Matriculacion Vehicular";
                bool res = Utilidades.EnviarCorreo.SendCorreo(serverConfig, correo, asunto, convertHtmlToString(persona, fecha));

                return res;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al enviar Correo " + ex.Message); ;
            }
        }

    }
}
