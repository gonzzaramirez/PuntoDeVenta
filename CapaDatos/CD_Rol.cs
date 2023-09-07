using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Rol
    {
        public List<Rol> Listar()
        {
            List<Rol> lista = new List<Rol>();

            using (SqlConnection con = new SqlConnection(Conexion.cadena))
            {


                try
                {

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select IdRol, Descripcion from ROL");
                    


                    SqlCommand cmd = new SqlCommand(query.ToString(), con);
                    
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Rol()
                            {
                                IdRol = Convert.ToInt32(reader["IdRol"]),
                               
                                Descripcion = reader["Descripcion"].ToString(),

                            });;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de errores aquí
                    lista = new List<Rol>();
                }
            }
            return lista;
        }
    }
}

