using AccesoDatos.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Logica.ClassLibrary.Utilidades
{
    public class EnviarCorreo
    {
        public static bool SendCorreo(Smtp dataConfiguration, string destinatario, string asunto, string mensaje) 
        {
            //Cuerpo Mensaje
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();

            msg.IsBodyHtml = true;

            //Destinatarios
            msg.To.Add(destinatario);

            //Asunto

            msg.Subject = asunto;

            //Adjuntar imagenes hacia el cuerpo del mensaje

            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mensaje, null, MediaTypeNames.Text.Html);

            LinkedResource imageHtmlBanner1 = new LinkedResource(@"C:\Vehiculos\imagen1.jpg", MediaTypeNames.Image.Jpeg);
            imageHtmlBanner1.ContentId = "idBanner1";

            LinkedResource imageHtmlBanner2 = new LinkedResource(@"C:\Vehiculos\imagen2.jpg", MediaTypeNames.Image.Jpeg);
            imageHtmlBanner2.ContentId = "idBanner2";

            htmlView.LinkedResources.Add(imageHtmlBanner1);
            htmlView.LinkedResources.Add(imageHtmlBanner2);

            msg.AlternateViews.Add(htmlView);

            msg.From = new MailAddress(dataConfiguration.smtp_username);


            SmtpClient cliente = new SmtpClient();

            cliente.Credentials = new System.Net.NetworkCredential(dataConfiguration.smtp_username, dataConfiguration.smtp_password);
            cliente.Port = int.Parse(dataConfiguration.smtp_puerto.ToString());
            cliente.EnableSsl = Convert.ToBoolean(dataConfiguration.smtp_tls);

            cliente.Host = dataConfiguration.smtp_servidor;

            try
            {
                cliente.Send(msg);
                msg.Dispose();
                return true;
            }
            catch (Exception ex) 
            {
                msg.Dispose();
                return false;
                
            }
        }
    }
}
