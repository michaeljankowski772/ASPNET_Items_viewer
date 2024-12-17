using aspnet_project.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aspnet_project.Controllers
{
    public class Item : Controller
    {
        private readonly ItemContext _context;

        public Item(ItemContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        { 
            return View(await _context.Items.ToListAsync());
        }
        public async Task<IActionResult> Details(int id)
        {
            var item = await _context.Items.SingleOrDefaultAsync(z => z.Id == id);
            if (item == null)
            {
                return NotFound();
                //alert
            }
            else
            {
                item.Armor += 1;
                await _context.SaveChangesAsync();
            }

            return View(await _context.Items.ToListAsync());
        }
    }
}
