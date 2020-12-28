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
    public class MstDepartmentsController : Controller
    {
        private readonly project1211Context _context;

        public MstDepartmentsController(project1211Context context)
        {
            _context = context;
        }

        // GET: MstDepartments
        public async Task<IActionResult> Index()
        {
            return View(await _context.MstDepartments.ToListAsync());
        }

        // GET: MstDepartments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstDepartment = await _context.MstDepartments
                .FirstOrDefaultAsync(m => m.PkDeptId == id);
            if (mstDepartment == null)
            {
                return NotFound();
            }

            return View(mstDepartment);
        }

        // GET: MstDepartments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MstDepartments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkDeptId,DepartmentName,IsActive")] MstDepartment mstDepartment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mstDepartment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mstDepartment);
        }

        // GET: MstDepartments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstDepartment = await _context.MstDepartments.FindAsync(id);
            if (mstDepartment == null)
            {
                return NotFound();
            }
            return View(mstDepartment);
        }

        // POST: MstDepartments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkDeptId,DepartmentName,IsActive")] MstDepartment mstDepartment)
        {
            if (id != mstDepartment.PkDeptId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mstDepartment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MstDepartmentExists(mstDepartment.PkDeptId))
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
            return View(mstDepartment);
        }

        // GET: MstDepartments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstDepartment = await _context.MstDepartments
                .FirstOrDefaultAsync(m => m.PkDeptId == id);
            if (mstDepartment == null)
            {
                return NotFound();
            }

            return View(mstDepartment);
        }

        // POST: MstDepartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstDepartment = await _context.MstDepartments.FindAsync(id);
            _context.MstDepartments.Remove(mstDepartment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstDepartmentExists(int id)
        {
            return _context.MstDepartments.Any(e => e.PkDeptId == id);
        }
    }
}
