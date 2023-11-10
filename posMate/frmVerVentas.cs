using CapaEntidad;
using CapaNegocio;
using CapaNegocios;
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
    public partial class frmVerVentas : Form
    {
        public frmVerVentas()
        {
            InitializeComponent();
        }

        private void frmVerVentas_Load(object sender, EventArgs e)
        {
            CN_Venta negocioVenta = new CN_Venta();

            // Obtener la lista de compras desde la capa de negocio
            List<Venta> ventas = negocioVenta.ObtenerVentas();

            // Establecer el texto de lblTotalVentas para mostrar el total de ventas
            lblTotalVentas.Text =  ventas.Count.ToString();

            dgvDataVenta.Rows.Clear();

            foreach (Venta venta in ventas)
            {
                // Accede a las propiedades Nombre de Usuario y Proveedor
                string Vendedor = venta.oUsuario.Nombre;

                dgvDataVenta.Rows.Add(
                    venta.IdVenta,
                    Vendedor,
                    venta.MontoPago,
                    venta.MontoCambio,
                    venta.MontoTotal,
                    venta.FechaRegistro
                );
            }

        }


        private void dgvDataVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Obtén el índice de la fila seleccionada
            int index = e.RowIndex;

            // Si el índice es válido (es decir, el usuario hizo clic en una fila, no en el encabezado de la columna)
            if (index != -1)
            {
                // Obtén el IdCompra de la fila seleccionada
                int idVenta = Convert.ToInt32(dgvDataVenta.Rows[index].Cells[0].Value);

                // Crea una instancia de CN_DetalleCompra
                CN_DetalleVenta negocioDetalleVenta = new CN_DetalleVenta();

                // Obtén los detalles de la compra desde la capa de negocio
                List<DetalleVenta> detallesVenta = negocioDetalleVenta.ObtenerDetallesVenta(idVenta);

                // Limpia las filas existentes en dgvDetalleCompra
                dgvDetalleVenta.Rows.Clear();

                // Agrega los detalles de la compra a dgvDetalleCompra
                foreach (DetalleVenta detalleVenta in detallesVenta)
                {
                    dgvDetalleVenta.Rows.Add(
                        detalleVenta.oProducto.IdProducto,
                        detalleVenta.oProducto.Nombre,
                        detalleVenta.PrecioVenta,
                        detalleVenta.Cantidad,
                        detalleVenta.Subtotal
                    );
                }

                // Establecer el texto de lblTotalDetalleVentas para mostrar el total de registros en detalle de venta
                lblTotalDetalleVentas.Text = detallesVenta.Count.ToString();
            }
        }

        private void dgvDetalleVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalVentas_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalDetalleVentas_Click(object sender, EventArgs e)
        {

        }
    }
}
