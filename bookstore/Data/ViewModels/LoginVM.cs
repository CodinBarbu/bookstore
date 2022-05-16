using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name ="Adresa de Email")]
        [Required(ErrorMessage="Introduceți Adresa de Email")]
        public string  EmailAdress { get; set; }
        [Display(Name = "Parola")]
        [Required(ErrorMessage = "Introduceți parola")]
        [DataType(DataType.Password)]
        public string  Password { get; set; }
    }
}
