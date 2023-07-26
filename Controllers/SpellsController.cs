using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DND_Character_Sheet_Webapp.Data;
using DND_Character_Sheet_Webapp.Models;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;

namespace DND_Character_Sheet_Webapp.Controllers
{
    public class SpellsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SpellsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Spells
        public async Task<IActionResult> Index()
        {
            TableBuild();
            return _context.Spell != null ?
                        View(await _context.Spell.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Spell'  is null.");
        }

        // GET: Spells/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Spell == null)
            {
                return NotFound();
            }

            var spell = await _context.Spell
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spell == null)
            {
                return NotFound();
            }

            return View(spell);
        }

        // GET: Spells/Create
        public IActionResult Create()
        {
            OnGet();
            return View();
        }

        // POST: Spells/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,SpellLevel,CastingTime,School,DamageDice,NumberOfDice,Bonus,Range,Duration,Save,Effect,Components,IsConcentration,IsRitual")] Spell spell)
        {
            if (ModelState.IsValid)
            {
                spell.Name = spell.Name.Trim();
                spell.Description = spell.Description.Trim();
                spell.CastingTime = spell.CastingTime.Trim();
                spell.Bonus = spell.Bonus?.Trim();
                spell.Range = spell.Range.Trim();
                spell.Duration = spell.Duration.Trim();
                spell.Components = spell.Components?.Trim();
                spell.Components = spell.Components?.Substring(0, 1).ToUpper() + spell.Components?.Substring(1);
                _context.Add(spell);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(spell);
        }

        // GET: Spells/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Spell == null)
            {
                return NotFound();
            }

            var spell = await _context.Spell.FindAsync(id);
            if (spell == null)
            {
                return NotFound();
            }
            OnGet();
            return View(spell);
        }

        // POST: Spells/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,SpellLevel,CastingTime,School,DamageDice,NumberOfDice,Bonus,Range,Duration,Save,Effect,Components,IsConcentration,IsRitual")] Spell spell)
        {
            if (id != spell.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    spell.Name = spell.Name.Trim();
                    spell.Description = spell.Description.Trim();
                    spell.CastingTime = spell.CastingTime.Trim();
                    spell.Bonus = spell.Bonus?.Trim();
                    spell.Range = spell.Range.Trim();
                    spell.Duration = spell.Duration.Trim();
                    spell.Components = spell.Components?.Trim();
                    spell.Components = spell.Components?.Substring(0, 1).ToUpper() + spell.Components?.Substring(1);
                    _context.Update(spell);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpellExists(spell.Id))
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
            return View(spell);
        }

        // GET: Spells/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Spell == null)
            {
                return NotFound();
            }

            var spell = await _context.Spell
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spell == null)
            {
                return NotFound();
            }

            return View(spell);
        }

        // POST: Spells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Spell == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Spell'  is null.");
            }
            var spell = await _context.Spell.FindAsync(id);
            if (spell != null)
            {
                _context.Spell.Remove(spell);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpellExists(int id)
        {
            return (_context.Spell?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public void OnGet()
        {
            //Spell School list
            List<SelectListItem> SpellSchools = new List<SelectListItem>
          {
            new SelectListItem { Value = "Abjuration", Text = "Abjuration" },
            new SelectListItem { Value = "Conjuration", Text = "Conjuration" },
            new SelectListItem { Value = "Divination", Text = "Divination" },
            new SelectListItem { Value = "Enchantment", Text = "Enchantment" },
            new SelectListItem { Value = "Evocation", Text = "Evocation" },
            new SelectListItem { Value = "Illusion", Text = "Illusion" },
            new SelectListItem { Value = "Necromancy", Text = "Necromancy" },
            new SelectListItem { Value = "Transmutation", Text = "Transmutation" },
          };
            ViewBag.SpellSchools = SpellSchools;
            //Spell levels
            List<SelectListItem> SpellLevels = new List<SelectListItem>
          {
            new SelectListItem { Value = "0", Text = "Cantrip" },
            new SelectListItem { Value = "1", Text = "1st Level" },
            new SelectListItem { Value = "2", Text = "2nd Level" },
            new SelectListItem { Value = "3", Text = "3rd Level" },
            new SelectListItem { Value = "4", Text = "4th Level" },
            new SelectListItem { Value = "5", Text = "5th Level" },
            new SelectListItem { Value = "6", Text = "6th Level" },
            new SelectListItem { Value = "7", Text = "7th Level" },
            new SelectListItem { Value = "8", Text = "8th Level"},
            new SelectListItem { Value = "9", Text = "9th Level"}
          };
            ViewBag.SpellLevels = SpellLevels;
            //Spell saves
            List<SelectListItem> SpellSaves = new List<SelectListItem>
          {
            new SelectListItem { Value = "None", Text = "None" },
            new SelectListItem { Value = "Str", Text = "Str save" },
            new SelectListItem { Value = "Dex", Text = "Dex save" },
            new SelectListItem { Value = "Con", Text = "Con save" },
            new SelectListItem { Value = "Wis", Text = "Wis save" },
            new SelectListItem { Value = "Int", Text = "Int save" },
            new SelectListItem { Value = "Cha", Text = "Cha save" },
          };
            ViewBag.SpellSaves = SpellSaves;
            //Spell effects
            List<SelectListItem> SpellEffects = new List<SelectListItem>
          {
            new SelectListItem { Value = "Acid", Text = "Acid" },
            new SelectListItem { Value = "Bludgeoning", Text = "Bludgeoning" },
            new SelectListItem { Value = "Cold", Text = "Cold" },
            new SelectListItem { Value = "Fire", Text = "Fire" },
            new SelectListItem { Value = "Force", Text = "Force" },
            new SelectListItem { Value = "Lightning", Text = "Lightning" },
            new SelectListItem { Value = "Necrotic", Text = "Necrotic" },
            new SelectListItem { Value = "Piercing", Text = "Piercing" },
            new SelectListItem { Value = "Poison", Text = "Poison" },
            new SelectListItem { Value = "Psychic", Text = "Psychic" },
            new SelectListItem { Value = "Radiant", Text = "Radiant" },
            new SelectListItem { Value = "Slashing", Text = "Slashing" },
            new SelectListItem { Value = "Thunder", Text = "Thunder" },
            new SelectListItem { Value = "Necrotic", Text = "Necrotic" },
            new SelectListItem { Value = "Blinded", Text = "Blinded" },
            new SelectListItem { Value = "Charmed", Text = "Charmed" },
            new SelectListItem { Value = "Deafened", Text = "Deafened" },
            new SelectListItem { Value = "Exhaustion", Text = "Exhaustion" },
            new SelectListItem { Value = "Frightened", Text = "Frightened" },
            new SelectListItem { Value = "Grappled", Text = "Grappled" },
            new SelectListItem { Value = "Incapacitated", Text = "Incapacitated" },
            new SelectListItem { Value = "Invisible", Text = "Invisible" },
            new SelectListItem { Value = "Paralyzed", Text = "Paralyzed" },
            new SelectListItem { Value = "Petrified", Text = "Petrified" },
            new SelectListItem { Value = "Poisoned", Text = "Poisoned" },
            new SelectListItem { Value = "Prone", Text = "Prone" },
            new SelectListItem { Value = "Restrained", Text = "Restrained" },
            new SelectListItem { Value = "Stunned", Text = "Stunned" },
            new SelectListItem { Value = "Unconscious", Text = "Unconscious" },
            new SelectListItem { Value = "Healing", Text = "Healing" },

          };
            var sortedSpellEffects = SpellEffects.OrderBy(x => x.Value);
            ViewBag.SpellEffects = sortedSpellEffects;
        }
        public void TableBuild()
        {
            string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=5eDB";
            string sqlQuery = "SELECT Id, NumberOfDice, DamageDice, Bonus FROM Spell;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Process the data returned by the query
                        Dictionary<int, string> SpellDice = new Dictionary<int, string>();
                        while (reader.Read())
                        {
                            // Access data using column names
                            int spellId = (int)reader["Id"];
                            var NumberOfDice = reader["NumberOfDice"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("NumberOfDice")) : 0;
                            var DamageDice = reader["DamageDice"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("DamageDice")) : 0;
                            string bonusString = reader["Bonus"] != DBNull.Value ? reader["Bonus"].ToString() : "0";
                            int bonus;
                            if (int.TryParse(bonusString, out bonus))
                            {
                                // Conversion successful
                                // "bonus" contains the int value from the string
                            }
                            else
                            {
                                // Conversion failed, set "bonus" to 0
                                bonus = 0;
                            }
                            string HandeledDice = $"{NumberOfDice}d{DamageDice}+{bonus}";
                            SpellDice.Add(spellId, HandeledDice);
                            // ... (and so on for other columns)
                        }
                        ViewBag.SpellDice = SpellDice;
                    }
                }
            }
        }
    }
}
