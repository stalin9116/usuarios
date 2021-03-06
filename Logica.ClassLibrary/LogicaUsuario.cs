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

        public static List<Usuario> getAllaUsers()
        {
            try
            {
                var lista = dc.Usuario.Where(data => data.usu_status == 'A')
                                      .OrderBy(ord => ord.usu_apellidos);

                return lista.ToList();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener Usuario " + ex.Message);
            }
        }


        public static List<Usuario> getUsersXCodigo(int codigo)
        {
            try
            {
                var lista = dc.Usuario.Where(data => data.usu_status == 'A'
                                             && data.usu_id.Equals(codigo))
                                      .OrderBy(ord => ord.usu_apellidos);

                return lista.ToList();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener Usuario " + ex.Message);
            }
        }

        public static List<Usuario> getUsersXApellidos(string apellidos)
        {
            try
            {
                var lista = dc.Usuario.Where(data => data.usu_status == 'A'
                                             && data.usu_apellidos.StartsWith(apellidos))
                                      .OrderBy(ord => ord.usu_apellidos);

                return lista.ToList();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener Usuario " + ex.Message);
            }
        }

        public static List<Usuario> getUsersXNombres(string correo)
        {
            try
            {
                var lista = dc.Usuario.Where(data => data.usu_status == 'A'
                                             && data.usu_nombres.StartsWith(correo))
                                      .OrderBy(ord => ord.usu_apellidos);

                return lista.ToList();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener Usuario " + ex.Message);
            }
        }

        public static List<Usuario> getUsersXCorreo(string correo)
        {
            try
            {
                var lista = dc.Usuario.Where(data => data.usu_status == 'A'
                                             && data.usu_correo.StartsWith(correo))
                                      .OrderBy(ord => ord.usu_apellidos);

                return lista.ToList();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener Usuario " + ex.Message);
            }
        }

        public static List<Usuario> getUsersXRol(string rol)
        {
            try
            {
                var lista = dc.Usuario.Where(data => data.usu_status == 'A'
                                             && data.Rol.rol_descripcion.StartsWith(rol))
                                      .OrderBy(ord => ord.usu_apellidos);

                return lista.ToList();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener Usuario " + ex.Message);
            }
        }



        public static Usuario getUserXId(int idUsuario)
        {
            try
            {
                var Usuario = dc.Usuario.Where(data => data.usu_status == 'A'
                                               && data.usu_id.Equals(idUsuario)).FirstOrDefault();

                return Usuario;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener Usuario " + ex.Message);
            }
        }

        public static Usuario getUserXLogin(string email, string clave)
        {
            try
            {
                var Usuario = dc.Usuario.Where(data => data.usu_status == 'A'
                                               && data.usu_correo.Equals(email)
                                               && data.usu_password.Equals(clave)
                                               ).FirstOrDefault();

                return Usuario;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener Usuario " + ex.Message);
            }
        }


        public static bool saveUser(Usuario dataUsuario)
        {
            try
            {
                bool result = false;
                dataUsuario.usu_add = DateTime.Now;
                dataUsuario.usu_status = 'A';

                dc.Usuario.InsertOnSubmit(dataUsuario);
                //Commit a la base
                dc.SubmitChanges();

                result = true;
                return result;

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al guardar Usuario " + ex.Message);
            }
        }

        public static bool updateUser(Usuario dataUsuario)
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
                throw new ArgumentException("Error al modificar Usuario " + ex.Message);
            }
        }

        public static bool updateUser2(Usuario dataUsuario)
        {
            try
            {
                bool result = false;
                dataUsuario.usu_update = DateTime.Now;

                dc.ExecuteCommand("UPDATE [dbo].[Usuario] SET [usu_correo] = {0}" +
                                  ",[usu_apellidos] = {1}" +
                                  ",[usu_nombres] = {2}" +
                                  ",[usu_update] = {3}" +
                                  ",[rol_id] = {4} " +
                                  "WHERE [usu_id] = {5}", new object[] {
                                  dataUsuario.usu_correo,
                                  dataUsuario.usu_apellidos,
                                  dataUsuario.usu_nombres,
                                  dataUsuario.usu_update,
                                  dataUsuario.rol_id,
                                  dataUsuario.usu_id
                                  });

                //Envia la consulta al ORM hacia la base de datos, actualizacion
                dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, dc.Usuario);
                //Commit a la base
                dc.SubmitChanges();

                result = true;
                return result;

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al modificar Usuario " + ex.Message);
            }
        }

        public static bool updateUser3(Usuario dataUsuario)
        {
            try
            {
                dc = new DcMantenimientoDataContext();
                bool result = false;

                var res = dc.Pcd_UpdateUser(dataUsuario.usu_id, dataUsuario.usu_correo, dataUsuario.usu_password, dataUsuario.usu_apellidos,
                    dataUsuario.usu_nombres, dataUsuario.rol_id);

                //Permite capturar el resultado del procedimiento almacenado
                var restProcedure = res.FirstOrDefault<Pcd_UpdateUserResult>();
                if (restProcedure.Column1 > 0)
                {
                    result = true;
                }

                //Commit a la base
                dc.SubmitChanges();

               
                return result;

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al modificar Usuario " + ex.Message);
            }
        }


        public static bool deleteteUser(Usuario dataUsuario)
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
                throw new ArgumentException("Error al eliminar Usuario " + ex.Message);
            }
        }

    }
}
