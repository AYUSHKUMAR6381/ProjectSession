using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication26.Models;

namespace WebApplication26.Controllers
{
    public class MstSubjectsController : Controller
    {
        private readonly project1211Context _context;

        public MstSubjectsController(project1211Context context)
        {
            _context = context;
        }

        // GET: MstSubjects
        public async Task<IActionResult> Index()
        {
            var project1211Context = _context.MstSubjects.Include(m => m.FkSem);
            return View(await project1211Context.ToListAsync());
        }

        // GET: MstSubjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstSubject = await _context.MstSubjects
                .Include(m => m.FkSem)
                .FirstOrDefaultAsync(m => m.PkSubjectId == id);
            if (mstSubject == null)
            {
                return NotFound();
            }

            return View(mstSubject);
        }

        // GET: MstSubjects/Create
        public IActionResult Create()
        {
            ViewData["FkSemId"] = new SelectList(_context.MstSemesters, "PkSemId", "PkSemId");
            return View();
        }

        // POST: MstSubjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkSubjectId,FkSemId,SubjectName,IsActive")] MstSubject mstSubject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mstSubject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkSemId"] = new SelectList(_context.MstSemesters, "PkSemId", "PkSemId", mstSubject.FkSemId);
            return View(mstSubject);
        }

        // GET: MstSubjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstSubject = await _context.MstSubjects.FindAsync(id);
            if (mstSubject == null)
            {
                return NotFound();
            }
            ViewData["FkSemId"] = new SelectList(_context.MstSemesters, "PkSemId", "PkSemId", mstSubject.FkSemId);
            return View(mstSubject);
        }

        // POST: MstSubjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkSubjectId,FkSemId,SubjectName,IsActive")] MstSubject mstSubject)
        {
            if (id != mstSubject.PkSubjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mstSubject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MstSubjectExists(mstSubject.PkSubjectId))
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
            ViewData["FkSemId"] = new SelectList(_context.MstSemesters, "PkSemId", "PkSemId", mstSubject.FkSemId);
            return View(mstSubject);
        }

        // GET: MstSubjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstSubject = await _context.MstSubjects
                .Include(m => m.FkSem)
                .FirstOrDefaultAsync(m => m.PkSubjectId == id);
            if (mstSubject == null)
            {
                return NotFound();
            }

            return View(mstSubject);
        }

        // POST: MstSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstSubject = await _context.MstSubjects.FindAsync(id);
            _context.MstSubjects.Remove(mstSubject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstSubjectExists(int id)
        {
            return _context.MstSubjects.Any(e => e.PkSubjectId == id);
        }
    }
}
