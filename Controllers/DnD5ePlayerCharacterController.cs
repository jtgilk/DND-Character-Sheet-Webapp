using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DND_Character_Sheet_Webapp.Data;
using DND_Character_Sheet_Webapp.Models;
using Microsoft.CodeAnalysis.Options;
using Newtonsoft.Json.Linq;

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
            OnGet();
            return View();
        }

        // POST: DnD5ePlayerCharacter/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Player,Name,Race,Class,Level,charStrength,charDexterity,charConstitution,charIntelligence,charWisdom,charCharisma,HitPoints,Background,Alignment")] DnD5ePlayerCharacter dnD5ePlayerCharacter)
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
            OnGet();
            return View(dnD5ePlayerCharacter);
        }

        // POST: DnD5ePlayerCharacter/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Player,Name,Race,Class,Level,charStrength,charDexterity,charConstitution,charIntelligence,charWisdom,charCharisma,HitPoints,Background,Alignment")] DnD5ePlayerCharacter dnD5ePlayerCharacter)
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
        
        //Alignment select list
        public void OnGet()
        {
            List<SelectListItem> Alignments = new List<SelectListItem>
          {
            new SelectListItem {Value = "Lawful Good", Text = "Lawful Good"},
            new SelectListItem {Value = "Neutral Good", Text = "Neutral Good" },
            new SelectListItem {Value = "Chaotic Good", Text = "Chaotic Good"  },
            new SelectListItem {Value = "Lawful Neutral", Text = "Lawful Neutral" },
            new SelectListItem {Value = "Neutral", Text = "Neutral"  },
            new SelectListItem {Value = "Chaotic Neutral", Text = "Chaotic Neutral"},
            new SelectListItem {Value = "Lawful Evil", Text = "Lawful Evil"},
            new SelectListItem {Value = "Neutral Evil", Text = "Neutral Evil"},
            new SelectListItem {Value = "Chaotic Evil", Text = "Chaotic Evil"},
          };
            ViewBag.Alignments = Alignments;

        //Level select list
            List<SelectListItem> levelsList = new List<SelectListItem>();

            for (int i = 1; i <= 20; i++)
            {
                levelsList.Add(new SelectListItem
                {
                    Text = i.ToString(),
                    Value = i.ToString()
                });
            }
            ViewBag.Levels = levelsList;

            //Class select list
            List<SelectListItem> Classes = new List<SelectListItem>
        {
            new SelectListItem { Value = "Barbarian", Text = "Barbarian" },
            new SelectListItem { Value = "Bard", Text = "Bard" },
            new SelectListItem { Value = "Cleric", Text = "Cleric" },
            new SelectListItem { Value = "Druid", Text = "Druid" },
            new SelectListItem { Value = "Fighter", Text = "Fighter" },
            new SelectListItem { Value = "Monk", Text = "Monk" },
            new SelectListItem { Value = "Paladin", Text = "Paladin" },
            new SelectListItem { Value = "Ranger", Text = "Ranger" },
            new SelectListItem { Value = "Rogue", Text = "Rogue" },
            new SelectListItem { Value = "Sorcerer", Text = "Sorcerer" },
            new SelectListItem { Value = "Warlock", Text = "Warlock" },
            new SelectListItem { Value = "Wizard", Text = "Wizard" }
        };
            ViewBag.Classes = Classes;

            //Race select list
            List<SelectListItem> Races = new List<SelectListItem>
        {
            new SelectListItem { Value = "Dragonborn", Text = "Dragonborn" },
            new SelectListItem { Value = "Dwarf", Text = "Dwarf" },
            new SelectListItem { Value = "Elf", Text = "Elf" },
            new SelectListItem { Value = "Gnome", Text = "Gnome" },
            new SelectListItem { Value = "Half-Elf", Text = "Half-Elf" },
            new SelectListItem { Value = "Half-Orc", Text = "Half-Orc" },
            new SelectListItem { Value = "Halfling", Text = "Halfling" },
            new SelectListItem { Value = "Human", Text = "Human" },
            new SelectListItem { Value = "Tiefling", Text = "Tiefling" }
        };
            ViewBag.Races = Races;
        }
    }
}
