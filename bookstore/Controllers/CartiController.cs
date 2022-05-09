using bookstore.Data;
using bookstore.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Controllers
{
    public class CartiController : Controller
    {
        private readonly ICartiService _service;
        public CartiController(ICartiService service)
        {
            _service = service;

        }
        public async Task<IActionResult> Index()
        {
            var allCarti = await _service.GetAllAsync(n=>n.Editura);
            return View(allCarti);
        }
        public async Task<IActionResult> Details(int id)
        {
            var carteDetail = await _service.GetCarteByIdAsync(id);
            return View(carteDetail);
        }
        public IActionResult Create()
        {
            ViewData["Welcome"] = "Bine ati venit la magazinul nostru";
            ViewBag.Description = "Aceasta este descrierea magazinului";
            return View();
        }
    }
}
