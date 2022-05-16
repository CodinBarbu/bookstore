using bookstore.Data;
using bookstore.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Models
{
    public class Carte:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public BookCategory BookCategory  { get; set; }
        public List<Autor_Carte> Autori_Carti{ get; set; }
        public int EdituraId { get; set; }
        [ForeignKey("EdituraId")]
        public Editura Editura { get; set; }
    }
}
