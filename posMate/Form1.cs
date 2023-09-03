using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaPresentacion;
using FontAwesome.Sharp;

namespace posMate
{
    public partial class Form1 : Form
    {
        private static Usuario usuarioActual;
       
        public Form1(Usuario objUsuario)
        {
            usuarioActual = objUsuario;

            InitializeComponent();
        }



        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            // ver en que menu estamos
            SidePanel.Height = btnUsuario.Height;
            SidePanel.Top = btnUsuario.Top;

            // Verificar si el formulario ya está abierto en el panel
            if (Application.OpenForms["frmUsuarios"] == null)
            {
                // Si no está abierto, crear una instancia del formulario frmUsuarios
                frmUsuarios formUsuarios = new frmUsuarios();

                // Establecer el formulario frmUsuarios como un formulario secundario
                formUsuarios.TopLevel = false;
                formUsuarios.FormBorderStyle = FormBorderStyle.None;
                formUsuarios.Dock = DockStyle.Fill;

                // Limpiar el panel contenedor antes de agregar el formulario
                contenedor.Controls.Clear();

                // Agregar el formulario frmUsuarios al panel
                contenedor.Controls.Add(formUsuarios);

                // Mostrar el formulario frmUsuarios
                formUsuarios.Show();
            }
            else
            {
                // Si el formulario ya está abierto, simplemente traerlo al frente
                Application.OpenForms["frmUsuarios"].BringToFront();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnBackup.Height;
            SidePanel.Top = btnBackup.Top;
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnVentas.Height;
            SidePanel.Top = btnVentas.Top;
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnProveedores.Height;
            SidePanel.Top = btnProveedores.Top;
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnProductos.Height;
            SidePanel.Top = btnProductos.Top;
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnReportes.Height;
            SidePanel.Top = btnReportes.Top;
        }

        private void btnDescuentos_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnCompras.Height;
            SidePanel.Top = btnCompras.Top;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button8.Height;
            SidePanel.Top = button8.Top;
        }

        private void btnVentas_Click_1(object sender, EventArgs e)
        {
            SidePanel.Height = btnVentas.Height;
            SidePanel.Top = btnVentas.Top;
        }

        private void btnProveedores_Click_1(object sender, EventArgs e)
        {
            SidePanel.Height = btnProveedores.Height;
            SidePanel.Top = btnProveedores.Top;
        }

        private void btnProductos_Click_1(object sender, EventArgs e)
        {
            SidePanel.Height = btnProductos.Height;
            SidePanel.Top = btnProductos.Top;
        }

       

        private void btnReportes_Click_1(object sender, EventArgs e)
        {
            SidePanel.Height = btnReportes.Height;
            SidePanel.Top = btnReportes.Top;
        }

        private void btnDescuentos_Click_1(object sender, EventArgs e)
        {
            SidePanel.Height = btnCompras.Height;
            SidePanel.Top = btnCompras.Top;
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            SidePanel.Height = button8.Height;
            SidePanel.Top = button8.Top;
        }

       

       

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnCategorias.Height;
            SidePanel.Top = btnCategorias.Top;
        }

        private void iconMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = usuarioActual.Nombre;
        }
    }
}
