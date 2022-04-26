using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Models
{
    public class Autor_Carte
    {
        public int CarteId { get; set; }
        public Carte Carte { get; set; }
        public int AutorId { get; set; }
        public Autor Autor { get; set; }
    }
}
