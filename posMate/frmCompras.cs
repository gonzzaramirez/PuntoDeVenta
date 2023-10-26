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
using CapaNegocio;
using CapaPresentacion.Utilidades;

namespace CapaPresentacion
{
    public partial class frmCompras : Form
    {
        // Declara una lista para el carrito
        private List<Producto> carrito = new List<Producto>();
        public frmCompras()
        {
            InitializeComponent();
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
            List<Producto> ObtenerProducto= new CN_Producto().ObtenerProductos();

            foreach (DataGridViewColumn columna in dgvData.Columns)
            {
                // Agregar a cboBusqueda
                if (columna.Visible == true && columna.Name != "Estado")
                {
                    cboBusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }

            // Configurar el ComboBox cboBusqueda para mostrar el texto y usar el valor al seleccionar
            cboBusqueda.DisplayMember = "Texto";
            cboBusqueda.ValueMember = "Valor";

            // Establecer la opción seleccionada inicialmente como la primera columna visible
            cboBusqueda.SelectedIndex = 0;

            foreach (Producto producto in ObtenerProducto)
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

        private void iconButton3_Click(object sender, EventArgs e)
        {
            // Crea un objeto Producto
            Producto nuevoProducto = new Producto
            {
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

            CN_Producto negocioProducto = new CN_Producto();


            if (negocioProducto.AgregarProducto(nuevoProducto))
            {
                MessageBox.Show("Producto insertado en la base de datos correctamente.");
                ActualizarDataGridView();
            }

          


        }

        private void ActualizarDataGridView()
        {
            // Obtener una nueva lista de categorías y actualizar el DataGridView
            List<Producto> ObtenerProducto = new CN_Producto().ObtenerProductos();
            dgvData.Rows.Clear();

            foreach (Producto producto in ObtenerProducto)
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


    }
}
