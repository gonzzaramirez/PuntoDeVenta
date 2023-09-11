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
using CapaNegocio;
using CapaEntidad;

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
            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(txtDNI.Text) || string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            List<Usuario> usuarios = new CN_Usuario().Listar();

            Usuario oUsuario = usuarios.FirstOrDefault(u => u.DNI == txtDNI.Text && u.Clave == txtClave.Text);

            if (oUsuario != null)
            {
                Form1 form1 = new Form1(oUsuario);
                form1.Show();
                this.Hide();
                form1.FormClosing += frm_closing;
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas. Por favor, verifique su DNI y Clave.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            txtDNI.Text = "";
            txtClave.Text = "";
            this.Show();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
