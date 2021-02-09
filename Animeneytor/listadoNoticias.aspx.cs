using BackEnd.datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;




namespace Animeneytor
{
    public partial class listadoNoticias : System.Web.UI.Page
    {

        public static NoticiaDAO noticiaDAO = new NoticiaDAO();


        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [WebMethod]
        public static String getNoticias(string correo, string password)
        {
            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(noticiaDAO.getAllNoticias());            

            return json.ToString();
        }

        [WebMethod]
        public static String eliminarNoticia(String id)
        {
            bool resultado = new NoticiaDAO().delete(id);

            if (resultado)
            {
                return "true";
            }
            else {
                return "false";
            }            
        }

        [WebMethod]
        public static String editarNoticia(String id,String titulo, String desc, String imagen)
        {
            bool resultado = new NoticiaDAO().editarNoticia(id, titulo, desc, imagen);

            if (resultado)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }

        [WebMethod]
        public static String agregarNoticia( String titulo, String desc, String imagen)
        {
            int resultado = new NoticiaDAO().agregarNoticia(titulo, desc, imagen);

            if (resultado!=0)
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