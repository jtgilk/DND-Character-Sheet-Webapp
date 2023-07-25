namespace DND_Character_Sheet_Webapp.Models
{
    public class DnD5ePlayerItem
    {
        // Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int WeightInPounds { get; set; }
        public int CostInGoldPieces { get; set; }
        public string? Notes { get; set; }


        // Weapon Constructor
        public DnD5ePlayerItem()
        {
        }
    }
}
