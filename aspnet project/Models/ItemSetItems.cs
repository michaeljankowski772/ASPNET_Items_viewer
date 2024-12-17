namespace aspnet_project.Models
{
    public class ItemSetItems
    {
        public int ItemId{ get; set; }
        public Item Item { get; set; }
        public int ItemSetId { get; set; }
        public ItemSet ItemSet { get; set; }
    }
}
