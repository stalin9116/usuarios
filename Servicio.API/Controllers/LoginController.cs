using Servicio.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Servicio.API.Controllers
{

    public class LoginController : ApiController
    {
        private DBMATRICULAEntities db = new DBMATRICULAEntities();

        [HttpPost]
        public IHttpActionResult loginXUser(Login login)
        {
            Usuario usuario = db.Usuario.Where(data => data.usu_status.Equals("A")
                                               && data.usu_correo.Equals(login.username)
                                               && data.usu_password.Equals(login.password)).FirstOrDefault();
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(new { 
                UserId = usuario.usu_id,
                Usuario = $"{usuario.usu_nombres} {usuario.usu_apellidos}",
                Correo = usuario.usu_correo,
                //Perfil = usuario.Rol.rol_descripcion
            });
        }


    }
}
