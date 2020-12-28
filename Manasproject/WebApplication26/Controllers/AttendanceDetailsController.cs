using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApplication26.Models;

namespace WebApplication26.Controllers
{
    public class AttendanceDetailsController : Controller
    {
        private readonly project1211Context _context;

        public AttendanceDetailsController(project1211Context context)
        {
            _context = context;
        }

        // GET: AttendanceDetails
        public async Task<IActionResult> Index()
        {
            var date = DateTime.Today;
          
            var project1211Context1 = _context.AttendanceDetails.FirstOrDefault(a => a.CreatedDate.Value.Date == date);
            if ((HttpContext.Session.GetString("Type") == "2")&&(project1211Context1==null))
            {
                var db = new project1211Context();
                using (SqlConnection connection = new SqlConnection("Server=tcp:testserver1211.database.windows.net,1433;Initial Catalog=project1211;Persist Security Info=False;User ID=Admin123;Password=Garry@123;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "exec p1";


                    connection.Open();

                    command.ExecuteNonQuery();

                    connection.Close();
                }


            }
            var project1211Context = _context.AttendanceDetails.Include(a => a.FkStud).OrderByDescending(a => a.CreatedDate);
            return View(await project1211Context.ToListAsync());
        }

        // GET: AttendanceDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendanceDetail = await _context.AttendanceDetails
                .Include(a => a.FkStud)
                .FirstOrDefaultAsync(m => m.PkAttndId == id);
            if (attendanceDetail == null)
            {
                return NotFound();
            }

            return View(attendanceDetail);
        }

        // GET: AttendanceDetails/Create
        public IActionResult Create()
        {
            ViewData["FkStudId"] = new SelectList(_context.StudentDetails, "PkStudentId", "PkStudentId");
            return View();
        }

        // POST: AttendanceDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkAttndId,FkStudId,Attendance,CreatedDate")] AttendanceDetail attendanceDetail)
        {
            if (ModelState.IsValid)
            {
                attendanceDetail.CreatedDate = DateTime.Now;
                _context.Add(attendanceDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkStudId"] = new SelectList(_context.StudentDetails, "PkStudentId", "Contact", attendanceDetail.FkStudId);
            return View(attendanceDetail);
        }

        // GET: AttendanceDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendanceDetail = await _context.AttendanceDetails.FindAsync(id);
            if (attendanceDetail == null)
            {
                return NotFound();
            }
            ViewData["FkStudId"] = new SelectList(_context.StudentDetails, "PkStudentId", "Contact", attendanceDetail.FkStudId);
            return View(attendanceDetail);
        }
        // POST: AttendanceDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkAttndId,FkStudId,Attendance,CreatedDate")] AttendanceDetail attendanceDetail)
        {
            if (id != attendanceDetail.PkAttndId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attendanceDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttendanceDetailExists(attendanceDetail.PkAttndId))
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
            ViewData["FkStudId"] = new SelectList(_context.StudentDetails, "PkStudentId", "Contact", attendanceDetail.FkStudId);
            return View(attendanceDetail);
        }

        // GET: AttendanceDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendanceDetail = await _context.AttendanceDetails
                .Include(a => a.FkStud)
                .FirstOrDefaultAsync(m => m.PkAttndId == id);
            if (attendanceDetail == null)
            {
                return NotFound();
            }

            return View(attendanceDetail);
        }

        // POST: AttendanceDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attendanceDetail = await _context.AttendanceDetails.FindAsync(id);
            _context.AttendanceDetails.Remove(attendanceDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool AttendanceDetailExists(int id)
        {
            return _context.AttendanceDetails.Any(e => e.PkAttndId == id);
        }
    }
}