using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Numele si prenumele")]
        [Required(ErrorMessage = "Introduceti Numele si prenumele")]
        public string FullName { get; set; }

        [Display(Name ="Adresa de Email")]
        [Required(ErrorMessage="Introduceți Adresa de Email")]

        public string  EmailAdress { get; set; }
        [Display(Name = "Parola")]
        [Required(ErrorMessage = "Introduceți parola")]
        [DataType(DataType.Password)]
        public string  Password { get; set; }

        [Display(Name ="Confirmare parola")]
        [Required(ErrorMessage = "Introduceti parola")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Parolele nu se potrivesc")]
        public string ConfirmPassword { get; set; }
    }
}
