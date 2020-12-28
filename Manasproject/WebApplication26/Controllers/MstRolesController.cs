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
    public class MstRolesController : Controller
    {
        private readonly project1211Context _context;

        public MstRolesController(project1211Context context)
        {
            _context = context;
        }

        // GET: MstRoles
        public async Task<IActionResult> Index()
        {
            return View(await _context.MstRoles.ToListAsync());
        }

        // GET: MstRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstRole = await _context.MstRoles
                .FirstOrDefaultAsync(m => m.PkRoleId == id);
            if (mstRole == null)
            {
                return NotFound();
            }

            return View(mstRole);
        }

        // GET: MstRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MstRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkRoleId,RoleName,IsActive")] MstRole mstRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mstRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mstRole);
        }

        // GET: MstRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstRole = await _context.MstRoles.FindAsync(id);
            if (mstRole == null)
            {
                return NotFound();
            }
            return View(mstRole);
        }

        // POST: MstRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkRoleId,RoleName,IsActive")] MstRole mstRole)
        {
            if (id != mstRole.PkRoleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mstRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MstRoleExists(mstRole.PkRoleId))
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
            return View(mstRole);
        }

        // GET: MstRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstRole = await _context.MstRoles
                .FirstOrDefaultAsync(m => m.PkRoleId == id);
            if (mstRole == null)
            {
                return NotFound();
            }

            return View(mstRole);
        }

        // POST: MstRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstRole = await _context.MstRoles.FindAsync(id);
            _context.MstRoles.Remove(mstRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstRoleExists(int id)
        {
            return _context.MstRoles.Any(e => e.PkRoleId == id);
        }
    }
}
