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
            
            dgvData.Rows.Add(new object[] { "", txtId.Text, txtDNI.Text, txtNombre.Text, txtApellido.Text, txtClave.Text, txtEmail.Text, txtDireccion.Text, dtpFecha.Value, txtTelefono.Text, ((OpcionCombo)cboRol.SelectedItem).Texto.ToString(), ((OpcionCombo)cboEstado.SelectedItem).Texto.ToString() });
            limpar();
        }

        private void limpar()
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
    }
}
