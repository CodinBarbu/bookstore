using bookstore.Data.Base;
using bookstore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Data.Services
{
    public class CartiService:EntityBaseRepository<Carte>, ICartiService
    {
        private readonly AppDbContext _context;
        public CartiService(AppDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<Carte> GetCarteByIdAsync(int id)
        {
            var carteDetails = await _context.Carti
            .Include(c => c.Editura)
            .Include(am => am.Autori_Carti).ThenInclude(a => a.Autor)
            .FirstOrDefaultAsync(n => n.Id == id);
            return carteDetails;
        }
    }
}
