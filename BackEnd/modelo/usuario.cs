using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.modelo
{
    public class Usuario
    {
        public int id { get; set; }
        public String correo { get; set; }
        public String password { get; set; }
        public String tipo { get; set; }


        public Usuario()
        { }

        public Usuario(int idUsuario, String email, String pass, String type)
        {
            id = idUsuario;
            correo = email;
            password = pass;
            tipo = type;
        }
    }
}
