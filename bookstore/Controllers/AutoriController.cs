using bookstore.Data;
using bookstore.Data.Services;
using bookstore.Data.Static;
using bookstore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class AutoriController : Controller
    {
          private readonly IAutoriService _service;
        public AutoriController(IAutoriService service)
        {
            _service = service;

        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Autor autor)
        {
            if (!ModelState.IsValid)
            {
                return View(autor);
            }
            await _service.AddAsync(autor);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]


        public async Task<IActionResult> Details(int id)
        {
            var autorDetails = await _service.GetByIdAsync(id);
            if (autorDetails == null) return View("NotFound");
            return View(autorDetails);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var autorDetails = await _service.GetByIdAsync(id);
            if (autorDetails == null) return View("NotFound");
            return View(autorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Autor autor)
        {
            if (!ModelState.IsValid)
            {
                return View(autor);
            }
            await _service.UpdateAsync(id,autor);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var autorDetails = await _service.GetByIdAsync(id);
            if (autorDetails == null) return View("NotFound");
            return View(autorDetails);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autorDetails = await _service.GetByIdAsync(id);
            if (autorDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
