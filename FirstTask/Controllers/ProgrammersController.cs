using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FirstTask.Data;
using FirstTask.Models;

namespace FirstTask.Controllers
{
    public class ProgrammersController : Controller
    {
        private readonly DBContext _context;

        public ProgrammersController(DBContext context)
        {
            _context = context;
        }

        // GET: Programmers
        public async Task<IActionResult> Index()
        {
            var dBContext = _context.Programmers.Include(p => p.Position);
            return View(await dBContext.ToListAsync());
        }

        // GET: Programmers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programmer = await _context.Programmers
                .Include(p => p.Position)
                .FirstOrDefaultAsync(m => m.ProgrammerID == id);
            if (programmer == null)
            {
                return NotFound();
            }

            return View(programmer);
        }

        // GET: Programmers/Create
        public IActionResult Create()
        {
            ViewData["PositionID"] = new SelectList(_context.Positions, "PositionID", "PositionName");
            return View();
        }

        // POST: Programmers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProgrammerID,Name,LastName,PositionID")] Programmer programmer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(programmer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PositionID"] = new SelectList(_context.Positions, "PositionID", "PositionName", programmer.PositionID);
            return View(programmer);
        }

        // GET: Programmers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programmer = await _context.Programmers.FindAsync(id);
            if (programmer == null)
            {
                return NotFound();
            }
            ViewData["PositionID"] = new SelectList(_context.Positions, "PositionID", "PositionName", programmer.PositionID);
            return View(programmer);
        }

        // POST: Programmers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProgrammerID,Name,LastName,PositionID")] Programmer programmer)
        {
            if (id != programmer.ProgrammerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(programmer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgrammerExists(programmer.ProgrammerID))
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
            ViewData["PositionID"] = new SelectList(_context.Positions, "PositionID", "PositionName", programmer.PositionID);
            return View(programmer);
        }

        // GET: Programmers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programmer = await _context.Programmers
                .Include(p => p.Position)
                .FirstOrDefaultAsync(m => m.ProgrammerID == id);
            if (programmer == null)
            {
                return NotFound();
            }

            return View(programmer);
        }

        // POST: Programmers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var programmer = await _context.Programmers.FindAsync(id);
            _context.Programmers.Remove(programmer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgrammerExists(int id)
        {
            return _context.Programmers.Any(e => e.ProgrammerID == id);
        }
    }
}
