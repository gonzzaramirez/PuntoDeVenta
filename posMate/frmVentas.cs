using CapaEntidad;
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
using System.Speech.Synthesis;
using FontAwesome.Sharp;

namespace CapaPresentacion
{
    public partial class frmVentas : Form
    {
        private Usuario usuarioActual;

        private List<Producto> carrito = new List<Producto>();
        public frmVentas(Usuario oUsuario = null)
        {
            usuarioActual = oUsuario;
            InitializeComponent();
        }







        private void frmVentas_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = DateTime.Now;
            verificarCheck();
        }

        private void verificarCheck()
        {
            if (carrito.Count > 0)
            {

                btnConfirmarCompra.Enabled = true;
                btnConfirmarCompra.BackColor = Color.Green;
            }
            else
            {
                btnConfirmarCompra.Enabled = false;
                btnConfirmarCompra.BackColor = SystemColors.Control;
            }

            iconButton1.Enabled = true;
            iconButton1.BackColor = Color.ForestGreen;

            btnCarrito.BackColor = SystemColors.Control;
            btnCarrito.Enabled = false;

            txtDNII.Focus();
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtCantidad.Enabled = false;
            txtPago.Enabled = false;
        }

        private void verifiado()
        {
            iconButton1.Enabled = false;
            iconButton1.BackColor = SystemColors.Control;

            btnCarrito.BackColor = Color.MediumTurquoise;
            btnCarrito.Enabled = true;
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtCantidad.Enabled = true;
            txtPago.Enabled = true;
        }



        private void iconButton1_Click(object sender, EventArgs e)
        {
            verifiado();
            CN_Cliente negocioCliente = new CN_Cliente();
            int dni = int.Parse(txtDNII.Text);
            Cliente clienteCargado = negocioCliente.BuscarClientePorDNI(dni);
            if(clienteCargado != null)
            {
                MessageBox.Show("Bienvenido "  + clienteCargado.Nombre + " " + clienteCargado.Apellido);
                int id = clienteCargado.IdCliente;
                txtId.Text = id.ToString();

                txtDNII.Text = clienteCargado.DNI.ToString();
                txtDNII.Enabled = false;

                txtNombre.Text = clienteCargado.Nombre;
                txtNombre.Enabled = false;

                txtApellido.Text = clienteCargado.Apellido;
                txtApellido.Enabled = false;


            }
            else
            {
                MessageBox.Show("Cliente inexistente, cargue sus datos");
                limpiarVerdificado();
            }
        }

        private void limpiarVerdificado()
        {
            txtNombre.Focus();
            txtDNII.ReadOnly = true;

            

        }

        private void btnCarrito_Click(object sender, EventArgs e)
        {

            Cliente nuevoCliente = new Cliente()
            {
                DNI = Convert.ToInt32(txtDNII.Text),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text

            };

            CN_Cliente negocioCliente = new CN_Cliente();
            if(negocioCliente.AgregarCliente(nuevoCliente))
            {
                MessageBox.Show("Cliente registrado");
            }

        }
    }
}
