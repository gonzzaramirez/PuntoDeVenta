using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Producto
    {
        private CD_Producto ocd_producto = new CD_Producto();

        public List<Producto> ObtenerProductos()
        {
            return ocd_producto.ObtenerProductos();
        }

        public bool AgregarProducto(Producto producto)
        {
            
            return ocd_producto.AgregarProducto(producto);
        }

        public bool EditarProducto(Producto producto)
        {
            return ocd_producto.EditarProducto(producto);
        }

        public Producto ObtenerProductoPorCodigoProducto(string codigoProducto)
        {
            
            return ocd_producto.ObtenerProductoPorCodigoProducto(codigoProducto);
        }


        public bool ActualizarStockProducto(int productoId, int cantidad)
        {
            // Aquí puedes agregar lógica adicional si es necesario antes de llamar a la capa de datos.
            return ocd_producto.ActualizarStockProducto(productoId, cantidad);
        }

    }
}
