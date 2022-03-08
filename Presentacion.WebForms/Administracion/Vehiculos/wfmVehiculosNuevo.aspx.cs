using AccesoDatos.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.WebForms.Administracion.Vehiculos
{
    public partial class wfmVehiculosNuevo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Capturar Id Request
                if (Request["cod"] != null)
                {
                    int condigoVehiculo = int.Parse(Request["cod"].ToString());
                    loadVehiculo(condigoVehiculo);
                }

                loadTipoVehiculo();
                loadColorVehiculo();
            }
        }

        private void loadVehiculo(int idVehiculo)
        {
            Vehiculo vehiculo = new Vehiculo();
            vehiculo = Logica.ClassLibrary.LogicaVehiculo.getVehiculoXId(idVehiculo);
            if (vehiculo != null)
            {
                lblId.Text = vehiculo.veh_id.ToString();
                txtMotor.Text = vehiculo.veh_motor;
                //vehiculo.veh_anio = Convert.ToInt16(ddlYear.SelectedValue);
                //vehiculo.veh_anio = 2018;
                txtChasis.Text = vehiculo.veh_chasis;
                txtlblCilindraje.Text = vehiculo.veh_cilindraje.ToString();
                //vehiculo.veh_combustible = 'S';

                txtFechaCompra.Text = vehiculo.veh_fechacompra.ToString();
                txtObservacion.Text = vehiculo.veh_observacion;
                txtNpasajeros.Text = vehiculo.veh_pasajeros.ToString();
                txtplacaActual.Text = vehiculo.veh_placaactual;
                txtplacaAnterior.Text = vehiculo.veh_placaanterior;
                txtTonelaje.Text = vehiculo.veh_tonelaje.ToString();

                ddlColor.SelectedValue = vehiculo.col_id.ToString();
                ddlTipo.SelectedValue = vehiculo.tip_id.ToString();

                //vehiculo.veh_carroceria = "SI";
                //vehiculo.pai_id = Convert.ToInt16(ddlPais.SelectedValue);
                //vehiculo.pai_id = 1;
                //vehiculo.mod_id = Convert.ToInt32(ddlModelo.SelectedValue);
                //vehiculo.mod_id = 1;
                //vehiculo.cla_id = 1;
            }
        }

        private void loadTipoVehiculo()
        {
            List<Tipo> listaTipoVehiculos = new List<Tipo>();
            listaTipoVehiculos = Logica.ClassLibrary.LogicaTipo.getTipoVehiculos();
            if (listaTipoVehiculos != null && listaTipoVehiculos.Count > 0)
            {
                listaTipoVehiculos.Insert(0, new Tipo { tip_id = 0, tip_descripcion = "Seleccione Tipo" });
                ddlTipo.DataSource = listaTipoVehiculos;
                ddlTipo.DataTextField = "tip_descripcion";
                ddlTipo.DataValueField = "tip_id";
                ddlTipo.DataBind();
            }

        }

        private void loadColorVehiculo()
        {
            List<Color> listaColorVehiculos = new List<Color>();
            listaColorVehiculos = Logica.ClassLibrary.LogicaColor.getColorVehiculos();
            if (listaColorVehiculos != null && listaColorVehiculos.Count > 0)
            {
                listaColorVehiculos.Insert(0, new Color { col_id = 0, col_nombre = "Seleccione Color" });
                ddlColor.DataSource = listaColorVehiculos;
                ddlColor.DataTextField = "col_nombre";
                ddlColor.DataValueField = "col_id";
                ddlColor.DataBind();
            }

        }

        private void nuevo()
        {
            lblId.Text = "";
            txtChasis.Text = "";
            txtFechaCompra.Text = "";
            txtlblCilindraje.Text = "";
            txtMotor.Text = "";
            ddlColor.SelectedIndex = 0;
            ddlTipo.SelectedIndex = 0;
            txtNpasajeros.Text = "";
            txtplacaActual.Text = "";
            txtplacaAnterior.Text = "";
            txtTonelaje.Text = "";
            txtObservacion.Text = "";
        }

        protected void imbNuevo_Click(object sender, ImageClickEventArgs e)
        {
            nuevo();
        }

        protected void lnkNuevo_Click(object sender, EventArgs e)
        {
            nuevo();
        }

        private void regresar()
        {
            Response.Redirect("wfmVehiculos.aspx");
        }

        protected void imgRegresar_Click(object sender, ImageClickEventArgs e)
        {
            regresar();
        }

        protected void lnkRegresar_Click(object sender, EventArgs e)
        {
            regresar();
        }

        private void saveVehiculo()
        {
            if (!string.IsNullOrEmpty(lblId.Text))
            {
                modificar();
            }
            else
            {
                guardar();
            }

        }

        private void guardar()
        {
            try
            {
                Vehiculo vehiculo = new Vehiculo();
                vehiculo.veh_motor = txtMotor.Text;
                //vehiculo.veh_anio = Convert.ToInt16(ddlYear.SelectedValue);
                vehiculo.veh_anio = 2018;
                vehiculo.veh_chasis = txtChasis.Text;
                vehiculo.veh_cilindraje = Convert.ToInt16(txtlblCilindraje.Text);
                vehiculo.veh_combustible = 'S';
                vehiculo.veh_fechacompra = Convert.ToDateTime(txtFechaCompra.Text);
                vehiculo.veh_observacion = txtObservacion.Text;
                vehiculo.veh_pasajeros = Convert.ToByte(txtNpasajeros.Text);
                vehiculo.veh_placaactual = txtplacaActual.Text;
                vehiculo.veh_placaanterior = txtplacaAnterior.Text;
                vehiculo.veh_tonelaje = Convert.ToDecimal(txtTonelaje.Text);
                vehiculo.col_id = Convert.ToInt32(ddlColor.SelectedValue);
                vehiculo.tip_id = Convert.ToInt32(ddlTipo.SelectedValue);
                vehiculo.veh_carroceria = "SI";
                //vehiculo.pai_id = Convert.ToInt16(ddlPais.SelectedValue);
                vehiculo.pai_id = 1;
                //vehiculo.mod_id = Convert.ToInt32(ddlModelo.SelectedValue);
                vehiculo.mod_id = 1;
                vehiculo.cla_id = 1;

                bool resGuardar = Logica.ClassLibrary.LogicaVehiculo.saveVehiculo(vehiculo);
                if (resGuardar)
                {
                    lblMessage.Text = "Vehiculo Guardado correctamente";
                    nuevo();
                }

            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }

        }

        private void modificar()
        {
            try
            {
                Vehiculo vehiculo = new Vehiculo();

                vehiculo = Logica.ClassLibrary.LogicaVehiculo.getVehiculoXId(int.Parse(lblId.Text));
                //vehiculo.veh_id = 
                vehiculo.veh_motor = txtMotor.Text;
                //vehiculo.veh_anio = Convert.ToInt16(ddlYear.SelectedValue);
                vehiculo.veh_anio = 2018;
                vehiculo.veh_chasis = txtChasis.Text;
                vehiculo.veh_cilindraje = Convert.ToInt16(txtlblCilindraje.Text);
                vehiculo.veh_combustible = 'S';
                vehiculo.veh_fechacompra = Convert.ToDateTime(txtFechaCompra.Text);
                vehiculo.veh_observacion = txtObservacion.Text;
                vehiculo.veh_pasajeros = Convert.ToByte(txtNpasajeros.Text);
                vehiculo.veh_placaactual = txtplacaActual.Text;
                vehiculo.veh_placaanterior = txtplacaAnterior.Text;
                vehiculo.veh_tonelaje = Convert.ToDecimal(txtTonelaje.Text);
                vehiculo.col_id = Convert.ToInt32(ddlColor.SelectedValue);
                vehiculo.tip_id = Convert.ToInt32(ddlTipo.SelectedValue);
                vehiculo.veh_carroceria = "SI";
                //vehiculo.pai_id = Convert.ToInt16(ddlPais.SelectedValue);
                vehiculo.pai_id = 1;
                //vehiculo.mod_id = Convert.ToInt32(ddlModelo.SelectedValue);
                //vehiculo.mod_id = 1;
                //vehiculo.cla_id = 1;

                bool resGuardar = Logica.ClassLibrary.LogicaVehiculo.updateVehiculo(vehiculo);
                if (resGuardar)
                {
                    lblMessage.Text = "Vehiculo Modificado correctamente";
                    Response.Redirect("wfmVehiculos.aspx");
                }

            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }

        }

        protected void imbGuardar_Click(object sender, ImageClickEventArgs e)
        {
            saveVehiculo();
        }

        protected void lnkGuardar_Click(object sender, EventArgs e)
        {
            saveVehiculo();
        }
    }
}