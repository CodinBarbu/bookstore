using bookstore.Data.Base;
using bookstore.Data.ViewModels;
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

        public async Task AddNewCarteAsync(NewCarteVM data)
        {
            var newCarte = new Carte()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                EdituraId = data.EdituraId,
                StartDate = data.StartDate,
                BookCategory = data.BookCategory

            };
            await _context.Carti.AddAsync(newCarte);
            await _context.SaveChangesAsync();

            foreach(var autorId in data.AutorIds)
            {
                var newAutorCarte = new Autor_Carte()
                {
                    CarteId = newCarte.Id,
                    AutorId = autorId
                };
                await _context.Autori_Carti.AddAsync(newAutorCarte);
            }
            await _context.SaveChangesAsync();
                
        }

        public async Task<Carte> GetCarteByIdAsync(int id)
        {
            var carteDetails = await _context.Carti
            .Include(c => c.Editura)
            .Include(am => am.Autori_Carti).ThenInclude(a => a.Autor)
            .FirstOrDefaultAsync(n => n.Id == id);
            return carteDetails;
        }

        public async Task<NewCarteDropdownsVM> GetNewCarteDropdownsValues()
        {
            var response = new NewCarteDropdownsVM()
            {
                Autori = await _context.Autori.OrderBy(n => n.FullName).ToListAsync(),
                Edituri = await _context.Edituri.OrderBy(n => n.Name).ToListAsync()

            };
           
            return response;

        }

        public async Task UpdateCarteAsync(NewCarteVM data)
        {
            var dbCarte = await _context.Carti.FirstOrDefaultAsync(n => n.Id == data.Id);
            if(dbCarte!=null)
            {
                dbCarte.Name = data.Name;
                dbCarte.Description = data.Description;
                dbCarte.Price = data.Price;
                dbCarte.ImageURL = data.ImageURL;
                dbCarte.EdituraId = data.EdituraId;
                dbCarte.StartDate = data.StartDate;
                dbCarte.BookCategory = data.BookCategory;
                await _context.SaveChangesAsync();

            }
            var existingAutoriDb = _context.Autori_Carti.Where(n => n.CarteId == data.Id).ToList();
            _context.Autori_Carti.RemoveRange(existingAutoriDb);
            await _context.SaveChangesAsync();

            foreach (var autorId in data.AutorIds)
            {
                var newAutorCarte = new Autor_Carte()
                {
                    CarteId = data.Id,
                    AutorId = autorId
                };
                await _context.Autori_Carti.AddAsync(newAutorCarte);
            }
            await _context.SaveChangesAsync();
        }
    }
}
