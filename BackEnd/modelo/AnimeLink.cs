using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.modelo
{
    public class AnimeLink
    {
        public int id { get; set; }
        public String nombre { get; set; }
        public String  tipo { get; set; }
        public String link { get; set; }
        public String date  { get; set; }
        public String id_anime { get; set; }
       

        public AnimeLink()
        { }

        public AnimeLink(int id, String nombre, String tipo, String link, String date, String id_anime)
        {
            this.id = id;
            this.nombre = nombre;
            this.tipo = tipo;
            this.link = link;
            this.date = date;
            this.id_anime = id_anime;            
        }
    }
}
