using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DND_Character_Sheet_Webapp.Data;
using DND_Character_Sheet_Webapp.Models;

namespace DND_Character_Sheet_Webapp.Controllers
{
    public class DnD5ePlayerItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DnD5ePlayerItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DnD5ePlayerItem
        public async Task<IActionResult> Index()
        {
              return _context.DnD5ePlayerItem != null ? 
                          View(await _context.DnD5ePlayerItem.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.DnD5ePlayerItem'  is null.");
        }

        // GET: DnD5ePlayerItem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DnD5ePlayerItem == null)
            {
                return NotFound();
            }

            var dnD5ePlayerItem = await _context.DnD5ePlayerItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dnD5ePlayerItem == null)
            {
                return NotFound();
            }

            return View(dnD5ePlayerItem);
        }

        // GET: DnD5ePlayerItem/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DnD5ePlayerItem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,WeightInPounds,CostInGoldPieces,Notes")] DnD5ePlayerItem dnD5ePlayerItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dnD5ePlayerItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dnD5ePlayerItem);
        }

        // GET: DnD5ePlayerItem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DnD5ePlayerItem == null)
            {
                return NotFound();
            }

            var dnD5ePlayerItem = await _context.DnD5ePlayerItem.FindAsync(id);
            if (dnD5ePlayerItem == null)
            {
                return NotFound();
            }
            return View(dnD5ePlayerItem);
        }

        // POST: DnD5ePlayerItem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,WeightInPounds,CostInGoldPieces,Notes")] DnD5ePlayerItem dnD5ePlayerItem)
        {
            if (id != dnD5ePlayerItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dnD5ePlayerItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DnD5ePlayerItemExists(dnD5ePlayerItem.Id))
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
            return View(dnD5ePlayerItem);
        }

        // GET: DnD5ePlayerItem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DnD5ePlayerItem == null)
            {
                return NotFound();
            }

            var dnD5ePlayerItem = await _context.DnD5ePlayerItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dnD5ePlayerItem == null)
            {
                return NotFound();
            }

            return View(dnD5ePlayerItem);
        }

        // POST: DnD5ePlayerItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DnD5ePlayerItem == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DnD5ePlayerItem'  is null.");
            }
            var dnD5ePlayerItem = await _context.DnD5ePlayerItem.FindAsync(id);
            if (dnD5ePlayerItem != null)
            {
                _context.DnD5ePlayerItem.Remove(dnD5ePlayerItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DnD5ePlayerItemExists(int id)
        {
          return (_context.DnD5ePlayerItem?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
