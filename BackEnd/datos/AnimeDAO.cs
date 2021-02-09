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
    public class AnimeDAO
    {




     
        public List<Anime> getAllAnime(String filtro)
        {
            try {
                List<Anime> lista = new List<Anime>();

                String data = "select id, nombre, productora, generos, sinopsis, imagen, date from animes order by(date) asc;";
                String favoritos = "select animes.id , animes.nombre, animes.productora, animes.generos, animes.sinopsis, animes.imagen, animes.date from animes inner join favoritos on animes.id = favoritos.id_anime order by(date) asc; ";
                String visto = "select animes.id , animes.nombre, animes.productora, animes.generos, animes.sinopsis, animes.imagen, animes.date from animes inner join visto on animes.id = visto.id_anime order by(date) asc; ";
                String por_ver = "select animes.id , animes.nombre, animes.productora, animes.generos, animes.sinopsis, animes.imagen, animes.date from animes inner join por_ver on animes.id = por_ver.id_anime order by(date) asc;";

                MySqlCommand sentencia = new MySqlCommand();
                if (filtro.Equals("1"))
                {
                    sentencia.CommandText = favoritos;
                }
                else if (filtro.Equals("2"))
                {
                    sentencia.CommandText = visto;
                }
                else if (filtro.Equals("3"))
                {
                    sentencia.CommandText = por_ver;
                }
                else
                {
                    sentencia.CommandText = data;
                }

                DataTable tabla = Conexion.ejecutarConsulta(sentencia);

                foreach (DataRow fila in tabla.Rows)
                {
                    lista.Add(new Anime(
                        int.Parse(fila["id"].ToString()),
                        fila["nombre"].ToString(),
                        fila["productora"].ToString(),
                        fila["generos"].ToString(),
                        fila["sinopsis"].ToString(),
                        fila["imagen"].ToString(),
                        fila["date"].ToString()

                                         )
                              );
                }

                return lista;
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se puede establecer la conexión con el servidor");
            }
           
        }
        public string BinaryToText(byte[] data)
        {
            return Encoding.UTF8.GetString(data);
        }


        public List<Anime> getAnimeDetalle(String id)
        {
            try {

                List<Anime> lista = new List<Anime>();

                MySqlCommand sentencia = new MySqlCommand();
                sentencia.CommandText =
                    "select * from  animes where id = @id;";

                sentencia.CommandType = CommandType.Text;

                sentencia.Parameters.AddWithValue("@id", id);

                DataTable tabla = Conexion.ejecutarConsulta(sentencia);

                foreach (DataRow fila in tabla.Rows)
                {
                    lista.Add(new Anime(
                        int.Parse(fila["id"].ToString()),
                        fila["nombre"].ToString(),
                        fila["productora"].ToString(),
                        fila["generos"].ToString(),
                        fila["sinopsis"].ToString(),
                        fila["imagen"].ToString(),
                        fila["date"].ToString()

                                         )
                              );
                }

                return lista;
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se puede establecer la conexión con el servidor");
            }
            
        }


        public List<AnimeLink> getAnimeDescargas(String id, String tipo)
        {
            try {

                List<AnimeLink> lista = new List<AnimeLink>();

                MySqlCommand sentencia = new MySqlCommand();
                sentencia.CommandText =
                    "select * from  links where id_anime = @id and tipo = @tipo;";

                sentencia.CommandType = CommandType.Text;

                sentencia.Parameters.AddWithValue("@id", id);
                sentencia.Parameters.AddWithValue("@tipo", tipo);

                DataTable tabla = Conexion.ejecutarConsulta(sentencia);

                foreach (DataRow fila in tabla.Rows)
                {
                    lista.Add(new AnimeLink(
                        int.Parse(fila["id"].ToString()),
                        fila["nombre"].ToString(),
                        fila["tipo"].ToString(),
                        fila["link"].ToString(),
                        fila["date"].ToString(),
                        fila["id_anime"].ToString()
                        )
                      );
                }

                return lista;
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se puede establecer la conexión con el servidor");
            }
           
        }


        public int addFavorito(String id, String id_usuario)
        {
            try
            {
                MySqlCommand sentencia = new MySqlCommand("insert into favoritos (id_usuario,id_anime) values (@idUsuario, @idAnime); SELECT LAST_INSERT_ID();");

                sentencia.CommandType = CommandType.Text;

                sentencia.Parameters.AddWithValue("@idAnime", id);

                sentencia.Parameters.AddWithValue("@idUsuario", id_usuario);
                

                int idGenerado = Conexion.ejecutarSentencia(sentencia, true);

                return idGenerado;
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se puede establecer la conexión con el servidor");
            }
            finally
            {
                Conexion.desconectar();
            }
        }


        public int addVisto(String id, String id_usuario)
        {
            try
            {
                MySqlCommand sentencia = new MySqlCommand("insert into visto (id_usuario,id_anime) values (@idUsuario, @idAnime); SELECT LAST_INSERT_ID();");

                sentencia.CommandType = CommandType.Text;

                sentencia.Parameters.AddWithValue("@idAnime", id);

                sentencia.Parameters.AddWithValue("@idUsuario", id_usuario);


                int idGenerado = Conexion.ejecutarSentencia(sentencia, true);

                return idGenerado;
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se puede establecer la conexión con el servidor");
            }
            finally
            {
                Conexion.desconectar();
            }
        }


        public int addPorVer(String id, String id_usuario)
        {
            try
            {
                MySqlCommand sentencia = new MySqlCommand("insert into por_ver (id_usuario,id_anime) values (@idUsuario, @idAnime); SELECT LAST_INSERT_ID();");

                sentencia.CommandType = CommandType.Text;

                sentencia.Parameters.AddWithValue("@idAnime", id);

                sentencia.Parameters.AddWithValue("@idUsuario", id_usuario);


                int idGenerado = Conexion.ejecutarSentencia(sentencia, true);

                return idGenerado;
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se puede establecer la conexión con el servidor");
            }
            finally
            {
                Conexion.desconectar();
            }
        }


        public int eliminarFavorito(String id, String id_usuario)
        {
            try
            {
                MySqlCommand sentencia = new MySqlCommand("DELETE FROM favoritos WHERE id_usuario=@idUsuario and id_anime=@idAnime;");

                sentencia.CommandType = CommandType.Text;

                sentencia.Parameters.AddWithValue("@idAnime", id);

                sentencia.Parameters.AddWithValue("@idUsuario", id_usuario);


                Conexion.ejecutarSentencia(sentencia, false);

                return 1;
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se puede establecer la conexión con el servidor");
            }
            finally
            {
                Conexion.desconectar();
            }
        }


        public int eliminarVisto(String id, String id_usuario)
        {
            try
            {
                MySqlCommand sentencia = new MySqlCommand("DELETE FROM visto WHERE id_usuario=@idUsuario and id_anime=@idAnime;");

                sentencia.CommandType = CommandType.Text;

                sentencia.Parameters.AddWithValue("@idAnime", id);

                sentencia.Parameters.AddWithValue("@idUsuario", id_usuario);


                Conexion.ejecutarSentencia(sentencia, false);

                return 1;
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se puede establecer la conexión con el servidor");
            }
            finally
            {
                Conexion.desconectar();
            }
        }

        public int eliminarPorVer(String id, String id_usuario)
        {
            try
            {
                MySqlCommand sentencia = new MySqlCommand("DELETE FROM por_ver WHERE id_usuario=@idUsuario and id_anime=@idAnime;");

                sentencia.CommandType = CommandType.Text;

                sentencia.Parameters.AddWithValue("@idAnime", id);

                sentencia.Parameters.AddWithValue("@idUsuario", id_usuario);


                Conexion.ejecutarSentencia(sentencia, false);

                return 1;
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se puede establecer la conexión con el servidor");
            }
            finally
            {
                Conexion.desconectar();
            }
        }

        public int existeFavorito(String idAnime, String idUsuario)
        {
            try
            {
                MySqlCommand sentencia = new MySqlCommand(
                    "select * from favoritos where id_usuario = @idUsuario and id_anime = @idAnime; SELECT LAST_INSERT_ID();");

                sentencia.CommandType = CommandType.Text;

                sentencia.Parameters.AddWithValue("@idUsuario", idUsuario);

                sentencia.Parameters.AddWithValue("@idAnime", idAnime);

                DataTable tabla = Conexion.ejecutarConsulta(sentencia);
                int id = 0;

                if (tabla != null && tabla.Rows.Count > 0)
                {
                    DataRow fila = tabla.Rows[0];
                    id = Int32.Parse(fila["id"].ToString());
                }

                return id;
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se puede establecer la conexión con el servidor");
            }
            finally
            {
                Conexion.desconectar();
            }
        }

        public int existeVisto(String idAnime, String idUsuario)
        {
            try
            {
                MySqlCommand sentencia = new MySqlCommand(
                    "select * from visto where id_usuario = @idUsuario and id_anime = @idAnime; SELECT LAST_INSERT_ID();");

                sentencia.CommandType = CommandType.Text;

                sentencia.Parameters.AddWithValue("@idUsuario", idUsuario);

                sentencia.Parameters.AddWithValue("@idAnime", idAnime);

                DataTable tabla = Conexion.ejecutarConsulta(sentencia);
                int id = 0;

                if (tabla != null && tabla.Rows.Count > 0)
                {
                    DataRow fila = tabla.Rows[0];
                    id = Int32.Parse(fila["id"].ToString());
                }

                return id;
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se puede establecer la conexión con el servidor");
            }
            finally
            {
                Conexion.desconectar();
            }
        }

        public int existePorVer(String idAnime, String idUsuario)
        {
            try
            {
                MySqlCommand sentencia = new MySqlCommand(
                    "select * from por_ver where id_usuario = @idUsuario and id_anime = @idAnime; SELECT LAST_INSERT_ID();");

                sentencia.CommandType = CommandType.Text;

                sentencia.Parameters.AddWithValue("@idUsuario", idUsuario);

                sentencia.Parameters.AddWithValue("@idAnime", idAnime);

                DataTable tabla = Conexion.ejecutarConsulta(sentencia);
                int id = 0;

                if (tabla != null && tabla.Rows.Count > 0)
                {
                    DataRow fila = tabla.Rows[0];
                    id = Int32.Parse(fila["id"].ToString());
                }

                return id;
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se puede establecer la conexión con el servidor");
            }
            finally
            {
                Conexion.desconectar();
            }
        }

        public bool delete(String id)
        {
            try
            {
                MySqlCommand sentencia = new MySqlCommand();
                sentencia.CommandText = "DELETE FROM animes WHERE id=@Id";

                sentencia.Parameters.AddWithValue("@Id", id);

                if (Conexion.ejecutarSentencia(sentencia, false) > 0)
                    return true;
                else
                    return false;

            }
            catch (MySqlException ex)
            {
                throw new Exception("No se puede establecer la conexión con el servidor");
            }
        }

        public bool deleteLink(String id)
        {
            try
            {
                MySqlCommand sentencia = new MySqlCommand();
                sentencia.CommandText = "DELETE FROM links WHERE id=@Id";

                sentencia.Parameters.AddWithValue("@Id", id);

                if (Conexion.ejecutarSentencia(sentencia, false) > 0)
                    return true;
                else
                    return false;

            }
            catch (MySqlException ex)
            {
                throw new Exception("No se puede establecer la conexión con el servidor");
            }
        }

        public int agregarAnime(String titulo, String desc, String image, String productora, String genero)
        {
            try
            {
                MySqlCommand sentencia = new MySqlCommand();
                sentencia.CommandText = "insert into animes (nombre, sinopsis, imagen, productora, generos)  values(@titulo, @desc, @imagen, @product, @genero); SELECT LAST_INSERT_ID();";

                sentencia.Parameters.AddWithValue("@titulo", titulo);
                sentencia.Parameters.AddWithValue("@desc", desc);
                sentencia.Parameters.AddWithValue("@imagen", image);
                sentencia.Parameters.AddWithValue("@product", productora);
                sentencia.Parameters.AddWithValue("@genero", genero);


                int idGenerado = Conexion.ejecutarSentencia(sentencia, true);

                return idGenerado;

            }
            catch (MySqlException ex)
            {
                throw new Exception("No se puede establecer la conexión con el servidor");
            }
        }
        public bool editarAnime(String id, String nombre, String productora, String genero, String sinopsis, String imagen)
        {
            try
            {
                MySqlCommand sentencia = new MySqlCommand();
                sentencia.CommandText = "UPDATE animes SET nombre=@nombre, productora=@productora, generos=@genero, sinopsis=@sinopsis, imagen=@imagen WHERE id=@Id";

                sentencia.Parameters.AddWithValue("@nombre", nombre);
                sentencia.Parameters.AddWithValue("@productora", productora);
                sentencia.Parameters.AddWithValue("@genero", genero);
                sentencia.Parameters.AddWithValue("@sinopsis", sinopsis);
                sentencia.Parameters.AddWithValue("@imagen", imagen);
                sentencia.Parameters.AddWithValue("@Id", id);

                if (Conexion.ejecutarSentencia(sentencia, false) > 0)
                    return true;
                else
                    return false;
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se puede establecer la conexión con el servidor");
            }
        }

        public int addLink(String id, String nombre, String link, String tipo)
        {
            try
            {
                MySqlCommand sentencia = new MySqlCommand("insert into links (nombre,tipo,link,id_anime) values (@nombre, @tipo, @link, @id_anime); SELECT LAST_INSERT_ID();");

                sentencia.CommandType = CommandType.Text;

                sentencia.Parameters.AddWithValue("@nombre", nombre);
                sentencia.Parameters.AddWithValue("@tipo", tipo);
                sentencia.Parameters.AddWithValue("@link", link);
                sentencia.Parameters.AddWithValue("@id_anime", id);                


                int idGenerado = Conexion.ejecutarSentencia(sentencia, true);

                return idGenerado;
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se puede establecer la conexión con el servidor");
            }
            finally
            {
                Conexion.desconectar();
            }
        }

        public bool editarLink(String id, String nombre, String link)
        {

            try
            {
                MySqlCommand sentencia = new MySqlCommand();
                sentencia.CommandText = "UPDATE links SET nombre=@nombre, link=@link WHERE id=@id_anime";

                sentencia.Parameters.AddWithValue("@nombre", nombre);                
                sentencia.Parameters.AddWithValue("@link", link);
                sentencia.Parameters.AddWithValue("@id_anime", id);


                if (Conexion.ejecutarSentencia(sentencia, false) > 0)
                    return true;
                else
                    return false;
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se puede establecer la conexión con el servidor");
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
