using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DND_Character_Sheet_Webapp.Models;

namespace DND_Character_Sheet_Webapp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<DND_Character_Sheet_Webapp.Models.DnD5ePlayerCharacter> DnD5ePlayerCharacter { get; set; } = default!;
        public DbSet<DND_Character_Sheet_Webapp.Models.DnD5eWeapon> DnD5eWeapon { get; set; } = default!;
        public DbSet<DND_Character_Sheet_Webapp.Models.DnD5ePlayerItem> DnD5ePlayerItem { get; set; } = default!;
    }
}