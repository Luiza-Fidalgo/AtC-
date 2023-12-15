using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using At_C__2023.Data;
using At_C__2023.Models;

namespace At_C__2023.Controllers
{
    public class FlorsController : Controller
    {
        private readonly At_C__2023Context _context;

        public FlorsController(At_C__2023Context context)
        {
            _context = context;
        }

        // GET: Flors
        public async Task<IActionResult> Index()
        {
              return _context.Flor != null ? 
                          View(await _context.Flor.ToListAsync()) :
                          Problem("Entity set 'At_C__2023Context.Flor'  is null.");
        }

        // GET: Flors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Flor == null)
            {
                return NotFound();
            }

            var flor = await _context.Flor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flor == null)
            {
                return NotFound();
            }

            return View(flor);
        }

        // GET: Flors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Flors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Especie,Quantidade")] Flor flor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flor);
        }

        // GET: Flors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Flor == null)
            {
                return NotFound();
            }

            var flor = await _context.Flor.FindAsync(id);
            if (flor == null)
            {
                return NotFound();
            }
            return View(flor);
        }

        // POST: Flors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Especie,Quantidade")] Flor flor)
        {
            if (id != flor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlorExists(flor.Id))
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
            return View(flor);
        }

        // GET: Flors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Flor == null)
            {
                return NotFound();
            }

            var flor = await _context.Flor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flor == null)
            {
                return NotFound();
            }

            return View(flor);
        }

        // POST: Flors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Flor == null)
            {
                return Problem("Entity set 'At_C__2023Context.Flor'  is null.");
            }
            var flor = await _context.Flor.FindAsync(id);
            if (flor != null)
            {
                _context.Flor.Remove(flor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlorExists(int id)
        {
          return (_context.Flor?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
