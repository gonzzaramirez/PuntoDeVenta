using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;



namespace CapaDatos
{
    public class CD_Usuario
    {
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();

            using (SqlConnection con = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    con.Open(); // Abre la conexión aquí

                    string query = @"
                        SELECT u.IdUsuario, u.DNI, u.Nombre, u.Apellido, u.Email, u.Clave, u.Direccion, 
                               ISNULL(u.FechaNacimiento, '') AS FechaNacimiento, u.Telefono, u.Estado, 
                               r.IdRol, r.Descripcion 
                        FROM usuario u
                        INNER JOIN rol r ON r.IdRol = u.IdRol";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new Usuario()
                                {
                                    IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                                    DNI = reader["DNI"].ToString(),
                                    Nombre = reader["Nombre"].ToString(),
                                    Apellido = reader["Apellido"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    Clave = reader["Clave"].ToString(),
                                    Direccion = reader["Direccion"].ToString(),
                                    FechaNacimiento = (DateTime)(reader["FechaNacimiento"] as DateTime?),
                                    Telefono = reader["Telefono"].ToString(),
                                    Estado = Convert.ToBoolean(reader["Estado"]),
                                    oRol = new Rol()
                                    {
                                        IdRol = Convert.ToInt32(reader["IdRol"]),
                                        Descripcion = reader["Descripcion"].ToString()
                                    }
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Aquí puedes manejar la excepción, registrarla o lanzarla nuevamente
                    throw ex;
                }
            }

            return lista;
        }
    }
}


