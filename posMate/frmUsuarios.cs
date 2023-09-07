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
namespace CapaPresentacion
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
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

            int idusuariogenerado = new CN_Usuario().Registrar(usuario, out mensaje);
            
            if( idusuariogenerado != 0)
            {
                dgvData.Rows.Add(new object[] { "", idusuariogenerado, txtDNI.Text, txtNombre.Text, txtApellido.Text, txtClave.Text, txtEmail.Text, txtDireccion.Text, dtpFecha.Value, txtTelefono.Text, ((OpcionCombo)cboRol.SelectedItem).Texto.ToString(), ((OpcionCombo)cboEstado.SelectedItem).Texto.ToString() });
                limpiar();
            }
            else
            {
                MessageBox.Show(mensaje);
            }
            
            
        }

        private void limpiar()
        {
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

        private void iconButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            // Verifica si la celda actual es la columna con el botón (reemplaza "btnseleccionar" con el nombre real de tu columna de botón)
            if (dgvData.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources._299110_check_sign_icon.Width;
                var h = Properties.Resources._299110_check_sign_icon.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
                e.Graphics.DrawImage(Properties.Resources._299110_check_sign_icon, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvData.Columns["btnseleccionar"].Index && e.RowIndex >= 0)
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
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

    }
}
