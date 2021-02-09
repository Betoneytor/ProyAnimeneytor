using BackEnd.datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Animeneytor
{
    public partial class detalleAnime : System.Web.UI.Page
    {
        public static AnimeDAO animeDAO = new AnimeDAO();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static String getAnimeDetalle(String id)
        {
            var jsonSerialiser = new JavaScriptSerializer
            {
                MaxJsonLength = 1073741824
            };
            var json = jsonSerialiser.Serialize(animeDAO.getAnimeDetalle(id));

            return json.ToString();
        }

        [WebMethod]
        public static String getAnimeDescargas(String id, String tipo)
        {
            var jsonSerialiser = new JavaScriptSerializer
            {
                MaxJsonLength = 1073741824
            };
            var json = jsonSerialiser.Serialize(animeDAO.getAnimeDescargas(id, tipo));

            return json.ToString();
        }

        [WebMethod]
        public static String addFavorito(String id)
        {
            
            detalleAnime form = new detalleAnime();
            String id_usuario = form.getVarSession("idUsuario");

            var idFav = animeDAO.existeFavorito(id,id_usuario);

            if (idFav != 0)
            {
                animeDAO.eliminarFavorito(id, id_usuario);
                var idFav2 = animeDAO.existeFavorito(id, id_usuario);
                if (idFav2 == 0)
                {
                    return "eliminado";
                }
                else {
                    return "no eliminado";
                }

            }
            else {
                int idUsr = animeDAO.addFavorito(id, id_usuario);
                //hay usuarios
                if (idUsr != 0)
                {
                    return "true";
                }
                //no hay usuarios
                else
                {
                    return "false";
                }
            }            
           

        }


        [WebMethod]
        public static String addVisto(String id)
        {

            detalleAnime form = new detalleAnime();
            String id_usuario = form.getVarSession("idUsuario");

            var idFav = animeDAO.existeVisto(id, id_usuario);
           

            if (idFav != 0)
            {
                animeDAO.eliminarVisto(id, id_usuario);
                var idFav2 = animeDAO.existeVisto(id, id_usuario);
                if (idFav2 == 0)
                {
                    return "eliminado";
                }
                else
                {
                    return "no eliminado";
                }

            }
            else
            {
                int idUsr = animeDAO.addVisto(id, id_usuario);
                //hay usuarios
                if (idUsr != 0)
                {
                    return "true";
                }
                //no hay usuarios
                else
                {
                    return "false";
                }
            }


        }


        [WebMethod]
        public static String addPorVer(String id)
        {

            detalleAnime form = new detalleAnime();
            String id_usuario = form.getVarSession("idUsuario");

            var idFav = animeDAO.existePorVer(id, id_usuario);

            if (idFav != 0)
            {
                animeDAO.eliminarPorVer(id, id_usuario);
                var idFav2 = animeDAO.existePorVer(id, id_usuario);
                if (idFav2 == 0)
                {
                    return "eliminado";
                }
                else
                {
                    return "no eliminado";
                }

            }
            else
            {
                int idUsr = animeDAO.addPorVer(id, id_usuario);
                //hay usuarios
                if (idUsr != 0)
                {
                    return "true";
                }
                //no hay usuarios
                else
                {
                    return "false";
                }
            }


        }


        [WebMethod]
        public static String existeFavorito(String id)
        {

            detalleAnime form = new detalleAnime();
            String id_usuario = form.getVarSession("idUsuario");

            var idFav = animeDAO.existeFavorito(id, id_usuario);

            if (idFav != 0)
            {
                return "true";
            }
            else {
                return "false";
            }


        }

        [WebMethod]
        public static String existeVisto(String id)
        {

            detalleAnime form = new detalleAnime();
            String id_usuario = form.getVarSession("idUsuario");

            var idFav = animeDAO.existeVisto(id, id_usuario);

            if (idFav != 0)
            {
                return "true";
            }
            else
            {
                return "false";
            }


        }


        [WebMethod]
        public static String existePorVer(String id)
        {

            detalleAnime form = new detalleAnime();
            String id_usuario = form.getVarSession("idUsuario");

            var idFav = animeDAO.existePorVer(id, id_usuario);

            if (idFav != 0)
            {
                return "true";
            }
            else
            {
                return "false";
            }


        }

        [WebMethod]
        public static String agregarLink(String id, String nombre, String link, String tipo)
        {

            detalleAnime form = new detalleAnime();
                int idUsr = animeDAO.addLink(id, nombre, link, tipo);
                //hay usuarios
                if (idUsr != 0)
                {
                    return "true";
                }
                //no hay usuarios
                else
                {
                    return "false";
                }

        }


        [WebMethod]
        public static String editarLink(String id, String nombre, String link)
        {

            detalleAnime form = new detalleAnime();
            bool idUsr = animeDAO.editarLink(id, nombre, link);
            //hay usuarios
            if (idUsr )
            {
                return "true";
            }
            //no hay usuarios
            else
            {
                return "false";
            }

        }

        [WebMethod]
        public static String eliminarLink(String id)
        {
            bool resultado = new AnimeDAO().deleteLink(id);

            if (resultado)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }


        public String getVarSession(String key)
        {
            return Session[key].ToString();
        }
    }
}