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
    public class DnD5ePlayerCharacterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DnD5ePlayerCharacterController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DnD5ePlayerCharacter
        public async Task<IActionResult> Index()
        {
              return _context.DnD5ePlayerCharacter != null ? 
                          View(await _context.DnD5ePlayerCharacter.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.DnD5ePlayerCharacter'  is null.");
        }

        // GET: DnD5ePlayerCharacter/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DnD5ePlayerCharacter == null)
            {
                return NotFound();
            }

            var dnD5ePlayerCharacter = await _context.DnD5ePlayerCharacter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dnD5ePlayerCharacter == null)
            {
                return NotFound();
            }

            return View(dnD5ePlayerCharacter);
        }

        // GET: DnD5ePlayerCharacter/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DnD5ePlayerCharacter/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Race,Class,Level,charStrength,charDexterity,charConstitution,charIntelligence,charWisdom,charCharisma,HitPoints,Background,Alignment")] DnD5ePlayerCharacter dnD5ePlayerCharacter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dnD5ePlayerCharacter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dnD5ePlayerCharacter);
        }

        // GET: DnD5ePlayerCharacter/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DnD5ePlayerCharacter == null)
            {
                return NotFound();
            }

            var dnD5ePlayerCharacter = await _context.DnD5ePlayerCharacter.FindAsync(id);
            if (dnD5ePlayerCharacter == null)
            {
                return NotFound();
            }
            return View(dnD5ePlayerCharacter);
        }

        // POST: DnD5ePlayerCharacter/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Race,Class,Level,charStrength,charDexterity,charConstitution,charIntelligence,charWisdom,charCharisma,HitPoints,Background,Alignment")] DnD5ePlayerCharacter dnD5ePlayerCharacter)
        {
            if (id != dnD5ePlayerCharacter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dnD5ePlayerCharacter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DnD5ePlayerCharacterExists(dnD5ePlayerCharacter.Id))
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
            return View(dnD5ePlayerCharacter);
        }

        // GET: DnD5ePlayerCharacter/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DnD5ePlayerCharacter == null)
            {
                return NotFound();
            }

            var dnD5ePlayerCharacter = await _context.DnD5ePlayerCharacter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dnD5ePlayerCharacter == null)
            {
                return NotFound();
            }

            return View(dnD5ePlayerCharacter);
        }

        // POST: DnD5ePlayerCharacter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DnD5ePlayerCharacter == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DnD5ePlayerCharacter'  is null.");
            }
            var dnD5ePlayerCharacter = await _context.DnD5ePlayerCharacter.FindAsync(id);
            if (dnD5ePlayerCharacter != null)
            {
                _context.DnD5ePlayerCharacter.Remove(dnD5ePlayerCharacter);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DnD5ePlayerCharacterExists(int id)
        {
          return (_context.DnD5ePlayerCharacter?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
