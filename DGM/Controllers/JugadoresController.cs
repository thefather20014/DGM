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
    public class JugadoresController : Controller
    {
        private readonly DGMContext _context;

        public JugadoresController(DGMContext context)
        {
            _context = context;
        }

        // GET: Jugadores
        public async Task<IActionResult> Index()
        {
            var dGMContext = _context.Jugadores.Include(j => j.IdEquipoNavigation).Include(j => j.IdEstadoNavigation);
            return View(await dGMContext.ToListAsync());
        }

          public IActionResult Fibonacci(int num = 4, int limit = 10)
        {
            int a = 0, b = num - 1;
            int[] fibonacci = new int[limit];

            fibonacci[0] = a;
            fibonacci[1] = b;


            for(int x = 2; x < limit; x++)
			{
   
                fibonacci[x] = fibonacci[x - 1] + fibonacci[x - 2];

            }

            return View(fibonacci);

        }

        public async Task<IActionResult> JugadoresDetails()
        {
            var dGMContext = _context.Jugadores.Include(j => j.IdEquipoNavigation).Include(j => j.IdEstadoNavigation);

            return View(await dGMContext.ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> JugadoresDetails(string search, string estado)
        {
            @ViewData["detallesJugador"] = search;
            @ViewData["detallesEstado"] = estado;

            // data
            var query = from juga in _context.Jugadores
                        select juga;

            var qestado = from est in _context.Estados
                        select est;

            // filtro
            if (!String.IsNullOrEmpty(search))
			{
				query = query.Where(q => q.IdEquipoNavigation.Nombre.Contains(search) && q.IdEstadoNavigation.Descripion.Contains(estado));

			}

            //Llenar Dropdown

            var dropdown = from equi in _context.Equipos
                           select new { Descripcion = equi.Nombre };

            var dropdown2 = from es in _context.Estados
                           select new { Descripcion = es.Descripion };

            ViewBag.dropdown = dropdown;
            ViewBag.estDropdown = dropdown2;

            return View(await query.Include(j => j.IdEquipoNavigation).Include(j => j.IdEstadoNavigation).ToListAsync()); //include aqui
        }


        // GET: Jugadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugadore = await _context.Jugadores
                .Include(j => j.IdEquipoNavigation)
                .Include(j => j.IdEstadoNavigation)
                .FirstOrDefaultAsync(m => m.IdJugadores == id);
            if (jugadore == null)
            {
                return NotFound();
            }

            return View(jugadore);
        }

        // GET: Jugadores/Create
        public IActionResult Create()
        {
            ViewData["IdEquipo"] = new SelectList(_context.Equipos, "IdEquipo", "Nombre");
            ViewData["IdEstado"] = new SelectList(_context.Estados, "IdEstado", "Descripion");
            ViewBag.Sexo = new List<SelectListItem>()
            {
                new SelectListItem() { Text="Masculino", Value="M" },
                new SelectListItem() { Text="Femenino", Value="F" }
            };
            return View();
        }

        // POST: Jugadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdJugadores,Nombre,Apellido,FechaNacimiento,Pasaporte,Direccion,Sexo,IdEquipo,IdEstado")] Jugadore jugadore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jugadore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEquipo"] = new SelectList(_context.Equipos, "IdEquipo", "Nombre", jugadore.IdEquipo);
            ViewData["IdEstado"] = new SelectList(_context.Estados, "IdEstado", "Descripion", jugadore.IdEstado);
            return View(jugadore);
        }

        // GET: Jugadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Sexo = new List<SelectListItem>()
            {
                new SelectListItem() { Text="Masculino", Value="M" },
                new SelectListItem() { Text="Femenino", Value="F" }
            };
            if (id == null)
            {
                return NotFound();
            }

            var jugadore = await _context.Jugadores.FindAsync(id);
            if (jugadore == null)
            {
                return NotFound();
            }
            ViewData["IdEquipo"] = new SelectList(_context.Equipos, "IdEquipo", "Nombre", jugadore.IdEquipo);
            ViewData["IdEstado"] = new SelectList(_context.Estados, "IdEstado", "Descripion", jugadore.IdEstado);
            return View(jugadore);
        }

        // POST: Jugadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdJugadores,Nombre,Apellido,FechaNacimiento,Pasaporte,Direccion,Sexo,IdEquipo,IdEstado")] Jugadore jugadore)
        {
            ViewBag.Sexo = new List<SelectListItem>()
            {
                new SelectListItem() { Text="Masculino", Value="M" },
                new SelectListItem() { Text="Femenino", Value="F" }
            };
            if (id != jugadore.IdJugadores)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jugadore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JugadoreExists(jugadore.IdJugadores))
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
            ViewData["IdEquipo"] = new SelectList(_context.Equipos, "IdEquipo", "Nombre", jugadore.IdEquipo);
            ViewData["IdEstado"] = new SelectList(_context.Estados, "IdEstado", "Descripion", jugadore.IdEstado);
            return View(jugadore);
        }

        // GET: Jugadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugadore = await _context.Jugadores
                .Include(j => j.IdEquipoNavigation)
                .Include(j => j.IdEstadoNavigation)
                .FirstOrDefaultAsync(m => m.IdJugadores == id);
            if (jugadore == null)
            {
                return NotFound();
            }

            return View(jugadore);
        }

        // POST: Jugadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jugadore = await _context.Jugadores.FindAsync(id);
            _context.Jugadores.Remove(jugadore);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JugadoreExists(int id)
        {
            return _context.Jugadores.Any(e => e.IdJugadores == id);
        }
    }
}
