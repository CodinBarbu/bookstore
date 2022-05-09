using bookstore.Data;
using bookstore.Data.Services;
using bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Controllers
{
    public class EdituriController : Controller
    {

        private readonly IEdituriService _service;
        public EdituriController(IEdituriService service)
        {
            _service = service;

        }
        public async Task<IActionResult> Index()
        {
            var allEdituri = await _service.GetAllAsync();
            return View(allEdituri);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("logo,Name,Description")]Editura editura)
        {
            if (!ModelState.IsValid) return View(editura);
            await _service.AddAsync(editura);
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult>Details(int id)
        {
            var edituraDetails = await _service.GetByIdAsync(id);
            if (edituraDetails == null) return View("NotFound");
            return View(edituraDetails);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var edituraDetails = await _service.GetByIdAsync(id);
            if (edituraDetails == null) return View("NotFound");
            return View(edituraDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,logo,Name,Description")] Editura editura)
        {
            if (!ModelState.IsValid) return View(editura);
            await _service.UpdateAsync(id, editura);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int id)
        {
            var edituraDetails = await _service.GetByIdAsync(id);
            if (edituraDetails == null) return View("NotFound");
            return View(edituraDetails);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var edituraDetails = await _service.GetByIdAsync(id);
            if (edituraDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }

    }
}
