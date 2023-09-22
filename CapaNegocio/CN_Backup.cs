using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;


namespace CapaNegocio
{
    public class CN_Backup
    {
        public static bool RealizarBackup(string nombreBaseDeDatos, string rutaCarpeta)
        {
            try
            {
                string connectionString = Conexion.cadena;
                string backupFileName = rutaCarpeta + "\\Backup_" + nombreBaseDeDatos + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".bak";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = $"BACKUP DATABASE [{nombreBaseDeDatos}] TO DISK = '{backupFileName}'";
                        cmd.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool RestaurarBaseDeDatos(string nombreBaseDeDatos, string rutaArchivoRespaldo)
        {
            try
            {
                string connectionString = Conexion.cadena;

                // Intentar cerrar todas las conexiones activas a la base de datos
                if (CerrarConexionesActivas(nombreBaseDeDatos, connectionString))
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Connection = connection;
                            cmd.CommandText = $"USE master; RESTORE DATABASE [{nombreBaseDeDatos}] FROM DISK = '{rutaArchivoRespaldo}'";
                            cmd.ExecuteNonQuery();
                        }
                    }

                    return true;
                }
                else
                {
                    
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static bool CerrarConexionesActivas(string nombreBaseDeDatos, string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = $@"
                    USE master;
                    DECLARE @killCommand NVARCHAR(MAX) = '';
                    SELECT @killCommand += 'KILL ' + CAST(session_id AS NVARCHAR(10)) + ';'
                    FROM sys.dm_exec_sessions
                    WHERE database_id = DB_ID('{nombreBaseDeDatos}')
                    EXEC (@killCommand);
                ";
                        cmd.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false; // No se pudieron cerrar todas las conexiones activas
            }
        }


    }
}
   

