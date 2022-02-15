using Logica.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.WebForms.Public
{
    public partial class wfmLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private void login()
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                var user = LogicaUsuario.getUserXLogin(username, Logica.ClassLibrary.Utilidades.Encriptar.GetMD5(password));
                if (user != null)
                {
                    Session["Usuario"] = user;
                    Response.Redirect("/Default.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Usuario o Clave Incorrecta');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Usuario o Clave Incorrecta');</script>");
            }
        }
    }
}