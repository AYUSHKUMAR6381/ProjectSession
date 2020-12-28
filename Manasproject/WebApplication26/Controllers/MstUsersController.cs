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
    public class MstUsersController : Controller
    {
        private readonly project1211Context _context;

        public MstUsersController(project1211Context context)
        {
            _context = context;
        }

        // GET: MstUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.MstUsers.ToListAsync());
        }

        // GET: MstUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstUser = await _context.MstUsers
                .FirstOrDefaultAsync(m => m.PkUserId == id);
            if (mstUser == null)
            {
                return NotFound();
            }

            return View(mstUser);
        }

        // GET: MstUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MstUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkUserId,Fname,Lname,Email,Contact,Pswd,Dob,CreatedDate,FkRoleId,IsActive,IsDeleted")] MstUser mstUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mstUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mstUser);
        }

        // GET: MstUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstUser = await _context.MstUsers.FindAsync(id);
            if (mstUser == null)
            {
                return NotFound();
            }
            return View(mstUser);
        }

        // POST: MstUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkUserId,Fname,Lname,Email,Contact,Pswd,Dob,CreatedDate,FkRoleId,IsActive,IsDeleted")] MstUser mstUser)
        {
            if (id != mstUser.PkUserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mstUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MstUserExists(mstUser.PkUserId))
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
            return View(mstUser);
        }

        // GET: MstUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstUser = await _context.MstUsers
                .FirstOrDefaultAsync(m => m.PkUserId == id);
            if (mstUser == null)
            {
                return NotFound();
            }

            return View(mstUser);
        }

        // POST: MstUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstUser = await _context.MstUsers.FindAsync(id);
            _context.MstUsers.Remove(mstUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstUserExists(int id)
        {
            return _context.MstUsers.Any(e => e.PkUserId == id);
        }
    }
}
