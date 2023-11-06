using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Producto
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["cadena_conexion"].ConnectionString;
        public List<Producto> ObtenerProductos()
        {
            List<Producto> lista = new List<Producto>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT p.IdProducto, p.IdCategoria, p.Nombre, p.Descripcion, p.Stock, p.PrecioCompra, p.PrecioVenta, p.Estado, p.FechaRegistro, c.Descripcion AS CategoriaDescripcion, p.codigoProducto ");
                    query.AppendLine("FROM PRODUCTO p ");
                    query.AppendLine("LEFT JOIN CATEGORIA c ON p.IdCategoria = c.IdCategoria");

                    SqlCommand cmd = new SqlCommand(query.ToString(), con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Producto()
                            {
                                IdProducto = Convert.ToInt32(reader["IdProducto"]),
                                oCategoria = new Categoria
                                {
                                    IdCategoria = Convert.ToInt32(reader["IdCategoria"]),
                                    Descripcion = reader["CategoriaDescripcion"].ToString()
                                },
                                Nombre = reader["Nombre"].ToString(),
                                Descripcion = reader["Descripcion"].ToString(),
                                Stock = Convert.ToInt32(reader["Stock"]),
                                PrecioCompra = Convert.ToDecimal(reader["PrecioCompra"]),
                                PrecioVenta = Convert.ToDecimal(reader["PrecioVenta"]),
                                Estado = Convert.ToBoolean(reader["Estado"]),
                                FechaRegistro = (DateTime)(reader["FechaRegistro"] as DateTime?),
                                codigoProducto = reader["codigoProducto"].ToString()

                            });
                        }
                    }
                }
                catch (Exception ex)    
                {
                    // Manejo de errores aquí
                    lista = new List<Producto>();
                }
            }
            return lista;
        }

        public bool AgregarProducto(Producto producto)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "INSERT INTO PRODUCTO (IdCategoria, Nombre, Descripcion, Stock, PrecioCompra, PrecioVenta, Estado, FechaRegistro, codigoProducto) " +
                                   "VALUES (@IdCategoria, @Nombre, @Descripcion, @Stock, @PrecioCompra, @PrecioVenta, @Estado, @FechaRegistro, @codigoProducto)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@IdCategoria", producto.oCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    cmd.Parameters.AddWithValue("@Stock", producto.Stock);
                    cmd.Parameters.AddWithValue("@PrecioCompra", producto.PrecioCompra);
                    cmd.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                    cmd.Parameters.AddWithValue("@Estado", producto.Estado);
                    cmd.Parameters.AddWithValue("@FechaRegistro", producto.FechaRegistro);
                    cmd.Parameters.AddWithValue("@codigoProducto", producto.codigoProducto);

                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    // Manejo de errores aquí
                    return false;
                }
            }
        }

        public bool EditarProducto(Producto producto)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "UPDATE PRODUCTO " +
                                   "SET IdCategoria = @IdCategoria, Nombre = @Nombre, Descripcion = @Descripcion, Stock = @Stock, " +
                                   "PrecioCompra = @PrecioCompra, PrecioVenta = @PrecioVenta, Estado = @Estado, FechaRegistro = @FechaRegistro, codigoProducto = @codigoProducto " +
                                   "WHERE IdProducto = @IdProducto";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@IdProducto", producto.IdProducto);
                    cmd.Parameters.AddWithValue("@IdCategoria", producto.oCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    cmd.Parameters.AddWithValue("@Stock", producto.Stock);
                    cmd.Parameters.AddWithValue("@PrecioCompra", producto.PrecioCompra);
                    cmd.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                    cmd.Parameters.AddWithValue("@Estado", producto.Estado);
                    cmd.Parameters.AddWithValue("@FechaRegistro", producto.FechaRegistro);
                    cmd.Parameters.AddWithValue("@codigoProducto", producto.codigoProducto);

                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    // Manejo de errores aquí
                    return false;
                }
            }
        }

        
        public Producto ObtenerProductoPorCodigoProducto(string codigoProducto)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT p.IdProducto, p.IdCategoria, p.Nombre, p.Descripcion, p.Stock, p.PrecioCompra, p.PrecioVenta, p.Estado, p.FechaRegistro, c.Descripcion AS CategoriaDescripcion, p.codigoProducto " +
                                   "FROM PRODUCTO p " +
                                   "LEFT JOIN CATEGORIA c ON p.IdCategoria = c.IdCategoria " +
                                   "WHERE p.codigoProducto = @CodigoProducto";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@CodigoProducto", codigoProducto);
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Producto
                            {
                                IdProducto = Convert.ToInt32(reader["IdProducto"]),
                                oCategoria = new Categoria
                                {
                                    IdCategoria = Convert.ToInt32(reader["IdCategoria"]),
                                    Descripcion = reader["CategoriaDescripcion"].ToString()
                                },
                                Nombre = reader["Nombre"].ToString(),
                                Descripcion = reader["Descripcion"].ToString(),
                                Stock = Convert.ToInt32(reader["Stock"]),
                                PrecioCompra = Convert.ToDecimal(reader["PrecioCompra"]),
                                PrecioVenta = Convert.ToDecimal(reader["PrecioVenta"]),
                                Estado = Convert.ToBoolean(reader["Estado"]),
                                FechaRegistro = (DateTime)(reader["FechaRegistro"] as DateTime?),
                                codigoProducto = reader["codigoProducto"].ToString()
                            };
                        }
                    }

                    // Si no se encuentra el producto, puedes devolver null o manejarlo de otra forma.
                    return null;
                }
                catch (Exception ex)
                {
                    // Manejo de errores aquí
                    return null;
                }
            }
        }

        public bool ActualizarStockProducto(int productoId, int cantidad)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "UPDATE PRODUCTO SET Stock = Stock + @Cantidad WHERE IdProducto = @ProductoId";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@ProductoId", productoId);

                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    // Manejo de errores aquí
                    return false;
                }
            }
        }

        public bool ActualizarStockProductoVenta(int productoId, int cantidad)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "UPDATE PRODUCTO SET Stock = Stock - @Cantidad WHERE IdProducto = @ProductoId";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@ProductoId", productoId);

                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    // Manejo de errores aquí
                    return false;
                }
            }
        }

        public Producto ObtenerProductoPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT p.IdProducto, p.IdCategoria, p.Nombre, p.Descripcion, p.Stock, p.PrecioCompra, p.PrecioVenta, p.Estado, p.FechaRegistro, c.Descripcion AS CategoriaDescripcion, p.codigoProducto " +
                                   "FROM PRODUCTO p " +
                                   "LEFT JOIN CATEGORIA c ON p.IdCategoria = c.IdCategoria " +
                                   "WHERE p.IdProducto = @id";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Producto
                            {
                                IdProducto = Convert.ToInt32(reader["IdProducto"]),
                                oCategoria = new Categoria
                                {
                                    IdCategoria = Convert.ToInt32(reader["IdCategoria"]),
                                    Descripcion = reader["CategoriaDescripcion"].ToString()
                                },
                                Nombre = reader["Nombre"].ToString(),
                                Descripcion = reader["Descripcion"].ToString(),
                                Stock = Convert.ToInt32(reader["Stock"]),
                                PrecioCompra = Convert.ToDecimal(reader["PrecioCompra"]),
                                PrecioVenta = Convert.ToDecimal(reader["PrecioVenta"]),
                                Estado = Convert.ToBoolean(reader["Estado"]),
                                FechaRegistro = (DateTime)(reader["FechaRegistro"] as DateTime?),
                                codigoProducto = reader["codigoProducto"].ToString()
                            };
                        }
                    }

                    // Si no se encuentra el producto, puedes devolver null o manejarlo de otra forma.
                    return null;
                }
                catch (Exception ex)
                {
                    // Manejo de errores aquí
                    return null;
                }
            }
        }

    }
}
