using AccesoDatos.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Logica.ClassLibrary
{
    public class LogicaUsuario
    {
        private static DcMantenimientoDataContext dc = new DcMantenimientoDataContext();

        public static List<USUARIO> getAllaUsers()
        {
            try
            {
                var lista = dc.USUARIO.Where(data => data.usu_status == 'A');

                return lista.ToList();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener usuario "+ ex.Message);
            }
        }

        public static USUARIO getUserXId(int idUsuario)
        {
            try
            {
                var usuario = dc.USUARIO.Where(data => data.usu_status == 'A'
                                               && data.usu_id.Equals(idUsuario)).FirstOrDefault();

                return usuario;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener usuario " + ex.Message);
            }
        }

        public static USUARIO getUserXLogin(string email, string clave)
        {
            try
            {
                var usuario = dc.USUARIO.Where(data => data.usu_status == 'A'
                                               && data.usu_correo.Equals(email)
                                               && data.usu_password.Equals(clave)
                                               ).FirstOrDefault();

                return usuario;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener usuario " + ex.Message);
            }
        }


        public static bool saveUser(USUARIO dataUsuario)
        {
            try
            {
                bool result = false;
                dataUsuario.usu_add = DateTime.Now;
                dataUsuario.usu_status = 'A';

                dc.USUARIO.InsertOnSubmit(dataUsuario);
                //Commit a la base
                dc.SubmitChanges();

                result = true;
                return result;
                
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al guardar usuario " + ex.Message);
            }
        }

        public static bool updateUser(USUARIO dataUsuario)
        {
            try
            {
                bool result = false;
                //Commit a la base
                dc.SubmitChanges();

                result = true;
                return result;

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al modificar usuario " + ex.Message);
            }
        }

        public static bool deleteteUser(USUARIO dataUsuario)
        {
            try
            {
                bool result = false;
                
                dataUsuario.usu_status = 'I';
                //Commit a la base
                dc.SubmitChanges();

                result = true;
                return result;

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al eliminar usuario " + ex.Message);
            }
        }




    }
}
