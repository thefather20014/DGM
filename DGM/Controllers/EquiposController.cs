using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DGM.Models;

namespace DGM.Controllers
{
    public class EquiposController : Controller
    {
        private readonly DGMContext _context;

        public EquiposController(DGMContext context)
        {
            _context = context;
        }

        // GET: Equipos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Equipos.ToListAsync());
        }

        // GET: Equipos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipos
                .FirstOrDefaultAsync(m => m.IdEquipo == id);
            if (equipo == null)
            {
                return NotFound();
            }

            return View(equipo);
        }

        // GET: Equipos/Create
        public IActionResult Create()
        {
            ViewBag.Countries = new List<string>() { "DOM", "USA", "ARG", "AFG", "BOL", "BRA", "CAN", "COL", "CUB", "ECU", "ESP", "GBR", "VEN", "PRI" };
            ViewBag.Estados = new List<SelectListItem>()
            {
                new SelectListItem() { Text="Activo", Value="A" },
                new SelectListItem() { Text="Inactivo", Value="I" }
            };
            return View();
        }

        // POST: Equipos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEquipo,Nombre,Pais,Estado,FechaCreacion")] Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(equipo);
        }

        // GET: Equipos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Countries = new List<string>() { "DOM", "USA", "ARG", "AFG", "BOL", "BRA", "CAN", "COL", "CUB", "ECU", "ESP", "GBR", "VEN", "PRI" };
            ViewBag.Estados = new List<SelectListItem>()
            {
                new SelectListItem() { Text="Activo", Value="A" },
                new SelectListItem() { Text="Inactivo", Value="I" }
            };
            if (id == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo == null)
            {
                return NotFound();
            }
            return View(equipo);
        }

        // POST: Equipos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEquipo,Nombre,Pais,Estado,FechaCreacion")] Equipo equipo)
        {
            ViewBag.Countries = new List<string>() { "DOM", "USA", "ARG", "AFG", "BOL", "BRA", "CAN", "COL", "CUB", "ECU", "ESP", "GBR", "VEN", "PRI" };
            ViewBag.Estados = new List<SelectListItem>()
            {
                new SelectListItem() { Text="Activo", Value="A" },
                new SelectListItem() { Text="Inactivo", Value="I" }
            };
            if (id != equipo.IdEquipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipoExists(equipo.IdEquipo))
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
            return View(equipo);
        }

        // GET: Equipos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipos
                .FirstOrDefaultAsync(m => m.IdEquipo == id);
            if (equipo == null)
            {
                return NotFound();
            }

            return View(equipo);
        }

        // POST: Equipos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipo = await _context.Equipos.FindAsync(id);
            _context.Equipos.Remove(equipo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipoExists(int id)
        {
            return _context.Equipos.Any(e => e.IdEquipo == id);
        }
    }
}
