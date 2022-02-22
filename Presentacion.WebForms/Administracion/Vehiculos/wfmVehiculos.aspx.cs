using AccesoDatos.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.WebForms.Administracion.Vehiculos
{
    public partial class wfmVehiculos : System.Web.UI.Page
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
                        loadVehiculos();
                    }
                }
                else
                {
                    Response.Redirect("~/Public/wfmLogin.aspx");
                }
            }
        }

        private void loadVehiculos()
        {
            List<Vehiculo> vehiculos = new List<Vehiculo>();

            vehiculos = Logica.ClassLibrary.LogicaVehiculo.getVehiculos();

            if (vehiculos.Count > 0 && vehiculos != null)
            {
                gdvVehiculos.DataSource = vehiculos.Select(data => new
                {
                    ID = data.veh_id,
                    PLACA = data.veh_placaactual,
                    MARCA = data.Modelo.Marca.mar_descripcion,
                    MODELO = data.Modelo.mod_descripcion,
                    MOTOR = data.veh_motor,
                    FECHA = data.veh_fechacompra.ToShortDateString(),
                    CILINDRAJE = data.veh_cilindraje
                });
                gdvVehiculos.DataBind();
            }

        }

        private void nuevo()
        {
            Response.Redirect("wfmVehiculosNuevo.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            nuevo();
        }

        protected void lnkNuevo_Click(object sender, EventArgs e)
        {
            nuevo();
        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void gdvVehiculos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string codigo = Convert.ToString(e.CommandArgument);

            if (e.CommandName == "Modificar")
            {
                //codigo
                Response.Redirect("wfmVehiculosNuevo.aspx?cod=" + codigo);

                //
            }
            else if (e.CommandName == "Eliminar")
            {
                Vehiculo vehiculo = new Vehiculo();
                vehiculo = Logica.ClassLibrary.LogicaVehiculo.getVehiculoXId(int.Parse(codigo));
                if (vehiculo != null)
                {
                    if (Logica.ClassLibrary.LogicaVehiculo.deleteVehiculo(vehiculo))
                    {
                        loadVehiculos();
                    }
                }

            }
        }
    }
}