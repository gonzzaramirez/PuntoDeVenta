using posMate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
           Form1 form1 = new Form1();
            form1.Show();
            this.Hide();

            form1.FormClosing += frm_closing;

        }

        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            txtUsuario.Text = "";
            txtClave.Text = "";
            this.Show();
        }
    }
}
