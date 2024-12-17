namespace aspnet_project.Models
{
    public class Item
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ItemSlot SlotId { get; set; }
        public int Armor { get; set; }
        public int PhysicalReductionPercent { get; set; }
        public string ImageURL { get; set; }
        public List<ItemSetItems>? ItemSetItems { get; set; }

    }
}
