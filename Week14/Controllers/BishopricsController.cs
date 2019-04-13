﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Week14.Models;

namespace Week14.Controllers
{
    public class BishopricsController : Controller
    {
        private readonly Week14Context _context;

        public BishopricsController(Week14Context context)
        {
            _context = context;
        }

        // GET: Bishoprics
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bishopric.ToListAsync());
        }

        // GET: Bishoprics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bishopric = await _context.Bishopric
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bishopric == null)
            {
                return NotFound();
            }

            return View(bishopric);
        }

        // GET: Bishoprics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bishoprics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Bishopric bishopric)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bishopric);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bishopric);
        }

        // GET: Bishoprics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bishopric = await _context.Bishopric.FindAsync(id);
            if (bishopric == null)
            {
                return NotFound();
            }
            return View(bishopric);
        }

        // POST: Bishoprics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Bishopric bishopric)
        {
            if (id != bishopric.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bishopric);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BishopricExists(bishopric.ID))
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
            return View(bishopric);
        }

        // GET: Bishoprics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bishopric = await _context.Bishopric
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bishopric == null)
            {
                return NotFound();
            }

            return View(bishopric);
        }

        // POST: Bishoprics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bishopric = await _context.Bishopric.FindAsync(id);
            _context.Bishopric.Remove(bishopric);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BishopricExists(int id)
        {
            return _context.Bishopric.Any(e => e.ID == id);
        }
    }
}
