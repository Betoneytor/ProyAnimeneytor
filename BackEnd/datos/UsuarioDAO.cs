using BackEnd.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using BackEnd.modelo;
using System.Diagnostics;

namespace BackEnd.datos
{
    public class UsuarioDAO
    {




        public int existeUsuario(String txtEmail, String txtContrasena)
        {
            try
            {
                MySqlCommand sentencia = new MySqlCommand(
                    "select u.id from usuarios u where u.correo =@Email and u.pass = @Contrasena");

                sentencia.CommandType = CommandType.Text;

                sentencia.Parameters.AddWithValue("@Email", txtEmail);

                sentencia.Parameters.AddWithValue("@Contrasena", txtContrasena);

                DataTable tabla = Conexion.ejecutarConsulta(sentencia);
                int id = 0;

                if (tabla != null && tabla.Rows.Count > 0)
                {
                    DataRow fila = tabla.Rows[0];
                    id = Int32.Parse(fila["id"].ToString());
                }

                return id;
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                Conexion.desconectar();
            }
        }

        public String obtenerTipoUsuario(String txtEmail)
        {
            try
            {
                MySqlCommand sentencia = new MySqlCommand(
                    "select * from usuarios where correo =@Email");

                sentencia.CommandType = CommandType.Text;

                sentencia.Parameters.AddWithValue("@Email", txtEmail);            

                DataTable tabla = Conexion.ejecutarConsulta(sentencia);
                String tipo = "";

                if (tabla != null && tabla.Rows.Count > 0)
                {
                    DataRow fila = tabla.Rows[0];
                    tipo = fila["tipo"].ToString();
                }

                return tipo;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return "no existe";
            }
            finally
            {
                Conexion.desconectar();
            }
        }

        public int registrarUsuario(String txtEmail, String txtContrasena)
        {
            try
            {
                MySqlCommand sentencia = new MySqlCommand("insert into usuarios (correo,pass,tipo) values (@Email,@Contrasena,@usuario); SELECT LAST_INSERT_ID();");

                sentencia.CommandType = CommandType.Text;

                sentencia.Parameters.AddWithValue("@Email", txtEmail);

                sentencia.Parameters.AddWithValue("@Contrasena", txtContrasena);
                
                sentencia.Parameters.AddWithValue("@usuario", "usuario");

                int idGenerado = Conexion.ejecutarSentencia(sentencia, true);

                return idGenerado;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return 0;
            }
            finally
            {
                Conexion.desconectar();
            }
        }



       /* public Usuario getEmailById(int id)
        {
            try
            {
                MySqlCommand sentencia = new MySqlCommand(
                    "select u.email,u.contrasena from usuarios u where u.idUsuario =@idUsuario");
                sentencia.CommandType = CommandType.Text;

                sentencia.Parameters.AddWithValue("@idUsuario", id);

                DataTable tabla = Conexion.ejecutarConsulta(sentencia);
                Usuario u = null;
                if (tabla != null && tabla.Rows.Count > 0)
                {
                    DataRow fila = tabla.Rows[0];
                    u = new Usuario(
                    id,
                    fila["email"].ToString(),
                    int.Parse(fila["contrasena"].ToString())
                    );
                }
                return u;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                Conexion.desconectar();
            }
        }*/

    }

}
