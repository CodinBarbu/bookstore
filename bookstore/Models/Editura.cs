using bookstore.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Models
{
    public class Editura:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Logo Editura")]
        [Required(ErrorMessage = "Field required")]
        public string logo { get; set; }
        [Display(Name = "Nume Editura")]
        [Required(ErrorMessage = "Field required")]
        public string Name { get; set; }
        [Display(Name = "Descriere Editura")]
        [Required(ErrorMessage = "Field required")]
        public string Description { get; set; }
        public List <Carte> Carti{ get; set; }
    }
}
