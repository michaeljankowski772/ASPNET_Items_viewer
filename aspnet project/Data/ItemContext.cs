using aspnet_project.Models;
using Microsoft.EntityFrameworkCore;

namespace aspnet_project.Data
{
    public class ItemContext : DbContext
    {
        public ItemContext(DbContextOptions<ItemContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemSetItems>().HasKey(z => new
            {
                z.ItemId,
                z.ItemSetId
            });

            modelBuilder.Entity<ItemSetItems>().HasOne(z => z.Item).WithMany(z => z.ItemSetItems).HasForeignKey(z => z.ItemId);
            modelBuilder.Entity<ItemSetItems>().HasOne(z => z.ItemSet).WithMany(z => z.ItemSetItems).HasForeignKey(z => z.ItemSetId);

            var ItemEntity = new Item
            {
                Id = 1,
                Name = "Golden Armor",
                Armor = 12,
                PhysicalReductionPercent = 0,
                SlotId = ItemSlot.Armor,
                ImageURL = "https://static.wikia.nocookie.net/tibia/images/d/d0/Golden_Armor.gif/revision/latest/thumbnail/width/360/height/360?cb=20050613134413&path-prefix=en"
            };
            var ItemSetEntity = new ItemSet
            {
                Id = 1,
                Name = "Golden set"
            };

            modelBuilder.Entity<Item>().HasData(ItemEntity);
            modelBuilder.Entity<ItemSet>().HasData(ItemSetEntity);

            modelBuilder.Entity<ItemSetItems>().HasData(
                new ItemSetItems { ItemId=1, ItemSetId=1});


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<ItemSet> ItemSets { get; set; }
        public DbSet<ItemSetItems> ItemSetItems { get; set; }



    }
}
