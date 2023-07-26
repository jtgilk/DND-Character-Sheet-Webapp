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


        // Item Constructor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public DnD5ePlayerItem()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
        }
    }
}
