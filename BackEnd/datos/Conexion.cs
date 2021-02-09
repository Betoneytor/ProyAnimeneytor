using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace BackEnd.datos
{
    /// <summary>
    /// Manejar la comunicación con la BD a través del driver
    /// </summary>
    public class Conexion
    {
        static MySqlConnection conexion;

        public static bool conectar()
        {
            try
            {

                if (conexion == null || conexion.State != ConnectionState.Open)
                {
                    conexion = new MySqlConnection();

                    conexion.ConnectionString = "Server=127.0.0.1;" +
                    "Database=animeneytor;" +
                    "uid=root;" +
                    "pwd=root;";// sslmode=none";

                    //conexion.ConnectionString = "Server=mysql5005.site4now.net;" +
                    //"Database=db_a637ad_animene;" +
                    //"uid=a637ad_animene;" +
                    //"pwd=Irondemon333*;";// sslmode=none";

                    conexion.Open();
                }
                return true;
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se puede establecer la conexión con el servidor");
            }
        }

        public static DataTable ejecutarConsulta(MySqlCommand consulta)
        {
            try
            {
                if (conectar())
                {
                    consulta.Connection = conexion;
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    return tabla;
                }
                return null;
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se puede establecer la conexión con el servidor");
            }
        }

        public static int ejecutarSentencia(MySqlCommand sentencia, bool esInsertar)
        {
            try
            {
                int valor = 0;
                if (conectar())
                {
                    sentencia.Connection = conexion;
                    if (esInsertar)
                        valor = int.Parse(sentencia.ExecuteScalar().ToString());
                    else
                        valor = sentencia.ExecuteNonQuery();
                }
                return valor;
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se puede establecer la conexión con el servidor");
            }
           
        }

        public static void desconectar()
        {
            if (conexion != null && conexion.State == ConnectionState.Open)
                conexion.Close();
        }
    }
}
