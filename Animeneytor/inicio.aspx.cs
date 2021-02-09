using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Animeneytor
{
    public partial class inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idUsuario"] == null)
            {

                Response.Redirect("loginForm.aspx");
            }
        }

        [WebMethod]
        public static String cerrarSession()
        {
            inicio form = new inicio();
            form.clearSession();
            return "ok";
        }

        public void clearSession()
        {            
            Session["idUsuario"] = null;
            Session["nombreUsuario"] = null;
        }
    }
}