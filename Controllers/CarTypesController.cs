using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class CarTypesController : Controller
    {
        private readonly MvcMovieContext _context;

        public CarTypesController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: CarTypes
        public async Task<IActionResult> Index()
        {
              return _context.CarTypes != null ? 
                          View(await _context.CarTypes.ToListAsync()) :
                          Problem("Entity set 'MvcMovieContext.CarTypes'  is null.");
        }

        // GET: CarTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CarTypes == null)
            {
                return NotFound();
            }

            var carType = await _context.CarTypes
                .FirstOrDefaultAsync(m => m.id == id);
            if (carType == null)
            {
                return NotFound();
            }

            return View(carType);
        }

        // GET: CarTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name")] CarType carType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carType);
        }

        // GET: CarTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CarTypes == null)
            {
                return NotFound();
            }

            var carType = await _context.CarTypes.FindAsync(id);
            if (carType == null)
            {
                return NotFound();
            }
            return View(carType);
        }

        // POST: CarTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Name")] CarType carType)
        {
            if (id != carType.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarTypeExists(carType.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(carType);
        }

        // GET: CarTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CarTypes == null)
            {
                return NotFound();
            }

            var carType = await _context.CarTypes
                .FirstOrDefaultAsync(m => m.id == id);
            if (carType == null)
            {
                return NotFound();
            }

            return View(carType);
        }

        // POST: CarTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CarTypes == null)
            {
                return Problem("Entity set 'MvcMovieContext.CarTypes'  is null.");
            }
            var carType = await _context.CarTypes.FindAsync(id);
            if (carType != null)
            {
                _context.CarTypes.Remove(carType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarTypeExists(int id)
        {
          return (_context.CarTypes?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
