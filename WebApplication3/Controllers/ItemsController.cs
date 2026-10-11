using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using WebApplication3.Areas.Identity.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class ItemsController : Controller
    {
        private readonly ArtEquipmentContext _context;
        private readonly IWebHostEnvironment _hostenv;

        public ItemsController(ArtEquipmentContext context, IWebHostEnvironment hostenv)
        {
            _context = context;
            _hostenv = hostenv;
        }

        // GET: Items
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["ItemSortParm"] = String.IsNullOrEmpty(sortOrder) ? "item_desc" : "";
            ViewData["CategorySortParm"] = String.IsNullOrEmpty(sortOrder) ? "category_desc" : "";
            ViewData["CurrentFilter"] = searchString;

            var items = from i in _context.Item
                           select i;
            if (!String.IsNullOrEmpty(searchString))
            {
                items = items.Where(i => i.ItemName.Contains(searchString)
                                       || i.Category.ToString().Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    items = items.OrderByDescending(i => i.ItemName);
                    break;
                case "category_desc":
                    items = items.OrderByDescending(i => i.Category);
                    break;
            }
            return View(await items.AsNoTracking().ToListAsync());
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemID,ItemName,Category")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemID,ItemName,Attachment,Category")] Item item)
        {
            if (id != item.ItemID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.ItemID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .FirstOrDefaultAsync(m => m.ItemID == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Item.FindAsync(id);

            if (item != null)
            {
                _context.Item.Remove(item);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return _context.Item.Any(e => e.ItemID == id);
        }
    }
}
