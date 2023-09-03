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
                    string query = "SELECT IdUsuario, DNI, Nombre, Apellido, Email, Clave, Estado FROM usuario";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
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
                                Estado = Convert.ToBoolean(reader["Estado"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de errores aquí
                    lista = new List<Usuario>();
                }
            }
            return lista;
        }
    }

}
