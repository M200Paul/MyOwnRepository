using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProvaAnagrafica.Models;

namespace ProvaAnagrafica.Controllers
{
    public class AnagraficheController : Controller
    {
        private readonly BloggingContext _context;

        public AnagraficheController(BloggingContext context)
        {
            _context = context;
        }

        // GET: Anagrafiche
        public async Task<IActionResult> Index()
        {
            return View(await _context.Anagrafiche.ToListAsync());
        }

        // GET: Anagrafiche/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anagrafica = await _context.Anagrafiche
                .FirstOrDefaultAsync(m => m.AnagraficaId == id);
            if (anagrafica == null)
            {
                return NotFound();
            }

            return View(anagrafica);
        }

        // GET: Anagrafiche/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Anagrafiche/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnagraficaId,Nome,Cognome,AnnoNascita,CodiceFiscale,Sesso")] Anagrafica anagrafica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anagrafica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anagrafica);
        }

        // GET: Anagrafiche/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anagrafica = await _context.Anagrafiche.FindAsync(id);
            if (anagrafica == null)
            {
                return NotFound();
            }
            return View(anagrafica);
        }

        // POST: Anagrafiche/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnagraficaId,Nome,Cognome,AnnoNascita,CodiceFiscale,Sesso")] Anagrafica anagrafica)
        {
            if (id != anagrafica.AnagraficaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anagrafica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnagraficaExists(anagrafica.AnagraficaId))
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
            return View(anagrafica);
        }

        // GET: Anagrafiche/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anagrafica = await _context.Anagrafiche
                .FirstOrDefaultAsync(m => m.AnagraficaId == id);
            if (anagrafica == null)
            {
                return NotFound();
            }

            return View(anagrafica);
        }

        // POST: Anagrafiche/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anagrafica = await _context.Anagrafiche.FindAsync(id);
            _context.Anagrafiche.Remove(anagrafica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnagraficaExists(int id)
        {
            return _context.Anagrafiche.Any(e => e.AnagraficaId == id);
        }
    }
}
