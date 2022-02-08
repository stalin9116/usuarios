using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Servicio.API.Models;

namespace Servicio.API.Controllers
{ 

    
    public class UsuariosController : ApiController
    {
        private DBMATRICULAEntities db = new DBMATRICULAEntities();

        
        public IQueryable<Usuario> GetUsuario()
        {
            return db.Usuario;
        }

        //[Route("login")]
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult PostUsuario(Usuario usuario)
        {
            Usuario datausuario = db.Usuario.Where(data => data.usu_status.Equals("A")
                                               && data.usu_correo.Equals(usuario.usu_correo)
                                               && data.usu_password.Equals(usuario.usu_password)).FirstOrDefault();
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(datausuario);
        }



        [ResponseType(typeof(Usuario))]
        public IHttpActionResult GetUsuario(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsuario(int id, Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuario.usu_id)
            {
                return BadRequest();
            }

            db.Entry(usuario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        
        //[ResponseType(typeof(Usuario))]
        //public IHttpActionResult PostUsuario(Usuario usuario)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Usuario.Add(usuario);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = usuario.usu_id }, usuario);
        //}

        
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult DeleteUsuario(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }

            db.Usuario.Remove(usuario);
            db.SaveChanges();

            return Ok(usuario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuarioExists(int id)
        {
            return db.Usuario.Count(e => e.usu_id == id) > 0;
        }
    }
}