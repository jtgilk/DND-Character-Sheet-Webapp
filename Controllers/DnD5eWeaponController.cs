using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DND_Character_Sheet_Webapp.Data;
using DND_Character_Sheet_Webapp.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.AccessControl;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Data.SqlClient;
using DND_Character_Sheet_Webapp.Data.Migrations;

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
            TableBuild();
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
            OnGet();
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
                dnD5eWeapon.Name = dnD5eWeapon.Name.Trim();
                dnD5eWeapon.Description = dnD5eWeapon.Description.Trim();
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
            OnGet();
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
                    dnD5eWeapon.Name = dnD5eWeapon.Name.Trim();
                    dnD5eWeapon.Description = dnD5eWeapon.Description.Trim();
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

        public void OnGet()
        {
            List<SelectListItem> weapons = new List<SelectListItem>
          {
            new SelectListItem { Value = "Sword", Text = "Sword" },
            new SelectListItem { Value = "Axe", Text = "Axe" },
            new SelectListItem { Value = "Bow", Text = "Bow" },
            new SelectListItem { Value = "Staff", Text = "Staff" },
            new SelectListItem { Value = "Dagger", Text = "Dagger" },
            new SelectListItem { Value = "Hammer", Text = "Hammer" },
            new SelectListItem { Value = "Mace", Text = "Mace" },
            new SelectListItem { Value = "Spear", Text = "Spear" },
            new SelectListItem { Value = "Polearm", Text = "Polearm" },
            new SelectListItem { Value = "Club", Text = "Club" },
            new SelectListItem { Value = "Crossbow", Text = "Crossbow" },
            new SelectListItem { Value = "Thrown", Text = "Thrown" }
          };
            ViewBag.Weapons = weapons;
        }
        public void TableBuild()
        {
            string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=5eDB";
            string sqlQuery = "SELECT Id, NumberOfDice, DamageDice, BonusDamage FROM DnD5eWeapon;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Process the data returned by the query
                        Dictionary<int, string> WeaponDice = new Dictionary<int, string>();
                        while (reader.Read())
                        {
                            // Access data using column names
                            int spellId = (int)reader["Id"];
                            var NumberOfDice = reader["NumberOfDice"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("NumberOfDice")) : 0;
                            var DamageDice = reader["DamageDice"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("DamageDice")) : 0;
                            string bonusString = reader["BonusDamage"] != DBNull.Value ? reader["BonusDamage"].ToString() : "0";
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
                            WeaponDice.Add(spellId, HandeledDice);
                            // ... (and so on for other columns)
                        }
                        ViewBag.WeaponDice = WeaponDice;
                    }
                }
            }
        }
    }
}