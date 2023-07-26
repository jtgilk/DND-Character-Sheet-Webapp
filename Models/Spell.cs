namespace DND_Character_Sheet_Webapp.Models
{
    public class Spell
    {
        // Properties
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SpellLevel { get; set; }
        public string CastingTime { get; set; }
        public string School { get; set; }
        public int? DamageDice { get; set; }
        public int? NumberOfDice { get; set; }
        public string? Bonus { get; set; }
        public string Range { get; set; }
        public string Duration { get; set; }
        public string Save { get; set; }
        public string Effect { get; set; }
        public string? Components { get; set; }
        public bool IsConcentration { get; set; }
        public bool IsRitual { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    }
}
