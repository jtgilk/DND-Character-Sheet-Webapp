using Microsoft.AspNetCore.Mvc.Rendering;

namespace DND_Character_Sheet_Webapp.Models
{
    public class DnD5ePlayerCharacter
    {
        public int Id { get; set; }
        public string Player { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }
        public int Level { get; set; }
        public int charStrength { get; set; }
        public int charDexterity { get; set; }
        public int charConstitution { get; set; }
        public int charIntelligence { get; set; }
        public int charWisdom { get; set; }
        public int charCharisma { get; set; }
        public int HitPoints { get; set; }
        public string Background { get; set; }
        public string Alignment { get; set; }

        //Constructor

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public DnD5ePlayerCharacter()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }

    }
}
