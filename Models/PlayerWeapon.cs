namespace DND_Character_Sheet_Webapp.Models
{
    public enum WeaponType
    {
        Sword,
        Axe,
        Bow,
        Staff,
        Dagger,
        Hammer,
        Mace,
        Spear,
        Polearm,
        Club,
        Crossbow,
        Thrown
    }
    public class DnD5eWeapon
    {
        // Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int WeightInPounds { get; set; }
        public int CostInGoldPieces { get; set; }
        public WeaponType WeaponType { get; set; }
        public int DamageDice { get; set; }
        public int NumberOfDice { get; set; }
        public int BonusDamage { get; set; }
        public bool IsMagical { get; set; }


        // Weapon Constructor
        public DnD5eWeapon()
        {
            DamageDice = 6; // Default to a six-sided dice for damage
            NumberOfDice = 1; // Default to one dice for damage
            BonusDamage = 0; // Default to no bonus damage
            IsMagical = false; // Default to non-magical item
        }

        // Method to get the damage of the weapon
        public string GetDamage()
        {
            return $"{NumberOfDice}d{DamageDice} + {BonusDamage}";
        }

        // Method to override ToString() for a user-friendly description of the item
        public override string ToString()
        {
            string magical = IsMagical ? " (Magical)" : "";
            return $"{Name}{magical}\nType: {WeaponType}\nDescription: {Description}\nWeight: {WeightInPounds} lbs\nCost: {CostInGoldPieces} gp\nDamage: {GetDamage()}";
        }
    }
}

