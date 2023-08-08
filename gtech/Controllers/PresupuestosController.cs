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
    public class PresupuestosController : Controller
    {
        private readonly GtechContext _context;

        public PresupuestosController(GtechContext context)
        {
            _context = context;
        }

        // GET: Presupuestos
        public async Task<IActionResult> Index()
        {
            var gtechContext = _context.PresupuestosTrabajos.Include(p => p.Cliente);
            return View(await gtechContext.ToListAsync());
        }

        // GET: Presupuestos/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.PresupuestosTrabajos == null)
            {
                return NotFound();
            }

            var presupuestosTrabajo = await _context.PresupuestosTrabajos
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(m => m.PresupuestoId == id);
            if (presupuestosTrabajo == null)
            {
                return NotFound();
            }

            return View(presupuestosTrabajo);
        }

        // GET: Presupuestos/Create
        public IActionResult Create()
        {
            ViewData["Cliente"] = new SelectList(_context.Clientes, "ClienteId", "Nombre");
            return View();
        }

        // POST: Presupuestos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PresupuestoId,ClienteId,FechaEmision,Descripcion,TotalPresupuesto")] PresupuestosTrabajo presupuestosTrabajo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(presupuestosTrabajo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cliente"] = new SelectList(_context.Clientes, "ClienteId", "Nombre", presupuestosTrabajo.Cliente);
            return View(presupuestosTrabajo);
        }

        // GET: Presupuestos/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.PresupuestosTrabajos == null)
            {
                return NotFound();
            }

            var presupuestosTrabajo = await _context.PresupuestosTrabajos.FindAsync(id);
            if (presupuestosTrabajo == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", presupuestosTrabajo.ClienteId);
            return View(presupuestosTrabajo);
        }

        // POST: Presupuestos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("PresupuestoId,ClienteId,FechaEmision,Descripcion,TotalPresupuesto")] PresupuestosTrabajo presupuestosTrabajo)
        {
            if (id != presupuestosTrabajo.PresupuestoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(presupuestosTrabajo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PresupuestosTrabajoExists(presupuestosTrabajo.PresupuestoId))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nombre", presupuestosTrabajo.Cliente);
            return View(presupuestosTrabajo);
        }

        // GET: Presupuestos/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.PresupuestosTrabajos == null)
            {
                return NotFound();
            }

            var presupuestosTrabajo = await _context.PresupuestosTrabajos
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(m => m.PresupuestoId == id);
            if (presupuestosTrabajo == null)
            {
                return NotFound();
            }

            return View(presupuestosTrabajo);
        }

        // POST: Presupuestos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.PresupuestosTrabajos == null)
            {
                return Problem("Entity set 'GtechContext.PresupuestosTrabajos'  is null.");
            }
            var presupuestosTrabajo = await _context.PresupuestosTrabajos.FindAsync(id);
            if (presupuestosTrabajo != null)
            {
                _context.PresupuestosTrabajos.Remove(presupuestosTrabajo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PresupuestosTrabajoExists(long id)
        {
          return (_context.PresupuestosTrabajos?.Any(e => e.PresupuestoId == id)).GetValueOrDefault();
        }
    }
}
