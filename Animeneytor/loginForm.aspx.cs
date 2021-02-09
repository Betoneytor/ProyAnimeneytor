using BackEnd.datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Animeneytor
{
    public partial class loginForm : System.Web.UI.Page
    {


       public static UsuarioDAO objUsuarioDao = new UsuarioDAO();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idUsuario"] != null)
            {
                Response.Redirect("inicio.aspx");
            }
        }

        [WebMethod]
        public static string GetLogin(string correo, string password)
        {
            int idUsr = objUsuarioDao.existeUsuario(correo, password);

           
            //hay usuarios
            if (idUsr != 0){
                loginForm form = new loginForm();
                form.setVarSession("idUsuario", idUsr + "");
                form.setVarSession("nombreUsuario", correo);
                
                String tipo = objUsuarioDao.obtenerTipoUsuario(correo);
                form.setVarSession("tipoUsuario", tipo);

                return "true";
            }
            //no hay usuarios
            else{
                return "false";
            }

            
        }

        [WebMethod]
        public static string postRegister(string correo, string password)
        {
            objUsuarioDao.registrarUsuario(correo, password);
            int idUsr = objUsuarioDao.existeUsuario(correo, password);            
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
        public void setVarSession(String key, String value)
        {
            Session[key] = value;
        }

        public String getVarSession(String key)
        {
            return Session[key].ToString() ;
        }
    }
 
}
