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
            //loadUsers();
            search("Todos");

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

        private void loadUsers2(List<Usuario> listaUsuarios)
        {
            try
            {
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
            if (!string.IsNullOrEmpty(lblCodigo.Text))
            {
                updateUser();
            }
            else
            {
                saveUser();
            }

        }

        private string validations(Usuario usuario)
        {
            string mensaje = string.Empty;
            if (string.IsNullOrEmpty(usuario.usu_apellidos))
            {
                mensaje += "* Apellidos campo obligatorio\n";
            }
            if (string.IsNullOrEmpty(usuario.usu_nombres))
            {
                mensaje += "* Nombres campo obligatorio\n";
            }
            if (string.IsNullOrEmpty(lblCodigo.Text))
            {
                if (string.IsNullOrEmpty(usuario.usu_password) || string.IsNullOrEmpty(txtClavveConfirmar.Text))
                {
                    mensaje += "* Clave campo obligatorio\n";
                }
            }
            if (string.IsNullOrEmpty(usuario.usu_correo))
            {
                mensaje += "* Correo campo obligatorio\n";
            }
            if (usuario.rol_id == 0)
            {
                mensaje += "* Rol campo obligatorio\n";
            }

            if (!string.IsNullOrEmpty(txtClave.Text) && !string.IsNullOrEmpty(txtClavveConfirmar.Text))
            {
                if (!txtClave.Text.Equals(txtClavveConfirmar.Text))
                {
                    mensaje += "* Claves no son iguales\n";
                }
            }

            if (!string.IsNullOrEmpty(usuario.usu_correo))
            {
                if (!Logica.ClassLibrary.Utilidades.Validaciones.email_bien_escrito(usuario.usu_correo))
                {
                    mensaje += "* Correo inválido\n";
                }
            }

            return mensaje;
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

                string validationsMessage = validations(usuario);

                if (!String.IsNullOrEmpty(validationsMessage))
                {
                    MessageBox.Show(validationsMessage, "Sistema de Matriculación Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //encriptar md5

                usuario.usu_password = Logica.ClassLibrary.Utilidades.Encriptar.GetMD5(usuario.usu_password);


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

        private void updateUser()
        {
            try
            {
                if (!string.IsNullOrEmpty(lblCodigo.Text))
                {

                    var resMessage = MessageBox.Show("Desea modificar el registro ???? ", "Sistema Vehicular", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resMessage.ToString() == "Yes")
                    {
                        Usuario usuario = new Usuario();
                        //usuario = LogicaUsuario.getUserXId(Convert.ToInt32(lblCodigo.Text));

                        usuario.usu_id = Convert.ToInt32(lblCodigo.Text);
                        usuario.usu_apellidos = txtApellidos.Text.ToUpper();
                        usuario.usu_nombres = txtNombres.Text.ToUpper();
                        usuario.usu_correo = txtCorreo.Text;
                        usuario.rol_id = int.Parse(cmbRol.SelectedValue.ToString());

                        //validaciones

                        string validationsMessage = validations(usuario);

                        if (!String.IsNullOrEmpty(validationsMessage))
                        {
                            MessageBox.Show(validationsMessage, "Sistema de Matriculación Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        //encriptar md5


                        if (!string.IsNullOrEmpty(txtClave.Text))
                        {
                            usuario.usu_password = txtClave.Text;
                            usuario.usu_password = Logica.ClassLibrary.Utilidades.Encriptar.GetMD5(usuario.usu_password);
                        }

                        bool resultSave = LogicaUsuario.updateUser2(usuario);
                        if (resultSave)
                        {
                            MessageBox.Show("Usuario modificado correctamente", "Sistema de Matriculación Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadUsers();
                            limpiar();
                        }
                        else
                        {
                            MessageBox.Show("Error al modificar usuario", "Sistema de Matriculación Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error al modificar usuario", "Sistema de Matriculación Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteUser()
        {
            try
            {
                if (!string.IsNullOrEmpty(lblCodigo.Text))
                {
                    var resMessage = MessageBox.Show("Desea eliminar el registro ???? ", "Sistema Vehicular", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resMessage.ToString() == "Yes")
                    {
                        Usuario usuario = new Usuario();
                        usuario = LogicaUsuario.getUserXId(Convert.ToInt32(lblCodigo.Text));
                        if (usuario != null)
                        {
                            if (LogicaUsuario.deleteteUser(usuario))
                            {
                                MessageBox.Show("Registro eliminado correctamente");
                                loadUsers();
                                limpiar();
                            }
                        }


                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al eliminar el registro.");
            }
        }


        private void dgvUsuarios_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var codigoUsuario = dgvUsuarios.Rows[e.RowIndex].Cells["CODIGO"].Value;
            var correoUsuario = dgvUsuarios.Rows[e.RowIndex].Cells["CORREO"].Value;
            var apellidosUsuario = dgvUsuarios.Rows[e.RowIndex].Cells["APELLIDOS"].Value;
            var nombresUsuario = dgvUsuarios.Rows[e.RowIndex].Cells["NOMBRES"].Value;
            var rolUsuario = dgvUsuarios.Rows[e.RowIndex].Cells["ROL"].Value;

            if (!string.IsNullOrEmpty(codigoUsuario.ToString()))
            {
                lblCodigo.Text = codigoUsuario.ToString();
                txtCorreo.Text = correoUsuario.ToString();
                txtApellidos.Text = apellidosUsuario.ToString();
                txtNombres.Text = nombresUsuario.ToString();
                cmbRol.SelectedIndex = cmbRol.FindString(rolUsuario.ToString());
                //txtClave.Enabled = false;
                //txtClavveConfirmar.Enabled = false;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            deleteUser();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            search(cmbBuscar.Text);
        }

        private void search(string op)
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            if (!string.IsNullOrEmpty(txtBuscar.Text))
            {
                
                string datoAbuscar = txtBuscar.Text.TrimEnd();

                switch (op)
                {
                    case "Todos":
                        listaUsuarios = LogicaUsuario.getAllaUsers();
                        loadUsers2(listaUsuarios);
                        txtBuscar.Clear();
                        break;
                    case "Codigo":
                        listaUsuarios = LogicaUsuario.getUsersXCodigo(int.Parse(datoAbuscar));
                        loadUsers2(listaUsuarios);
                        break;
                    case "Apellidos":
                        listaUsuarios = LogicaUsuario.getUsersXApellidos(datoAbuscar);
                        loadUsers2(listaUsuarios);
                        break;
                    case "Nombres":
                        listaUsuarios = LogicaUsuario.getUsersXNombres(datoAbuscar);
                        loadUsers2(listaUsuarios);
                        break;
                    case "Correo":
                        listaUsuarios = LogicaUsuario.getUsersXCorreo(datoAbuscar);
                        loadUsers2(listaUsuarios);
                        break;
                    case "Rol":
                        listaUsuarios = LogicaUsuario.getUsersXRol(datoAbuscar);
                        loadUsers2(listaUsuarios);
                        break;
                }
            }
            else
            {
                if (op.Equals("Todos"))
                {
                    listaUsuarios = LogicaUsuario.getAllaUsers();
                    loadUsers2(listaUsuarios);
                    txtBuscar.Clear();
                }
            }

        }

    }
}
