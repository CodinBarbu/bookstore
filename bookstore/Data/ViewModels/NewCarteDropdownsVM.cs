using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Data.ViewModels
{
    public class NewCarteDropdownsVM
    {
        public NewCarteDropdownsVM()
        {
            Edituri = new List<Editura>();
            Autori = new List<Autor>();

        }
        public List <Editura> Edituri { get; set; }
        public List<Autor> Autori { get; set; }


    }
}
