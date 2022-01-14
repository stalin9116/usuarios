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

        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProvincia.SelectedIndex > 0)
            {
                loadCantones(int.Parse(cmbProvincia.SelectedValue.ToString()));
            }
        }

        private void saveMatricula()
        { 
            
        
        }

    }
}
