using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace posMate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnUsuario.Height;
            SidePanel.Top = btnUsuario.Top;
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
            SidePanel.Height = btnDescuentos.Height;
            SidePanel.Top = btnDescuentos.Top;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button8.Height;
            SidePanel.Top = button8.Top;
        }
    }
}
