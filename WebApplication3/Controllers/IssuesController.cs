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
    public class IssuesController : Controller
    {
        private readonly ArtEquipmentContext _context;

        public IssuesController(ArtEquipmentContext context)
        {
            _context = context;
        }

        // GET: Issues
        public async Task<IActionResult> Index()
        {
            var issue = _context.Issue
                .Include(i => i.Student)
                .Include(i => i.Subject)
                .AsNoTracking();
            return View(await issue.ToListAsync());
        }

        // GET: Issues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issue = await _context.Issue
                .Include(i => i.Student)
                .Include(i => i.Subject)
                .FirstOrDefaultAsync(m => m.IssueID == id);
            if (issue == null)
            {
                return NotFound();
            }

            return View(issue);
        }

        // GET: Issues/Create
        public IActionResult Create()
        {
            StudentForeignKeyDropdown();
            SubjectForeignKeyDropdown();
            return View();
        }

        // POST: Issues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IssueID,StudentID,SubjectID,Period,Reason,DateIssued")] Issue issue)
        {
            if (ModelState.IsValid)
            {
                SubjectForeignKeyDropdown(issue.SubjectID);
                _context.Add(issue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            StudentForeignKeyDropdown(issue.StudentID);
            SubjectForeignKeyDropdown(issue.SubjectID);
            return View(issue);
        }

        // GET: Issues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issue = await _context.Issue.FindAsync(id);
            if (issue == null)
            {
                return NotFound();
            }
            StudentForeignKeyDropdown();
            SubjectForeignKeyDropdown();
            return View(issue);
        }

        // POST: Issues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IssueID,StudentID,SubjectID,Period,Reason,DateIssued")] Issue issue)
        {
            if (id != issue.IssueID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    SubjectForeignKeyDropdown(issue.SubjectID);
                    _context.Update(issue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IssueExists(issue.IssueID))
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
            StudentForeignKeyDropdown(issue.StudentID);
            SubjectForeignKeyDropdown(issue.SubjectID);
            return View(issue);
        }

        private void StudentForeignKeyDropdown(object selected = null)
        {
            var query = from s in _context.Student
                        orderby s.FirstName
                        select s;
            ViewBag.StudentID = new SelectList(query.AsNoTracking(), "StudentID", "FirstName", selected);
        }

        private void SubjectForeignKeyDropdown(object selected = null)
        {
            var query = from s in _context.Subject
                        orderby s.SubjectName
                        select s;
            ViewBag.SubjectID = new SelectList(query.AsNoTracking(), "SubjectID", "SubjectName", selected);
        }

        // GET: Issues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issue = await _context.Issue
                .Include(i => i.Student)
                .Include(i => i.Subject)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.IssueID == id);
            if (issue == null)
            {
                return NotFound();
            }

            return View(issue);
        }

        // POST: Issues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var issue = await _context.Issue.FindAsync(id);
            if (issue != null)
            {
                _context.Issue.Remove(issue);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IssueExists(int id)
        {
            return _context.Issue.Any(e => e.IssueID == id);
        }
    }
}
