using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Models
{
    public class Editura
    {
        [Key]
        public int Id { get; set; }
        public string logo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List <Carte> Carti{ get; set; }
    }
}
