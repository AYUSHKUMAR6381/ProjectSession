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
    public class MstSemestersController : Controller
    {
        private readonly project1211Context _context;

        public MstSemestersController(project1211Context context)
        {
            _context = context;
        }

        // GET: MstSemesters
        public async Task<IActionResult> Index()
        {
            return View(await _context.MstSemesters.ToListAsync());
        }

        // GET: MstSemesters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstSemester = await _context.MstSemesters
                .FirstOrDefaultAsync(m => m.PkSemId == id);
            if (mstSemester == null)
            {
                return NotFound();
            }

            return View(mstSemester);
        }

        // GET: MstSemesters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MstSemesters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkSemId,Semester,IsActive")] MstSemester mstSemester)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mstSemester);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mstSemester);
        }

        // GET: MstSemesters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstSemester = await _context.MstSemesters.FindAsync(id);
            if (mstSemester == null)
            {
                return NotFound();
            }
            return View(mstSemester);
        }

        // POST: MstSemesters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkSemId,Semester,IsActive")] MstSemester mstSemester)
        {
            if (id != mstSemester.PkSemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mstSemester);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MstSemesterExists(mstSemester.PkSemId))
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
            return View(mstSemester);
        }

        // GET: MstSemesters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstSemester = await _context.MstSemesters
                .FirstOrDefaultAsync(m => m.PkSemId == id);
            if (mstSemester == null)
            {
                return NotFound();
            }

            return View(mstSemester);
        }

        // POST: MstSemesters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstSemester = await _context.MstSemesters.FindAsync(id);
            _context.MstSemesters.Remove(mstSemester);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstSemesterExists(int id)
        {
            return _context.MstSemesters.Any(e => e.PkSemId == id);
        }
    }
}
