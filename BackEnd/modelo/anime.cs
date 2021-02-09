using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.modelo
{
    public class Anime
    {
        public int id { get; set; }
        public String nombre { get; set; }
        public String  productora { get; set; }
        public String generos { get; set; }
        public String sinopsis  { get; set; }
        public String imagen { get; set; }
        public String date { get; set; }

        public Anime()
        { }

        public Anime(int id, String nombre, String productora, String generos, String sinopsis, String imagen, String date)
        {
            this.id = id;
            this.nombre = nombre;
            this.productora = productora;
            this.generos = generos;
            this.sinopsis = sinopsis;
            this.imagen = imagen;
            this.date = date;
        }
    }
}
