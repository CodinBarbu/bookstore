using bookstore.Data;
using bookstore.Data.Services;
using bookstore.Data.Static;
using bookstore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class CartiController : Controller
    {
        private readonly ICartiService _service;
        public CartiController(ICartiService service)
        {
            _service = service;

        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allCarti = await _service.GetAllAsync(n=>n.Editura);
            return View(allCarti);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allCarti = await _service.GetAllAsync(n => n.Editura);

            if(!string.IsNullOrEmpty(searchString))
            {
                var filteredReasult = allCarti.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();
                return View("Index", filteredReasult);
            }

            return View("Index",allCarti);
        }
        [AllowAnonymous]
        public async Task<IActionResult> BookDetails(int id)
        {
            var carteDetail = await _service.GetCarteByIdAsync(id);
            return View("BookDetails", carteDetail);
        }
        public async Task<IActionResult> Create()
        {
            var carteDropdownsData = await _service.GetNewCarteDropdownsValues();
            ViewBag.Edituri = new SelectList(carteDropdownsData.Edituri, "Id", "Name");
            ViewBag.Autori = new SelectList(carteDropdownsData.Autori, "Id", "FullName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewCarteVM carte)
        {
            if(!ModelState.IsValid)
            {
                var carteDropdownsData = await _service.GetNewCarteDropdownsValues();
                ViewBag.Edituri = new SelectList(carteDropdownsData.Edituri, "Id", "Name");
                ViewBag.Autori = new SelectList(carteDropdownsData.Autori, "Id", "FullName");
                return View(carte);
            }
            await _service.AddNewCarteAsync(carte);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var carteDetails = await _service.GetCarteByIdAsync(id);
            if (carteDetails == null) return View("NotFound");

            var response = new NewCarteVM()
            {
                Id = carteDetails.Id,
                Name = carteDetails.Name,
                Description = carteDetails.Description,
                Price = carteDetails.Price,
                StartDate=carteDetails.StartDate,
                ImageURL = carteDetails.ImageURL,
                BookCategory = carteDetails.BookCategory,
                EdituraId = carteDetails.EdituraId,
                AutorIds = carteDetails.Autori_Carti.Select(n => n.AutorId).ToList(),

            };

            var carteDropdownsData = await _service.GetNewCarteDropdownsValues();
            ViewBag.Edituri = new SelectList(carteDropdownsData.Edituri, "Id", "Name");
            ViewBag.Autori = new SelectList(carteDropdownsData.Autori, "Id", "FullName");
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewCarteVM carte)
        {
            if (id != carte.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var carteDropdownsData = await _service.GetNewCarteDropdownsValues();
                ViewBag.Edituri = new SelectList(carteDropdownsData.Edituri, "Id", "Name");
                ViewBag.Autori = new SelectList(carteDropdownsData.Autori, "Id", "FullName");
                return View(carte);
            }
            await _service.UpdateCarteAsync(carte);
            return RedirectToAction(nameof(Index));
        }
    }
}
