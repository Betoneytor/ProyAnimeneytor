using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using BackEnd.modelo;
using BackEnd.datos;

namespace Animeneytor.WebServices
{
    /// <summary>
    /// Descripción breve de WSlistaAnimes
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class WSlistaAnimes : System.Web.Services.WebService
    {
        public static AnimeDAO animeDAO = new AnimeDAO();

        
        [WebMethod(EnableSession = true)]
        public String getAllAnime(String filtro)
        {
            if (Session["tipoUsuario"] != null) 
            {
                var jsonSerialiser = new JavaScriptSerializer();
                jsonSerialiser.MaxJsonLength = 1073741824;
                var json = jsonSerialiser.Serialize(animeDAO.getAllAnime(filtro));

                return json.ToString();
            }
            throw new SecurityException("Acceso restringido Solo a usuarios Registrados");
        }


        [WebMethod(EnableSession = true)]
        public  String eliminarAnime(String id)
        {
            if (Session["tipoUsuario"] != null && Session["tipoUsuario"].ToString().Equals("administrador"))
            {
                bool resultado = new AnimeDAO().delete(id);

                if (resultado)
                {
                    return "true";
                }
                else
                {
                    return "false";
                }
            }
            throw new SecurityException("Acceso restringido");
        }

        [WebMethod(EnableSession = true)]
        public String agregarAnime(String titulo, String desc, String imagen, String productora, String genero)
        {
            if (Session["tipoUsuario"] != null && Session["tipoUsuario"].ToString().Equals("administrador"))
            {
                int resultado = new AnimeDAO().agregarAnime(titulo, desc, imagen, productora, genero);

                if (resultado != 0)
                {
                    return "true";
                }
                else
                {
                    return "false";
                }
            }
            throw new SecurityException("Acceso restringido");
           
        }

        //"{'id':'" + id + "', 'nombre': '" + nombre + "','productora': '" + productora + "', 'genero':'" + genero + "', 'sinopsis':'" + sinopsis + "', 'imagen':'" + imagen + "'}";
        [WebMethod(EnableSession = true)]
        public String editarAnime(String id, String nombre, String productora, String genero, String sinopsis, String imagen)
        {
            if (Session["tipoUsuario"] != null && Session["tipoUsuario"].ToString().Equals("administrador"))
            {
                bool resultado = new AnimeDAO().editarAnime(id, nombre, productora, genero, sinopsis, imagen);

                if (resultado)
                {
                    return "true";
                }
                else
                {
                    return "false";
                }
            }
            throw new SecurityException("Acceso restringido");
           
        }
       
    }
}
