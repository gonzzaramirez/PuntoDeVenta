using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shapes;
using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using CapaNegocios;
using CapaPresentacion;
using CapaPresentacion.Utilidades;
using FontAwesome.Sharp;

namespace CapaPresentacion
{
    public partial class frmVentas : Form
    {
        private Usuario usuarioActual;
        private int idClienteCreado;

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

            //obtener los productos
            List <Producto> listaProducto = new CN_Producto().ObtenerProductos();
            foreach (var producto in listaProducto)
            {
                cboProducto.Items.Add(new OpcionCombo() { Valor = producto.IdProducto, Texto = producto.Nombre });
            }
            cboProducto.DisplayMember = "Texto";
            cboProducto.ValueMember = "Valor";
            cboProducto.SelectedIndex = 0;
           
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
            cboProducto.Enabled = false;
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
            cboProducto.Enabled = true;
        }


        //verificar
        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDNII.Text))
            {
                MessageBox.Show("Por favor, completa el campo DNI.");
                return;
            }

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
            // Validación de campos obligatorios
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtDNII.Text) ||
                string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos obligatorios.");
                return;
            }

            CN_Cliente negocioCliente = new CN_Cliente();

            

            Cliente nuevoCliente = new Cliente()
            {
                DNI = Convert.ToInt32(txtDNII.Text),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text
            };

            negocioCliente.AgregarCliente(nuevoCliente);

            if (txtId.Text == "0")
            {
                int idClienteCreado = negocioCliente.ObtenerIdClientePorDNI(Convert.ToInt32(txtDNII.Text));
                txtId.Text = idClienteCreado.ToString();
            }

            CN_Producto negocioProducto = new CN_Producto();

            OpcionCombo productoSeleccionado = (OpcionCombo)cboProducto.SelectedItem;

            int idProducto = (int)productoSeleccionado.Valor; // ID del producto
            int cantidad = Convert.ToInt32(txtCantidad.Text);

            Producto producto = negocioProducto.ObtenerProductoPorId(idProducto);
            // Verificar si el producto existe y la cantidad es válida
            if (producto != null && cantidad > 0 && cantidad <= producto.Stock)
            {

                negocioProducto.ActualizarStockProductoVenta(idProducto, cantidad);
                carrito.Add(producto);

                if (carrito.Count > 0)
                {
                    btnConfirmarCompra.BackColor = Color.ForestGreen;
                    btnConfirmarCompra.Enabled = true;
                }

                // Agregar los datos del producto al DataGridView
                dgvData.Rows.Add(new object[]
                {
             txtDNII.Text, // DNI del cliente
             producto.Nombre, // Nombre del producto
             producto.PrecioVenta, // Precio del producto
             cantidad, // Cantidad
            producto.PrecioVenta * cantidad // Total
                });

                // Limpiar los campos después de agregar el producto al carrito
                txtCantidad.Clear();
                cboProducto.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("La cantidad ingresada excede el stock del producto.");
            }
        }


        private decimal CalcularMontoTotalDelCarrito()
        {
            decimal montoTotal = 0;

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (row.Cells["Cantidad"].Value != null)
                {
                    int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                    decimal precioVenta = Convert.ToDecimal(row.Cells["Precio"].Value);
                    decimal valorTotalProducto = cantidad * precioVenta;
                    montoTotal += valorTotalProducto;
                }
            }

            return montoTotal;
        }


        private void btnConfirmarCompra_Click(object sender, EventArgs e)
        {
            verificarCheck();

            if (txtId != null && txtId.Text != null)
            {
                int idCliente = 0;
                if (int.TryParse(txtId.Text, out idCliente))
                {
                    decimal montoTotal = CalcularMontoTotalDelCarrito();

                    if (txtPago != null && txtPago.Text != null)
                    {
                        decimal montoPago;
                        if (decimal.TryParse(txtPago.Text, out montoPago))
                        {
                            decimal montoCambio = montoPago - montoTotal;

                            Venta nuevaVenta = new Venta
                            {
                                oUsuario = new Usuario() { IdUsuario = usuarioActual.IdUsuario },
                                oCliente = new Cliente() { IdCliente = idCliente },
                                MontoPago = montoPago,
                                MontoCambio = montoCambio,
                                MontoTotal = montoTotal,
                                FechaRegistro = dtpFecha.Value,
                            };

                            CN_Venta negocioVenta = new CN_Venta();
                            if (negocioVenta.AgregarVenta(nuevaVenta))
                            {
                                MessageBox.Show("Compra confirmada con éxito.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("El monto de pago no es válido.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El campo de monto de pago es nulo o vacío.");
                    }
                }
                else
                {
                    MessageBox.Show("El ID del cliente no es un número válido.");
                }
            }
            else
            {
                MessageBox.Show("El campo de ID del cliente es nulo o vacío.");
            }
        }
    }

}



