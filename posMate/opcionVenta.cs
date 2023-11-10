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
    public partial class opcionVenta : Form
    {
        private Usuario usuarioActual;
        public opcionVenta(Usuario oUsuario = null)
        {
            usuarioActual = oUsuario;
            InitializeComponent();
        }

        private void opcionVenta_Load(object sender, EventArgs e)
        {

        }

       

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario de compras (frmCompras)
            frmVentas formularioVentas = new frmVentas(usuarioActual);

            // Obtener el formulario padre (Form1)
            Form1 formPadre = this.ParentForm as Form1;

            if (formPadre != null)
            {
                // Mostrar el formulario de compras en el contenedor de Form1
                formPadre.MostrarFormularioEnContenedor(formularioVentas);

                // Cerrar el formulario actual (opcionCompra)
                this.Close();
            }

        }

        private void bunifuGradientPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}
