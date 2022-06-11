﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameHub.Data;
using GameHub.Models;

namespace GameHub.Controllers
{
    public class KomentarIgricaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KomentarIgricaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: KomentarIgrica
        public async Task<IActionResult> Index()
        {
            return View(await _context.KomentarIgrica.ToListAsync());
        }

        // GET: KomentarIgrica/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var komentarIgrica = await _context.KomentarIgrica
                .FirstOrDefaultAsync(m => m.Id == id);
            if (komentarIgrica == null)
            {
                return NotFound();
            }

            return View(komentarIgrica);
        }

        // GET: KomentarIgrica/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KomentarIgrica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tekst,Ocjena,IgricaId")] KomentarIgrica komentarIgrica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(komentarIgrica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(komentarIgrica);
        }

        // GET: KomentarIgrica/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var komentarIgrica = await _context.KomentarIgrica.FindAsync(id);
            if (komentarIgrica == null)
            {
                return NotFound();
            }
            return View(komentarIgrica);
        }

        // POST: KomentarIgrica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tekst,Ocjena,IgricaId")] KomentarIgrica komentarIgrica)
        {
            if (id != komentarIgrica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(komentarIgrica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KomentarIgricaExists(komentarIgrica.Id))
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
            return View(komentarIgrica);
        }

        // GET: KomentarIgrica/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var komentarIgrica = await _context.KomentarIgrica
                .FirstOrDefaultAsync(m => m.Id == id);
            if (komentarIgrica == null)
            {
                return NotFound();
            }

            return View(komentarIgrica);
        }

        // POST: KomentarIgrica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var komentarIgrica = await _context.KomentarIgrica.FindAsync(id);
            _context.KomentarIgrica.Remove(komentarIgrica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KomentarIgricaExists(int id)
        {
            return _context.KomentarIgrica.Any(e => e.Id == id);
        }
    }
}