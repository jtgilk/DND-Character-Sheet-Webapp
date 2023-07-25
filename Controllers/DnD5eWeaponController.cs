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
    public class DnD5eWeaponController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DnD5eWeaponController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DnD5eWeapon
        public async Task<IActionResult> Index()
        {
              return _context.DnD5eWeapon != null ? 
                          View(await _context.DnD5eWeapon.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.DnD5eWeapon'  is null.");
        }

        // GET: DnD5eWeapon/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DnD5eWeapon == null)
            {
                return NotFound();
            }

            var dnD5eWeapon = await _context.DnD5eWeapon
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dnD5eWeapon == null)
            {
                return NotFound();
            }

            return View(dnD5eWeapon);
        }

        // GET: DnD5eWeapon/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DnD5eWeapon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,WeightInPounds,CostInGoldPieces,WeaponType,DamageDice,NumberOfDice,BonusDamage,IsMagical")] DnD5eWeapon dnD5eWeapon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dnD5eWeapon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dnD5eWeapon);
        }

        // GET: DnD5eWeapon/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DnD5eWeapon == null)
            {
                return NotFound();
            }

            var dnD5eWeapon = await _context.DnD5eWeapon.FindAsync(id);
            if (dnD5eWeapon == null)
            {
                return NotFound();
            }
            return View(dnD5eWeapon);
        }

        // POST: DnD5eWeapon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,WeightInPounds,CostInGoldPieces,WeaponType,DamageDice,NumberOfDice,BonusDamage,IsMagical")] DnD5eWeapon dnD5eWeapon)
        {
            if (id != dnD5eWeapon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dnD5eWeapon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DnD5eWeaponExists(dnD5eWeapon.Id))
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
            return View(dnD5eWeapon);
        }

        // GET: DnD5eWeapon/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DnD5eWeapon == null)
            {
                return NotFound();
            }

            var dnD5eWeapon = await _context.DnD5eWeapon
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dnD5eWeapon == null)
            {
                return NotFound();
            }

            return View(dnD5eWeapon);
        }

        // POST: DnD5eWeapon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DnD5eWeapon == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DnD5eWeapon'  is null.");
            }
            var dnD5eWeapon = await _context.DnD5eWeapon.FindAsync(id);
            if (dnD5eWeapon != null)
            {
                _context.DnD5eWeapon.Remove(dnD5eWeapon);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DnD5eWeaponExists(int id)
        {
          return (_context.DnD5eWeapon?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
