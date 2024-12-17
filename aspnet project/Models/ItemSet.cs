namespace aspnet_project.Models
{
    public class ItemSet
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<ItemSetItems>? ItemSetItems { get; set; }
    }
}
