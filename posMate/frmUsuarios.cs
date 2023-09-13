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

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dB_PosnetDataSet.USUARIO' table. You can move, or remove it, as needed.
            
            cboEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            cboEstado.DisplayMember = "Texto";
            cboEstado.ValueMember =  "Valor";
            cboEstado.SelectedIndex = 0;


            List<Rol> listaRol = new CN_Rol().Listar();
            foreach (var item in listaRol)
            {
                cboRol.Items.Add(new OpcionCombo() { Valor = item.IdRol, Texto = item.Descripcion });
               
            }
            cboRol.DisplayMember = "Texto";
            cboRol.ValueMember = "Valor";
            cboRol.SelectedIndex = 0;


            foreach(DataGridViewColumn columna in dgvData.Columns)
            {
                if(columna.Visible == true && columna.Name != "btnseleccionar")
                {
                  cboBusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
                
            }
            cboBusqueda.DisplayMember = "Texto";
            cboBusqueda.ValueMember = "Valor";
            cboBusqueda.SelectedIndex = 0;

            //Mostrar usuarios
            List<Usuario> listaUsuario = new CN_Usuario().Listar();

            foreach (Usuario usuario in listaUsuario)
            {
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

        }

        //btn guardar
        private void iconButton1_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Usuario usuario = new Usuario()
            {
                IdUsuario = Convert.ToInt32(txtId.Text),
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

            if(usuario.IdUsuario == 0)
            {
                int idusuariogenerado = new CN_Usuario().Registrar(usuario, out mensaje);

                if (idusuariogenerado != 0)
                {
                    dgvData.Rows.Add(new object[] { "", idusuariogenerado, txtDNI.Text, txtNombre.Text, txtApellido.Text, txtClave.Text, txtEmail.Text, txtDireccion.Text, dtpFecha.Value, txtTelefono.Text, ((OpcionCombo)cboRol.SelectedItem).Texto.ToString(), ((OpcionCombo)cboEstado.SelectedItem).Texto.ToString() });
                    limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            else
            {
                bool resultado = new CN_Usuario().Editar(usuario, out mensaje);
                if (resultado)
                {
                    DataGridViewRow row = dgvData.Rows[Convert.ToInt32(txtIndice.Text)];
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
                }
                else
                {
                    MessageBox.Show(mensaje);
                }

            }


        }

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

        

        //private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.ColumnIndex == dgvData.Columns["btnseleccionar"].Index && e.RowIndex >= 0)
        //    {
        //        int indice = e.RowIndex;
        //        if (indice >= 0)
        //        {
        //            txtIndice.Text = indice.ToString();
        //            txtId.Text = dgvData.Rows[indice].Cells["id"].Value.ToString();
        //            txtDNI.Text = dgvData.Rows[indice].Cells["Documento"].Value.ToString();
        //            txtNombre.Text = dgvData.Rows[indice].Cells["Nombre"].Value.ToString();
        //            txtApellido.Text = dgvData.Rows[indice].Cells["Apellido"].Value.ToString();
        //            txtClave.Text = dgvData.Rows[indice].Cells["Clave"].Value.ToString();
        //            txtEmail.Text = dgvData.Rows[indice].Cells["Email"].Value.ToString();
        //            txtDireccion.Text = dgvData.Rows[indice].Cells["Direccion"].Value.ToString();
        //            dtpFecha.Value = Convert.ToDateTime(dgvData.Rows[indice].Cells["FechaNacimiento"].Value);
        //            txtTelefono.Text = dgvData.Rows[indice].Cells["Telefono"].Value.ToString();

        //            string rolEnDataGrid = dgvData.Rows[indice].Cells["Rol"].Value.ToString();
        //            cboRol.SelectedIndex = cboRol.FindStringExact(rolEnDataGrid);


        //            string estadoEnDataGrid = dgvData.Rows[indice].Cells["Estado"].Value.ToString();


        //            cboEstado.SelectedIndex = cboEstado.FindStringExact(estadoEnDataGrid);
        //        }
        //    }
        //}

        private void btnlimpiarCampos_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
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

       

        //private void bunifuDataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.ColumnIndex == dgvData.Columns["btnseleccionar"].Index && e.RowIndex >= 0)
        //    {
        //        int indice = e.RowIndex;
        //        if (indice >= 0)
        //        {
        //            txtIndice.Text = indice.ToString();
        //            txtId.Text = dgvData.Rows[indice].Cells["id"].Value.ToString();
        //            txtDNI.Text = dgvData.Rows[indice].Cells["Documento"].Value.ToString();
        //            txtNombre.Text = dgvData.Rows[indice].Cells["Nombre"].Value.ToString();
        //            txtApellido.Text = dgvData.Rows[indice].Cells["Apellido"].Value.ToString();
        //            txtClave.Text = dgvData.Rows[indice].Cells["Clave"].Value.ToString();
        //            txtEmail.Text = dgvData.Rows[indice].Cells["Email"].Value.ToString();
        //            txtDireccion.Text = dgvData.Rows[indice].Cells["Direccion"].Value.ToString();
        //            dtpFecha.Value = Convert.ToDateTime(dgvData.Rows[indice].Cells["FechaNacimiento"].Value);
        //            txtTelefono.Text = dgvData.Rows[indice].Cells["Telefono"].Value.ToString();

        //            string rolEnDataGrid = dgvData.Rows[indice].Cells["Rol"].Value.ToString();
        //            cboRol.SelectedIndex = cboRol.FindStringExact(rolEnDataGrid);


        //            string estadoEnDataGrid = dgvData.Rows[indice].Cells["Estado"].Value.ToString();


        //            cboEstado.SelectedIndex = cboEstado.FindStringExact(estadoEnDataGrid);
        //        }
        //    }
        //}

        private void dgvData_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvData.Columns["btnseleccionar"].Index && e.RowIndex >= 0)
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvData.Rows[indice].Cells["id"].Value.ToString();
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
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            FiltrarUsuarios(false);
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            FiltrarUsuarios(true);
        }

        private void FiltrarUsuarios(bool estadoActivo)
        {
            // Limpia el cuadro de búsqueda
            txtBusqueda.Clear();

            // Recorre las filas del DataGridView y muestra/oculta según el estado
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                bool estadoFila = row.Cells["Estado"].Value.ToString() == "Activo";

                if (estadoActivo && estadoFila)
                {
                    // Mostrar usuarios activos
                    row.Visible = true;
                }
                else if (!estadoActivo && !estadoFila)
                {
                    // Mostrar usuarios inactivos (dados de baja)
                    row.Visible = true;
                }
                else
                {
                    // Ocultar otros usuarios
                    row.Visible = false;
                }
            }
        }
    }
}
