using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaPresentacion.Utilidades;
using CapaEntidad;
using CapaNegocio;
using System.Net;
using System.Text.RegularExpressions;

namespace CapaPresentacion
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
            txtBusqueda.TextChanged += new EventHandler(txtBusqueda_TextChanged);
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        // Carga el formulario y se ejecuta este metodo
        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            // Agregar opciones "Activo" y "No Activo" al ComboBox cboEstado
            cboEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });

            // Configurar el ComboBox cboEstado para mostrar el texto y usar el valor al seleccionar
            cboEstado.DisplayMember = "Texto";
            cboEstado.ValueMember = "Valor";

            // Establecer la opción seleccionada inicialmente como "Activo"
            cboEstado.SelectedIndex = 0;

            // Obtener una lista de roles y agregarlos al ComboBox cboRol
            List<Rol> listaRol = new CN_Rol().Listar();
            foreach (var item in listaRol)
            {
                cboRol.Items.Add(new OpcionCombo() { Valor = item.IdRol, Texto = item.Descripcion });
            }

            // Configurar el ComboBox cboRol para mostrar el texto y usar el valor al seleccionar
            cboRol.DisplayMember = "Texto";
            cboRol.ValueMember = "Valor";

            // Establecer la opción seleccionada inicialmente como administrador
            cboRol.SelectedIndex = 0;

            // Iterar a través de las columnas del DataGridView dgvData
            foreach (DataGridViewColumn columna in dgvData.Columns)
            {
                //  agrega a cboBusqueda
                if (columna.Visible == true && columna.Name != "btnseleccionar")
                {
                    cboBusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }

            // Configurar el ComboBox cboBusqueda para mostrar el texto y usar el valor al seleccionar
            cboBusqueda.DisplayMember = "Texto";
            cboBusqueda.ValueMember = "Valor";

            // Establecer la opción seleccionada inicialmente como la primera columna visible
            cboBusqueda.SelectedIndex = 0;

            // Obtener una lista de usuarios y mostrarlos en el dgv
            List<Usuario> listaUsuario = new CN_Usuario().Listar();

            foreach (Usuario usuario in listaUsuario)
            {
                // Agregar una fila al DataGridView con los datos del usuario
                dgvData.Rows.Add(
                    "",
                    usuario.IdUsuario,
                    usuario.DNI,
                    usuario.Nombre,
                    usuario.Apellido,
                    usuario.Clave,
                    usuario.Email,
                    usuario.Direccion,
                    usuario.FechaNacimiento,
                    usuario.Telefono,
                    usuario.Estado ? "Activo" : "Inactivo",
                    usuario.oRol.Descripcion
                );
            }

           
            FiltrarUsuarios(true);
        }



        //limpia los campos
        private void limpiar()
        {
            txtDNI.Focus();
            txtIndice.Text = "-1";
            txtId.Clear(); 
            txtDNI.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtClave.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();
            dtpFecha.Value = DateTime.Now;
            txtTelefono.Clear();
            cboRol.SelectedIndex = -1;
            cboEstado.SelectedIndex = -1;
        }


        //Busqueda del dgv tiempo real
        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            // Obtiene la columna de filtro seleccionada desde el ComboBox
            string columnaFiltro = ((OpcionCombo)cboBusqueda.SelectedItem).Valor.ToString();
            // Obtiene el texto de búsqueda del cuadro de texto y lo convierte a mayúsculas
            string textoBusqueda = txtBusqueda.Text.Trim().ToUpper();

            if (dgvData.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    // Obtiene el valor de la celda en la columna de filtro, si no es nulo
                    string valorCelda = row.Cells[columnaFiltro].Value != null ? row.Cells[columnaFiltro].Value.ToString().ToUpper() : "";

                    // Comprueba si el valor de la celda contiene el texto de búsqueda
                    bool filaVisible = valorCelda.Contains(textoBusqueda);

                    // Configura la visibilidad de la fila en función del resultado de la búsqueda
                    row.Visible = filaVisible;
                }
            }
        }



        //seleccionar de los items en el dgv
        private void dgvData_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int indice = e.RowIndex;
                btnGuardar.Text = "Actualizar datos";

                // Muestra los datos en los TextBox
                txtIndice.Text = indice.ToString(); // Establecer el índice de la fila seleccionada
                txtId.Text = dgvData.Rows[indice].Cells["Id"].Value.ToString();
                txtDNI.Text = dgvData.Rows[indice].Cells["Documento"].Value.ToString();
                txtNombre.Text = dgvData.Rows[indice].Cells["Nombre"].Value.ToString();
                txtApellido.Text = dgvData.Rows[indice].Cells["Apellido"].Value.ToString();
                txtClave.Text = dgvData.Rows[indice].Cells["Clave"].Value.ToString();
                txtEmail.Text = dgvData.Rows[indice].Cells["Email"].Value.ToString();
                txtDireccion.Text = dgvData.Rows[indice].Cells["Direccion"].Value.ToString();
                dtpFecha.Value = Convert.ToDateTime(dgvData.Rows[indice].Cells["FechaNacimiento"].Value);
                txtTelefono.Text = dgvData.Rows[indice].Cells["Telefono"].Value.ToString();

                string rolEnDataGrid = dgvData.Rows[indice].Cells["Rol"].Value.ToString();
                cboRol.SelectedIndex = cboRol.FindStringExact(rolEnDataGrid);

                string estadoEnDataGrid = dgvData.Rows[indice].Cells["Estado"].Value.ToString();
                cboEstado.SelectedIndex = cboEstado.FindStringExact(estadoEnDataGrid);
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }



        private void FiltrarUsuarios(bool estadoActivo)
        {
            // Limpia el cuadro de búsqueda
            txtBusqueda.Clear();

            // Recorre las filas del DataGridView y muestra/oculta según el estado
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                bool estadoFila = row.Cells["Estado"].Value.ToString() == "Activo";

                if ((estadoActivo && estadoFila) || (!estadoActivo && !estadoFila))
                {
                    // Mostrar usuarios activos si estadoActivo es true
                    // Mostrar usuarios inactivos si estadoActivo es false
                    row.Visible = true;
                }
                else
                {
                    // Ocultar otros usuarios
                    row.Visible = false;
                }
            }
        }


        private void bunifuGradientPanel1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        // ********GUARDAR *************
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //** VALIDACIONES **

            // Validación de campos obligatorios
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtClave.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtDNI.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                cboRol.SelectedItem == null ||
                cboEstado.SelectedItem == null)
            {
                MessageBox.Show("Por favor, completa todos los campos obligatorios.");
                return;
            }

            // Validación de DNI como número entero positivo
            if (!int.TryParse(txtDNI.Text, out int dni) || dni <= 0)
            {
                MessageBox.Show("El DNI debe ser un número válido y mayor que cero.");
                return;
            }

            // Validación de dirección de correo electrónico
            string emailPattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            if (!Regex.IsMatch(txtEmail.Text, emailPattern))
            {
                MessageBox.Show("El correo electrónico ingresado no es válido.");
                return;
            }

            string mensaje = string.Empty;
            int idUsuario = 0;

            if (!string.IsNullOrEmpty(txtId.Text))
            {
                // Si el campo txtId no está vacío, intenta convertirlo a un entero
                if (!int.TryParse(txtId.Text, out idUsuario))
                {
                    MessageBox.Show("El campo ID no contiene un valor numérico válido.");
                    return;
                }
            }

            if (!Regex.IsMatch(txtNombre.Text, "^[A-Za-z ]+$") || !Regex.IsMatch(txtApellido.Text, "^[A-Za-z ]+$"))
            {
                MessageBox.Show("Los nombres y apellidos solo deben contener letras y espacios.");
                return;
            }

            Usuario usuario = new Usuario()
            {
                IdUsuario = idUsuario,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Clave = txtClave.Text,
                Email = txtEmail.Text,
                DNI = txtDNI.Text,
                Direccion = txtDireccion.Text,
                FechaNacimiento = dtpFecha.Value,
                Telefono = txtTelefono.Text,
                oRol = new Rol() { IdRol = Convert.ToInt32(((OpcionCombo)cboRol.SelectedItem).Valor) },
                Estado = Convert.ToInt32(((OpcionCombo)cboEstado.SelectedItem).Valor) == 1 ? true : false,
            };

            //si es usuario nuevo pasa esto
            if (usuario.IdUsuario == 0)
            {
                int idusuariogenerado = new CN_Usuario().Registrar(usuario, out mensaje);

                if (idusuariogenerado != 0)
                {
                    dgvData.Rows.Add(new object[] { "", idusuariogenerado, txtDNI.Text, txtNombre.Text, txtApellido.Text, txtClave.Text, txtEmail.Text, txtDireccion.Text, dtpFecha.Value, txtTelefono.Text, ((OpcionCombo)cboRol.SelectedItem).Texto.ToString(), ((OpcionCombo)cboEstado.SelectedItem).Texto.ToString() });
                    limpiar();

                    // Mostrar un mensaje de éxito al guardar
                    MessageBox.Show("Usuario guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            //si es usuario ya existente actualiza
            else
            {
                bool resultado = new CN_Usuario().Editar(usuario, out mensaje);
                if (resultado)
                {
                    DataGridViewRow row = dgvData.Rows[int.Parse(txtIndice.Text)];
                    row.Cells["Id"].Value = txtId.Text;
                    row.Cells["Nombre"].Value = txtNombre.Text;
                    row.Cells["Apellido"].Value = txtApellido.Text;
                    row.Cells["Clave"].Value = txtClave.Text;
                    row.Cells["Email"].Value = txtEmail.Text;
                    row.Cells["Documento"].Value = txtDNI.Text;
                    row.Cells["Direccion"].Value = txtDireccion.Text;
                    row.Cells["FechaNacimiento"].Value = dtpFecha.Value;
                    row.Cells["Telefono"].Value = txtTelefono.Text;
                    row.Cells["Estado"].Value = ((OpcionCombo)cboEstado.SelectedItem).Texto.ToString();
                    row.Cells["Rol"].Value = ((OpcionCombo)cboRol.SelectedItem).Texto.ToString();
                    limpiar();

                    // Mostrar un mensaje de éxito al editar
                    MessageBox.Show("Usuario editado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
        }

        private void btnlimpiarCampos_Click_1(object sender, EventArgs e)
        {
            btnGuardar.Text = "Guardar";
            limpiar();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            FiltrarUsuarios(false);
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            FiltrarUsuarios(true);
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            txtBusqueda.Clear();


            if (dgvData.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    row.Visible = true;
                }
            }
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
            
                e.Handled = true;
            }
        }

        private void dgvData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dgvData.Columns[e.ColumnIndex].Name == "FechaNacimiento" && e.Value != null)
            {
                if (e.Value is DateTime fecha)
                {
                    // Formatea la fecha para mostrar solo la parte de la fecha (sin la hora)
                    e.Value = fecha.ToShortDateString();
                }
            }
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
