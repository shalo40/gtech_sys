using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gtech.Models;

namespace gtech.Controllers
{
    public class TrabajadorController : Controller
    {
        private readonly GtechContext _context;

        public TrabajadorController(GtechContext context)
        {
            _context = context;
        }

        // GET: Trabajador
        public async Task<IActionResult> Index()
        {
              return _context.Trabajadores != null ? 
                          View(await _context.Trabajadores.ToListAsync()) :
                          Problem("Entity set 'GtechContext.Trabajadores'  is null.");
        }

        // GET: Trabajador/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Trabajadores == null)
            {
                return NotFound();
            }

            var trabajadore = await _context.Trabajadores
                .FirstOrDefaultAsync(m => m.TrabajadorId == id);
            if (trabajadore == null)
            {
                return NotFound();
            }

            return View(trabajadore);
        }

        // GET: Trabajador/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trabajador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrabajadorId,Nombre,Cargo,Telefono,Email,Rut,FechaIngreso")] Trabajadore trabajadore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trabajadore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trabajadore);
        }

        // GET: Trabajador/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Trabajadores == null)
            {
                return NotFound();
            }

            var trabajadore = await _context.Trabajadores.FindAsync(id);
            if (trabajadore == null)
            {
                return NotFound();
            }
            return View(trabajadore);
        }

        // POST: Trabajador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("TrabajadorId,Nombre,Cargo,Telefono,Email,Rut,FechaIngreso")] Trabajadore trabajadore)
        {
            if (id != trabajadore.TrabajadorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trabajadore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrabajadoreExists(trabajadore.TrabajadorId))
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
            return View(trabajadore);
        }

        // GET: Trabajador/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Trabajadores == null)
            {
                return NotFound();
            }

            var trabajadore = await _context.Trabajadores
                .FirstOrDefaultAsync(m => m.TrabajadorId == id);
            if (trabajadore == null)
            {
                return NotFound();
            }

            return View(trabajadore);
        }

        // POST: Trabajador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Trabajadores == null)
            {
                return Problem("Entity set 'GtechContext.Trabajadores'  is null.");
            }
            var trabajadore = await _context.Trabajadores.FindAsync(id);
            if (trabajadore != null)
            {
                _context.Trabajadores.Remove(trabajadore);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrabajadoreExists(long id)
        {
          return (_context.Trabajadores?.Any(e => e.TrabajadorId == id)).GetValueOrDefault();
        }
    }
}
