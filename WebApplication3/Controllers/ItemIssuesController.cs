using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Areas.Identity.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class ItemIssuesController : Controller
    {
        private readonly ArtEquipmentContext _context;

        public ItemIssuesController(ArtEquipmentContext context)
        {
            _context = context;
        }

        // GET: ItemIssues
        public async Task<IActionResult> Index()
        {
            var itemIssue = _context.ItemIssue
                .Include(ii => ii.Issue)
                .Include(ii => ii.Stock)
                .AsNoTracking();
            return View(await itemIssue.ToListAsync());
        }

        // GET: ItemIssues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemIssue = await _context.ItemIssue
            .Include(ii => ii.Issue)
            .Include(ii => ii.Stock)
            .FirstOrDefaultAsync(m => m.StockID == id);
            if (itemIssue == null)
            {
                return NotFound();
            }

            return View(itemIssue);
        }

        // GET: ItemIssues/Create
        public IActionResult Create()
        {
            IssueForeignKeyDropdown();
            StockForeignKeyDropdown();
            return View();
        }

        // POST: ItemIssues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemIssueID,IssueID,StockID,Note,DateReturned")] ItemIssue itemIssue)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemIssue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            IssueForeignKeyDropdown(itemIssue.IssueID);
            StockForeignKeyDropdown(itemIssue.StockID);
            return View(itemIssue);
        }

        // GET: ItemIssues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemIssue = await _context.ItemIssue.FindAsync(id);
            if (itemIssue == null)
            {
                return NotFound();
            }
            IssueForeignKeyDropdown();
            StockForeignKeyDropdown();
            return View(itemIssue);
        }

        // POST: ItemIssues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemIssueID,IssueID,StockID,Note,DateReturned")] ItemIssue itemIssue)
        {
            if (id != itemIssue.ItemIssueID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemIssue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemIssueExists(itemIssue.ItemIssueID))
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
            IssueForeignKeyDropdown(itemIssue.IssueID);
            StockForeignKeyDropdown(itemIssue.StockID);
            return View(itemIssue);
        }

        // LINQ Query that displays the name of the issue in place of the standard foreign key field.
        // When using the application, the user sees the issue number whilst the ID is entered in the background.
        private void IssueForeignKeyDropdown(object selected = null)
        {
            var query = from i in _context.Issue
                        orderby i.IssueID
                        select i;
            ViewBag.IssueID = new SelectList(query.AsNoTracking(), "IssueID", "IssueID", selected);
        }

        // LINQ Query that displays the tag of the stock in place of the standard foreign key field.
        // When using the application, the user sees the stock tag whilst the ID is entered in the background.
        private void StockForeignKeyDropdown(object selected = null)
        {
            var query = from s in _context.Stock
                        orderby s.StockTag
                        select s;
            ViewBag.StockID = new SelectList(query.AsNoTracking(), "StockID", "StockTag", selected);
        }

        // GET: ItemIssues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemIssue = await _context.ItemIssue
                .Include(ii => ii.Issue)
                .Include(ii => ii.Stock)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ItemIssueID == id);
            if (itemIssue == null)
            {
                return NotFound();
            }

            return View(itemIssue);
        }

        // POST: ItemIssues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemIssue = await _context.ItemIssue.FindAsync(id);
            if (itemIssue != null)
            {
                _context.ItemIssue.Remove(itemIssue);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemIssueExists(int id)
        {
            return _context.ItemIssue.Any(e => e.ItemIssueID == id);
        }
    }
}
