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
    public partial class frmReportes : Form
    {
        private Usuario usuarioActual;
        public frmReportes(Usuario oUsuario = null)
        {
            usuarioActual = oUsuario;
            InitializeComponent();
        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            frmVerCompras formularioCompras = new frmVerCompras();
            formularioCompras.Show();

            // Obtener el formulario padre (Form1)
            //Form1 formPadre = this.ParentForm as Form1;

            //formPadre.MostrarFormularioEnContenedor(formularioCompras);
        }

        private void categoriaGanancias_Click(object sender, EventArgs e)
        {
            FormGananciasPorCategoria formGananciasPorCategoria = new FormGananciasPorCategoria();
            formGananciasPorCategoria.Show();
        }

        private void Ventas_Click(object sender, EventArgs e)
        {
            frmVerVentas formularioVentas = new frmVerVentas();
            formularioVentas.Show();
        }
    }
}
