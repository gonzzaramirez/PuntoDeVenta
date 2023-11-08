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
using CapaNegocios;

namespace CapaPresentacion
{
    public partial class frmVerCompras : Form
    {
        public frmVerCompras()
        {
            InitializeComponent();
        }

        private void frmVerCompras_Load(object sender, EventArgs e)
        {
            CN_Compra negocioCompra = new CN_Compra();

            // Obtener la lista de compras desde la capa de negocio
            List<Compra> compras = negocioCompra.ObtenerCompras();

            dgvData.Rows.Clear();

            foreach (Compra compra in compras)
            {
                // Accede a las propiedades Nombre de Usuario y Proveedor
                string nombreUsuario = compra.oUsuario.Nombre;
                string nombreProveedor = compra.oProveedor.Nombre;

                dgvData.Rows.Add(
                    compra.IdCompra,
                    nombreUsuario,
                    nombreProveedor,
                    compra.MontoTotal,
                    compra.FechaRegistro
                );



            }
    }
    }
}
