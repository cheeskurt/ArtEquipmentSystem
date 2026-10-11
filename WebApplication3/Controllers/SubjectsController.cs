
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Areas.Identity.Data;
using WebApplication3.Models;

[Authorize(Roles = "Teacher")]

public class SubjectsController : Controller
{
    private readonly ArtEquipmentContext _context;

    public SubjectsController(ArtEquipmentContext context)
    {
        _context = context;
    }

    // GET: SUBJECTS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Subject.ToListAsync());
    }

    // GET: SUBJECTS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: SUBJECTS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("SubjectID,SubjectName,Users,Issues")] Subject subject)
    {
        if (ModelState.IsValid)
        {
            _context.Add(subject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(subject);
    }

    // GET: SUBJECTS/Edit/5
    public async Task<IActionResult> Edit(int? subjectid)
    {
        if (subjectid == null)
        {
            return NotFound();
        }

        var subject = await _context.Subject.FindAsync(subjectid);
        if (subject == null)
        {
            return NotFound();
        }
        return View(subject);
    }

    // POST: SUBJECTS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? subjectid, [Bind("SubjectID,SubjectName,Users,Issues")] Subject subject)
    {
        if (subjectid != subject.SubjectID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(subject);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectExists(subject.SubjectID))
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
        return View(subject);
    }

    // GET: SUBJECTS/Delete/5
    public async Task<IActionResult> Delete(int? subjectid)
    {
        if (subjectid == null)
        {
            return NotFound();
        }

        var subject = await _context.Subject
            .FirstOrDefaultAsync(m => m.SubjectID == subjectid);
        if (subject == null)
        {
            return NotFound();
        }

        return View(subject);
    }

    // POST: SUBJECTS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? subjectid)
    {
        var subject = await _context.Subject.FindAsync(subjectid);
        if (subject != null)
        {
            _context.Subject.Remove(subject);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool SubjectExists(int? subjectid)
    {
        return _context.Subject.Any(e => e.SubjectID == subjectid);
    }
}
