using bookstore.Data.Base;
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
    }
}
