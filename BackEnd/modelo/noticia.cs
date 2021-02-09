using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.modelo
{
    public class Noticia
    {
        public int id { get; set; }
        public String titulo { get; set; }
        public String descripcion { get; set; }
        public String imagen { get; set; }
        public String date { get; set; }


        public Noticia()
        { }

        public Noticia(int id, String titulo, String descripcion, String imagen, String date)
        {
            this.id = id;
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.imagen = imagen;
            this.date = date;
        }
    }
}
