using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using CapaNegocios;
using CapaPresentacion.Utilidades;
using FontAwesome.Sharp;

namespace CapaPresentacion
{
    public partial class frmCompras : Form
    {
       

        // para saber que usuario compra
        private Usuario usuarioActual;
        // Declara una lista para el carrito
        private List<Producto> carrito = new List<Producto>();


        public frmCompras(Usuario oUsuario = null)
        {

            usuarioActual = oUsuario;
            InitializeComponent();
            txtCodigoBarra.Focus();
            verificarCheck();
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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


            iconButton2.Enabled = true;
            iconButton2.BackColor = Color.ForestGreen;
            
            btnCarrito.BackColor = SystemColors.Control;
            btnCarrito.Enabled = false;
           
            txtNombree.Enabled = false;
            txtDesc.Enabled = false;
            txtCantidad.Enabled = false;
            txtPrecioCompra.Enabled = false;
            txtPrecioVenta.Enabled = false;
            dtpFecha.Enabled = false;
            cboCategoria.Enabled = false;
            cboProveedor.Enabled = false;
            cboEstadoo.Enabled = false;
        }

        private void verificado()
        {
           

            iconButton2.Enabled = false;
            iconButton2.BackColor = SystemColors.Control;
          
            btnCarrito.BackColor = Color.MediumTurquoise;
            btnCarrito.Enabled = true;
           

            aviso.Visible = false;
            txtNombree.Enabled = true;
            txtDesc.Enabled = true;
            txtCantidad.Enabled = true;
            txtPrecioCompra.Enabled = true;
            txtPrecioVenta.Enabled = true;
            dtpFecha.Enabled = true;
            cboCategoria.Enabled = true;
            cboProveedor.Enabled = true;
            cboEstadoo.Enabled = true;
        }



        private void frmCompras_Load(object sender, EventArgs e)
        {



            // Agregar opciones "Activo" y "No Activo" al ComboBox cboEstado
            cboEstadoo.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboEstadoo.Items.Add(new OpcionCombo() { Valor = 0, Texto = "Inactivo" });

            // Configurar el ComboBox cboEstado para mostrar el texto y usar el valor al seleccionar
            cboEstadoo.DisplayMember = "Texto";
            cboEstadoo.ValueMember = "Valor";

            // Establecer la opción seleccionada inicialmente como "Activo"
            cboEstadoo.SelectedIndex = 0;

            // Obtener una lista de proveedores y agregarlos al ComboBox cboProveedor
            List<Proveedor> listaProveedor = new CN_Proveedor().ObtenerProveedores();
            foreach (var item in listaProveedor)
            {
                cboProveedor.Items.Add(new OpcionCombo() { Valor = item.IdProveedor, Texto = item.Nombre });
            }

            // Configurar el ComboBox provedor para mostrar el texto y usar el valor al seleccionar
            cboProveedor.DisplayMember = "Texto";
            cboProveedor.ValueMember = "Valor";

            // Establecer la opción seleccionada inicialmente como administrador
            cboProveedor.SelectedIndex = 0;

            // Obtener una lista de categorias y agregarlos al ComboBox cbocategoria
            List<Categoria> listaCategoria = new CN_Categoria().ObtenerCategorias();
            foreach (var item in listaCategoria)
            {
                cboCategoria.Items.Add(new OpcionCombo() { Valor = item.IdCategoria, Texto = item.Descripcion });
            }

            // Configurar el ComboBox provedor para mostrar el texto y usar el valor al seleccionar
            cboCategoria.DisplayMember = "Texto";
            cboCategoria.ValueMember = "Valor";

            // Establecer la opción seleccionada inicialmente como administrador
            cboCategoria.SelectedIndex = 0;

            // Obtener una lista de productos y mostrarlos en el dgv
           



        }

        //boton agregar carrito
        private void btnCarrito_Click(object sender, EventArgs e)
        {
            verificarCheck();

            Producto nuevoProducto = new Producto
            {
                codigoProducto = txtCodigoBarra.Text,
                Nombre = txtNombree.Text,
                Descripcion = txtDesc.Text,
                Stock = Convert.ToInt32(txtCantidad.Text),
                PrecioCompra = Convert.ToDecimal(txtPrecioCompra.Text),
                PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text),
                FechaRegistro = dtpFecha.Value,
                Estado = cboEstadoo.SelectedIndex == 0,
                oCategoria = new Categoria() { IdCategoria = Convert.ToInt32(((OpcionCombo)cboCategoria.SelectedItem).Valor) }

            };



            // Agrega el producto al carrito
            carrito.Add(nuevoProducto);
            MessageBox.Show("Producto agregado al carrito. Total de productos en el carrito: " + carrito.Count);

            if (carrito.Count > 0)
            {
                btnConfirmarCompra.BackColor = Color.ForestGreen;
                btnConfirmarCompra.Enabled = true;
            }

            CN_Producto negocioProducto = new CN_Producto();

            if (txtCodigoBarra.Enabled)
            {
                if (negocioProducto.AgregarProducto(nuevoProducto))
                {
                    MessageBox.Show("Producto insertado en la base de datos correctamente.");
                    ActualizarDataGridView(carrito);
                }
            }
            else
            {
                int idProducto = int.Parse(txtId.Text);
                Producto producto = negocioProducto.ObtenerProductos().FirstOrDefault(p => p.IdProducto == idProducto);
                producto.PrecioCompra = decimal.Parse(txtPrecioCompra.Text);
                
                producto.Stock = int.Parse(txtCantidad.Text);
                if (negocioProducto.EditarProducto(producto))
                {
                    MessageBox.Show("El producto se ha editado correctamente.");
                    ActualizarDataGridView(carrito);


                }

            }
            limpar();




        }

        private void ActualizarDataGridView(List<Producto> productos)
        {
            dgvData.Rows.Clear();

            foreach (Producto producto in productos)
            {
                string estadoTexto = producto.Estado ? "Activo" : "Inactivo";
                dgvData.Rows.Add(
                    producto.Nombre,
                    producto.Stock,
                    producto.PrecioCompra,
                    producto.PrecioVenta,
                    producto.FechaRegistro
                );
            }
        }

        private void btnConfirmarCompra_Click(object sender, EventArgs e)
        {
            verificarCheck();
            int idProveedor = Convert.ToInt32(((OpcionCombo)cboProveedor.SelectedItem).Valor);
            decimal montoTotal = CalcularMontoTotalDelCarrito();
            Compra nuevoCompra = new Compra
            {
                oUsuario = new Usuario() { IdUsuario = usuarioActual.IdUsuario },
                oProveedor = new Proveedor() { IdProveedor = idProveedor },
                MontoTotal = montoTotal,
                FechaRegistro = dtpFecha.Value
            };

            CN_Compra negocioCompra = new CN_Compra();
            CN_DetalleCompra negocioDetalle = new CN_DetalleCompra();
            CN_Producto negocioProducto = new CN_Producto();

            if (negocioCompra.AgregarCompra(nuevoCompra))
            {
                int idCompra = negocioCompra.obtenerUltimoIdCompra();

                if (idCompra > 0)
                {
                    List<DetalleCompra> detallesCompra = new List<DetalleCompra>();
                    List<Producto> productosDisponibles = negocioProducto.ObtenerProductos();

                    foreach (Producto productoEnCarrito in carrito)
                    {
                        Producto productoEnBaseDeDatos = productosDisponibles.FirstOrDefault(p =>
                            p.Nombre == productoEnCarrito.Nombre && p.Descripcion == productoEnCarrito.Descripcion);

                        if (productoEnBaseDeDatos != null)
                        {
                            DetalleCompra detalle = new DetalleCompra
                            {
                                IdCompra = idCompra,
                                oProducto = new Producto() { IdProducto = productoEnBaseDeDatos.IdProducto },
                                PrecioCompra = productoEnCarrito.PrecioCompra,
                                PrecioVenta = productoEnCarrito.PrecioVenta,
                                Cantidad = productoEnCarrito.Stock,
                                MontoTotal = productoEnCarrito.PrecioCompra * productoEnCarrito.Stock,
                                FechaRegistro = productoEnCarrito.FechaRegistro
                            };

                            if (negocioDetalle.AgregarDetalleCompra(detalle))
                            {
                                detallesCompra.Add(detalle);
                            }
                        }
                    }

                    nuevoCompra.DetallesCompra = detallesCompra;
                    carrito.Clear();
                    ActualizarDataGridView(carrito);
                    MessageBox.Show("Compra confirmada con éxito.");
                }
            }
        }




        private decimal CalcularMontoTotalDelCarrito()
        {
            decimal montoTotal = 0;

            // Recorre los productos en el carrito y suma el valor total de cada uno
            foreach (Producto producto in carrito)
            {
                decimal valorTotalProducto = producto.Stock * producto.PrecioCompra;
                montoTotal += valorTotalProducto;
            }

            return montoTotal;
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            verificado();
            CN_Producto negocioProducto = new CN_Producto();
            string codigoProducto = txtCodigoBarra.Text;
            Producto productoCargado = negocioProducto.ObtenerProductoPorCodigoProducto(codigoProducto);

            if (productoCargado != null)
            {
                MessageBox.Show("Producto existente");
                txtCantidad.Focus();
                int id = productoCargado.IdProducto;
                txtId.Text = id.ToString();

                txtCodigoBarra.Text = productoCargado.codigoProducto;
                txtCodigoBarra.Enabled = false;
                txtNombree.Text = productoCargado.Nombre;
                txtNombree.Enabled = false;
                txtDesc.Text = productoCargado.Descripcion;
                txtDesc.Enabled = false;
                txtPrecioVenta.Text = productoCargado.PrecioVenta.ToString();
                txtPrecioVenta.Enabled = false;
                cboCategoria.Enabled = false;
                cboEstadoo.Enabled = false;
                
            }
            else
            {
                MessageBox.Show("Producto inexistente, cargue sus datos");
                limpar();
            }




        }

        private void limpar()
        {
            txtCodigoBarra.Focus();
            txtCodigoBarra.Enabled  = true;
            txtCodigoBarra.Clear();
            txtNombree.Clear();
            txtDesc.Clear();
            txtCantidad.Clear();
            txtPrecioCompra.Clear();    
            txtPrecioVenta.Clear();
           

        }
    }
}