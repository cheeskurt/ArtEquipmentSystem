
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Areas.Identity.Data;
using WebApplication3.Models;

[Authorize(Roles = "Teacher")]

public class StocksController : Controller
{
    private readonly ArtEquipmentContext _context;

    public StocksController(ArtEquipmentContext context)
    {
        _context = context;
    }

    // GET: STOCKS
    public async Task<IActionResult> Index()    
    {
        var stock = _context.Stock
                .Include(s => s.Item)
                .AsNoTracking();
        return View(await stock.ToListAsync());
    }

    // GET: STOCKS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            
            return NotFound();
        }

        var stock = await _context.Stock
            .Include(s => s.Item)
            .FirstOrDefaultAsync(m => m.StockID == id);
        if (stock == null)
        {
            return NotFound();
        }

        return View(stock);
    }

    // GET: STOCKS/Create
    public IActionResult Create()
    {
        ItemForeignKeyDropdown();
        return View();
    }

    // POST: STOCKS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("StockID,ItemID,StockTag,Item,ItemIssues")] Stock stock)
    {
        if (ModelState.IsValid)
        {
            _context.Add(stock);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ItemForeignKeyDropdown(stock.ItemID);
        return View(stock);
    }

    // GET: STOCKS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var stock = await _context.Stock.FindAsync(id);
        if (stock == null)
        {
            return NotFound();
        }
        ItemForeignKeyDropdown();
        return View(stock);
    }

    // POST: STOCKS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("StockID,ItemID,StockTag,Item,ItemIssues")] Stock stock)
    {
        if (id != stock.StockID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(stock);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockExists(stock.StockID))
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
        ItemForeignKeyDropdown(stock.ItemID);
        return View(stock);
    }

    // LINQ Query that displays the name of the item in place of the standard foreign key field.
    // When using the application, the user sees the item names whilst the ID is entered in the background.
    private void ItemForeignKeyDropdown(object selected = null)
    {
        var query = from i in _context.Item
        orderby i.ItemName
        select i;
        ViewBag.ItemID = new SelectList(query.AsNoTracking(), "ItemID", "ItemName", selected);
    }

    // GET: STOCKS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var stock = await _context.Stock
                .Include(s => s.Item)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.StockID == id);
        if (stock == null)
        {
            return NotFound();
        }

        return View(stock);
    }

    // POST: STOCKS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var stock = await _context.Stock.FindAsync(id);
        if (stock != null)
        {
            _context.Stock.Remove(stock);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool StockExists(int? id)
    {
        return _context.Stock.Any(e => e.StockID == id);
    }
}
