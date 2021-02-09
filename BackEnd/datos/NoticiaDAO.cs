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
    public class NoticiaDAO
    {




     
        public List<Noticia> getAllNoticias()
        {
            List<Noticia> lista = new List<Noticia>();

            MySqlCommand sentencia = new MySqlCommand();
            sentencia.CommandText =
                "select id, titulo, descripcion, imagen, date from noticia order by(date) asc;";
            
            DataTable tabla = Conexion.ejecutarConsulta(sentencia);

            foreach (DataRow fila in tabla.Rows)
            {
                lista.Add(new Noticia(
                    int.Parse(fila["id"].ToString()),                     
                    fila["titulo"].ToString(),
                    fila["descripcion"].ToString(),
                    fila["imagen"].ToString(),
                    fila["date"].ToString())
                          );
            }

            return lista;
        }
        public string BinaryToText(byte[] data)
        {
            return Encoding.UTF8.GetString(data);
        }

        public bool editarNoticia(string id, string titulo, string desc, string imagen)
        {
            try
            {
                MySqlCommand sentencia = new MySqlCommand();
                sentencia.CommandText = "UPDATE noticia SET titulo=@titulo, descripcion=@desc, imagen=@imagen WHERE id=@Id";

                sentencia.Parameters.AddWithValue("@titulo", titulo);
                sentencia.Parameters.AddWithValue("@desc", desc);
                sentencia.Parameters.AddWithValue("@imagen", imagen);
                sentencia.Parameters.AddWithValue("@Id", id);

                if (Conexion.ejecutarSentencia(sentencia, false) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return false;
            }
        }

        public int agregarNoticia(String titulo, String desc, String image)
        {
            try
            {
                MySqlCommand sentencia = new MySqlCommand();
                sentencia.CommandText = "insert into noticia (titulo, descripcion, imagen)  values(@titulo, @desc, @imagen); SELECT LAST_INSERT_ID();";

                sentencia.Parameters.AddWithValue("@titulo", titulo);
                sentencia.Parameters.AddWithValue("@desc", desc);
                sentencia.Parameters.AddWithValue("@imagen", image);


                int idGenerado = Conexion.ejecutarSentencia(sentencia, true);

                return idGenerado;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public bool delete(String id)
        {
            try
            {
                MySqlCommand sentencia = new MySqlCommand();
                sentencia.CommandText = "DELETE FROM noticia WHERE id=@Id";

                sentencia.Parameters.AddWithValue("@Id", id);

                if (Conexion.ejecutarSentencia(sentencia, false) > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception)
            {
                return false;
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
