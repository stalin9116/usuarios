using AccesoDatos.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.WebForms
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Usuario"] != null)
                {
                    Usuario user = new Usuario();
                    user = (Usuario)Session["Usuario"];
                    if (user != null)
                    {
                        lblUsuario.Text = $"{user.usu_nombres} {user.usu_apellidos}";
                    }
                }
                else
                {
                    Response.Redirect("~/Public/wfmLogin.aspx");
                }
            }
        }
    }
}