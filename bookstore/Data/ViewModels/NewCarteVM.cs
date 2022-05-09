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
    public class NewCarteVM
    {
        [Display(Description="Nume Carte")]
        [Required(ErrorMessage ="Introduceti numele")]
        public string Name { get; set; }
        [Display(Description = "Descriere Carte")]
        [Required(ErrorMessage = "Introduceti Descrierea")]
        public string Description { get; set; }
        [Display(Description = "Pret in LEI")]
        [Required(ErrorMessage = "Introduceti pretul:")]
        public double Price { get; set; }
        [Display(Description = "Poză Carte")]
        [Required(ErrorMessage = "Introduceti poza")]
        public string ImageURL { get; set; }
        [Display(Description = "Anul publicării")]
        [Required(ErrorMessage = "Introduceti anul")]
        public DateTime StartDate { get; set; }
        [Display(Description = "Selectează categoria")]
        [Required(ErrorMessage = "Trebuie să selectezi o categorie")]
        public BookCategory BookCategory  { get; set; }
        [Display(Description = "Selectează autorul")]
        [Required(ErrorMessage = "Introduceti Autorul Cartii")]

        public List<int> AutorIds{ get; set; }
        [Display(Description = "Selectează Editura")]
        [Required(ErrorMessage = "Selectează Editura")]
        public int EdituraId { get; set; }


    }
}
