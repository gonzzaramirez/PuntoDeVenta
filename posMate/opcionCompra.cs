using CapaEntidad;
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
    public partial class opcionCompra : Form
    {
        private Usuario usuarioActual;
        public opcionCompra(Usuario oUsuario = null)
        {
            usuarioActual = oUsuario;
            InitializeComponent();
        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        //ver compra
        private void bunifuButton22_Click(object sender, EventArgs e)
        {

        }


        //realizar compra
        private void bunifuButton22_Click_1(object sender, EventArgs e)
        {
            // Crear una instancia del formulario de compras (frmCompras)
            frmCompras formularioCompras = new frmCompras(usuarioActual);

            // Obtener el formulario padre (Form1)
            Form1 formPadre = this.ParentForm as Form1;

            if (formPadre != null)
            {
                // Mostrar el formulario de compras en el contenedor de Form1
                formPadre.MostrarFormularioEnContenedor(formularioCompras);

                // Cerrar el formulario actual (opcionCompra)
                this.Close();
            }

        }

        private void btnVerCompra_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario de compras (frmCompras)
            frmVerCompras formularioCompras = new frmVerCompras();

            // Obtener el formulario padre (Form1)
            Form1 formPadre = this.ParentForm as Form1;

            if (formPadre != null)
            {
                // Mostrar el formulario de compras en el contenedor de Form1
                formPadre.MostrarFormularioEnContenedor(formularioCompras);

                // Cerrar el formulario actual (opcionCompra)
                this.Close();
            }

        }

        private void bunifuLabel4_Click(object sender, EventArgs e)
        {

        }

        private void btnVerCompra_Click_1(object sender, EventArgs e)
        {

            // Crear una instancia del formulario de compras (frmCompras)
            frmVerCompras formularioCompras = new frmVerCompras();

            // Obtener el formulario padre (Form1)
            Form1 formPadre = this.ParentForm as Form1;

            if (formPadre != null)
            {
                // Mostrar el formulario de compras en el contenedor de Form1
                formPadre.MostrarFormularioEnContenedor(formularioCompras);

                // Cerrar el formulario actual (opcionCompra)
                this.Close();
            }

        }
    }
}
