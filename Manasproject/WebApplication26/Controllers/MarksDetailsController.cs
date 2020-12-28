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
    public class MarksDetailsController : Controller
    {
        private readonly project1211Context _context;

        public MarksDetailsController(project1211Context context)
        {
            _context = context;
        }

        // GET: MarksDetails
        public async Task<IActionResult> Index()
        {
            var project1211Context = _context.MarksDetails.Include(m => m.FkSem).Include(m => m.FkStud).Include(m => m.FkSub);
            return View(await project1211Context.ToListAsync());
        }

        // GET: MarksDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marksDetail = await _context.MarksDetails
                .Include(m => m.FkSem)
                .Include(m => m.FkStud)
                .Include(m => m.FkSub)
                .FirstOrDefaultAsync(m => m.PkMarksId == id);
            if (marksDetail == null)
            {
                return NotFound();
            }

            return View(marksDetail);
        }

        // GET: MarksDetails/Create
        public IActionResult Create()
        {
            ViewData["FkSemId"] = new SelectList(_context.MstSemesters, "PkSemId", "PkSemId");
            ViewData["FkStudId"] = new SelectList(_context.StudentDetails, "PkStudentId", "Contact");
            ViewData["FkSubId"] = new SelectList(_context.MstSubjects, "PkSubjectId", "PkSubjectId");
            return View();
        }

        // POST: MarksDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkMarksId,FkSemId,FkStudId,FkSubId,SessionalMarks,MainExamMarks,TotalMarks")] MarksDetail marksDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marksDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkSemId"] = new SelectList(_context.MstSemesters, "PkSemId", "PkSemId", marksDetail.FkSemId);
            ViewData["FkStudId"] = new SelectList(_context.StudentDetails, "PkStudentId", "Contact", marksDetail.FkStudId);
            ViewData["FkSubId"] = new SelectList(_context.MstSubjects, "PkSubjectId", "PkSubjectId", marksDetail.FkSubId);
            return View(marksDetail);
        }

        // GET: MarksDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marksDetail = await _context.MarksDetails.FindAsync(id);
            if (marksDetail == null)
            {
                return NotFound();
            }
            ViewData["FkSemId"] = new SelectList(_context.MstSemesters, "PkSemId", "PkSemId", marksDetail.FkSemId);
            ViewData["FkStudId"] = new SelectList(_context.StudentDetails, "PkStudentId", "Contact", marksDetail.FkStudId);
            ViewData["FkSubId"] = new SelectList(_context.MstSubjects, "PkSubjectId", "PkSubjectId", marksDetail.FkSubId);
            return View(marksDetail);
        }

        // POST: MarksDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkMarksId,FkSemId,FkStudId,FkSubId,SessionalMarks,MainExamMarks,TotalMarks")] MarksDetail marksDetail)
        {
            if (id != marksDetail.PkMarksId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marksDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarksDetailExists(marksDetail.PkMarksId))
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
            ViewData["FkSemId"] = new SelectList(_context.MstSemesters, "PkSemId", "PkSemId", marksDetail.FkSemId);
            ViewData["FkStudId"] = new SelectList(_context.StudentDetails, "PkStudentId", "Contact", marksDetail.FkStudId);
            ViewData["FkSubId"] = new SelectList(_context.MstSubjects, "PkSubjectId", "PkSubjectId", marksDetail.FkSubId);
            return View(marksDetail);
        }

        // GET: MarksDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marksDetail = await _context.MarksDetails
                .Include(m => m.FkSem)
                .Include(m => m.FkStud)
                .Include(m => m.FkSub)
                .FirstOrDefaultAsync(m => m.PkMarksId == id);
            if (marksDetail == null)
            {
                return NotFound();
            }

            return View(marksDetail);
        }

        // POST: MarksDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var marksDetail = await _context.MarksDetails.FindAsync(id);
            _context.MarksDetails.Remove(marksDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarksDetailExists(int id)
        {
            return _context.MarksDetails.Any(e => e.PkMarksId == id);
        }
    }
}
