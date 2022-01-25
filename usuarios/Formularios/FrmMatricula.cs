using AccesoDatos.ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace usuarios.Formularios
{
    public partial class FrmMatricula : Form
    {
        public FrmMatricula()
        {
            InitializeComponent();
            loadProvincias();
        }


        private void loadProvincias()
        {
            try
            {
                List<Provincia> listaProvincias = new List<Provincia>();
                listaProvincias = Logica.ClassLibrary.LogicaProvincia.getAllProvincias();
                if (listaProvincias != null && listaProvincias.Count > 0)
                {
                    listaProvincias.Insert(0, new Provincia
                    {
                        pro_id = 0,
                        pro_nombre = "Seleccione Provincia"
                    });

                    cmbProvincia.DataSource = listaProvincias;
                    cmbProvincia.DisplayMember = "pro_nombre";
                    cmbProvincia.ValueMember = "pro_id";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los roles", "Sistema de Matriculación Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadCantones(int codigoProvincia)
        {
            try
            {
                if (codigoProvincia > 0)
                {
                    List<Canton> listaCanton = new List<Canton>();
                    listaCanton = Logica.ClassLibrary.LogicaCanton.getAllCantonesXProvincia(codigoProvincia);
                    if (listaCanton != null && listaCanton.Count > 0)
                    {
                        listaCanton.Insert(0, new Canton
                        {
                            can_id = 0,
                            can_nombre = "Seleccione Cantón"
                        });

                        cmbCanton.DataSource = listaCanton;
                        cmbCanton.DisplayMember = "can_nombre";
                        cmbCanton.ValueMember = "can_id";
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los roles", "Sistema de Matriculación Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarPersona_Click(object sender, EventArgs e)
        {
            searchPerson();
        }

        private void searchPerson()
        {
            string identificacion = txtCedula.Text.TrimEnd().TrimStart();
            if (!string.IsNullOrEmpty(identificacion))
            {
                Persona persona = new Persona();
                persona = Logica.ClassLibrary.LogicaPersona.getPersonXIdentificacion(identificacion);
                if (persona != null)
                {
                    lblPersona.Text = persona.per_apellidos + " " + persona.per_nombres;
                    //Interpolation
                    lblPersona.Text = $"{persona.per_apellidos} {persona.per_nombres}";
                }
                else
                {
                    MessageBox.Show("Persona no existe", "Sistema Matriculacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Formularios.FrmPersona frmPersona = new FrmPersona();
                    frmPersona.Show();
                }
            }
        }

        private void searchVehiculo()
        {
            string placa = txtPlaca.Text.TrimEnd().TrimStart();
            if (!string.IsNullOrEmpty(placa))
            {
                Vehiculo vehiculo = new Vehiculo();
                vehiculo = Logica.ClassLibrary.LogicaVehiculo.getVehiculoXPlaca(placa);
                if (vehiculo != null)
                {
                    lblIdVehiculo.Text = vehiculo.veh_id.ToString();
                    //Interpolation
                    lblVehiculoMarca.Text = $"{vehiculo.Modelo.Marca.mar_descripcion} {vehiculo.Modelo.mod_descripcion}";
                }
                else
                {
                    MessageBox.Show("Vehiculo no existe", "Sistema Matriculacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Formularios.FrmVehiculo frmVehiculo = new FrmVehiculo();
                    frmVehiculo.Show();
                }
            }
        }
        private void btnVehiculo_Click(object sender, EventArgs e)
        {
            searchVehiculo();
        }

        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProvincia.SelectedIndex > 0)
            {
                loadCantones(int.Parse(cmbProvincia.SelectedValue.ToString()));
            }
        }

        private void guardarMatricula()
        {
            try
            {
                Matricula matricula = new Matricula();

                matricula.mat_fechaemsion = dtpFechaEmision.Value;
                matricula.mat_fechacaducidad = dtpFechaCaducidad.Value;
                matricula.mat_numeroespecie = txtNumeroEspecie.Text;
                matricula.valor_matricula = 500;
                matricula.can_id = Convert.ToInt32(cmbCanton.SelectedValue.ToString());
                matricula.per_identificacion = txtCedula.Text;
                matricula.veh_id = int.Parse(lblIdVehiculo.Text);
                bool resSaveMatricula = Logica.ClassLibrary.LogicaMatricula.saveMatricula(matricula);
                if (resSaveMatricula)
                {
                    MessageBox.Show("Matricula generada correctamente", "Sistema de Matriculación Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var persona = Logica.ClassLibrary.LogicaPersona.getPersonXIdentificacion(matricula.per_identificacion);

                    string datosPersona = $"{persona.per_apellidos} {persona.per_nombres}";

                    bool resEmail = Logica.ClassLibrary.LogicaMatricula.sendEmail(persona.per_correo, datosPersona, matricula.mat_fechaemsion);
                    if (resEmail)
                    {
                        MessageBox.Show("Correo enviado correctamente", "Sistema de Matriculación Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar matricula", "Sistema de Matriculación Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarMatricula();
        }
    }
}
