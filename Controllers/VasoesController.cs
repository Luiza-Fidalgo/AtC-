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
    public class VasoesController : Controller
    {
        private readonly At_C__2023Context _context;

        public VasoesController(At_C__2023Context context)
        {
            _context = context;
        }

        // GET: Vasoes
        public async Task<IActionResult> Index()
        {
              return _context.Vaso != null ? 
                          View(await _context.Vaso.ToListAsync()) :
                          Problem("Entity set 'At_C__2023Context.Vaso'  is null.");
        }

        // GET: Vasoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vaso == null)
            {
                return NotFound();
            }

            var vaso = await _context.Vaso
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vaso == null)
            {
                return NotFound();
            }

            return View(vaso);
        }

        // GET: Vasoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vasoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipo,Tamanho,Cor")] Vaso vaso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vaso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vaso);
        }

        // GET: Vasoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vaso == null)
            {
                return NotFound();
            }

            var vaso = await _context.Vaso.FindAsync(id);
            if (vaso == null)
            {
                return NotFound();
            }
            return View(vaso);
        }

        // POST: Vasoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tipo,Tamanho,Cor")] Vaso vaso)
        {
            if (id != vaso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vaso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VasoExists(vaso.Id))
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
            return View(vaso);
        }

        // GET: Vasoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vaso == null)
            {
                return NotFound();
            }

            var vaso = await _context.Vaso
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vaso == null)
            {
                return NotFound();
            }

            return View(vaso);
        }

        // POST: Vasoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vaso == null)
            {
                return Problem("Entity set 'At_C__2023Context.Vaso'  is null.");
            }
            var vaso = await _context.Vaso.FindAsync(id);
            if (vaso != null)
            {
                _context.Vaso.Remove(vaso);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VasoExists(int id)
        {
          return (_context.Vaso?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
