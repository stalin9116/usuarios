using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica.ClassLibrary;
using AccesoDatos.ClassLibrary;


namespace usuarios.Formularios
{
    public partial class FrmUsuario : Form
    {
        //Constructor
        public FrmUsuario()
        {
            InitializeComponent();

        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            loadUsers();
            loadRol();
        }

        private void loadUsers()
        {
            try
            {
                List<Usuario> listaUsuarios = new List<Usuario>();
                listaUsuarios = LogicaUsuario.getAllaUsers();
                if (listaUsuarios != null && listaUsuarios.Count > 0)
                {
                    //Cargando los datos hacia el Datagridview
                    dgvUsuarios.DataSource = listaUsuarios.Select(data => new
                    {

                        CODIGO = data.usu_id,
                        APELLIDOS = data.usu_apellidos,
                        NOMBRES = data.usu_nombres,
                        CORREO = data.usu_correo,
                        ROL = data.Rol.rol_descripcion

                    }).ToList();
                }
            }
            catch
            {

                MessageBox.Show("Error al cargar los usuarios", "Sistema de Matriculación Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void loadRol()
        {
            try
            {
                List<Rol> listaRoles = new List<Rol>();
                listaRoles = LogicaRol.getAllRol();
                if (listaRoles != null && listaRoles.Count > 0)
                {
                    listaRoles.Insert(0, new Rol
                    {
                        rol_id = 0,
                        rol_descripcion = "Seleccione Rol"

                    });

                    cmbRol.DataSource = listaRoles;
                    cmbRol.DisplayMember = "rol_descripcion";
                    cmbRol.ValueMember = "rol_id";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los roles", "Sistema de Matriculación Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            lblCodigo.Text = "";
            txtApellidos.Clear();
            txtClave.Clear();
            txtClavveConfirmar.Clear();
            txtCorreo.Clear();
            txtNombres.Clear();
            cmbRol.SelectedIndex = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            saveUser();
        }

        private void saveUser()
        {
            try
            {
                Usuario usuario = new Usuario();
                usuario.usu_apellidos = txtApellidos.Text.ToUpper();
                usuario.usu_nombres = txtNombres.Text.ToUpper();
                usuario.usu_password = txtClave.Text;
                usuario.usu_correo = txtCorreo.Text;
                usuario.rol_id = int.Parse(cmbRol.SelectedValue.ToString());

                //validaciones

                bool resultSave = LogicaUsuario.saveUser(usuario);
                if (resultSave)
                {
                    MessageBox.Show("Usuario guardado correctamente", "Sistema de Matriculación Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadUsers();
                    limpiar();
                }
                else
                {
                    MessageBox.Show("Error al guardar usuario", "Sistema de Matriculación Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error al guardar usuario", "Sistema de Matriculación Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
