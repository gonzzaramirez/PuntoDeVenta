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
            // Puedes agregar validaciones u otra lógica de negocio aquí antes de llamar al método en la capa de datos.
            return ocd_producto.AgregarProducto(producto);
        }

        public bool EditarProducto(Producto producto)
        {
            // Puedes agregar validaciones u otra lógica de negocio aquí antes de llamar al método en la capa de datos.
            return ocd_producto.EditarProducto(producto);
        }
    }
}
