using bookstore.Data.Base;
using bookstore.Data.ViewModels;
using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Data.Services
{
    public interface ICartiService:IEntityBaseRepository<Carte>
    {
        Task<Carte> GetCarteByIdAsync(int id);
        Task<NewCarteDropdownsVM> GetNewCarteDropdownsValues();
        Task AddNewCarteAsync (NewCarteVM data);
        Task UpdateCarteAsync(NewCarteVM data);

    }
}
