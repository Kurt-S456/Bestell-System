using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrderSystem;
using OrderSystem.Models;

namespace OrderSystem.Controllers
{
    public class AdminPersonsController : Controller
    {
        private readonly OrderSystemDbContext _context;

        public AdminPersonsController(OrderSystemDbContext context)
        {
            _context = context;
        }

        // GET: AdminPersons
        public async Task<IActionResult> Index()
        {
            var orderSystemDbContext = _context.PerPersons.Include(p => p.RoRole).Include(p => p.UsrUser);
            return View(await orderSystemDbContext.ToListAsync());
        }

        // GET: AdminPersons/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.PerPersons == null)
            {
                return NotFound();
            }

            var perPerson = await _context.PerPersons
                .Include(p => p.RoRole)
                .Include(p => p.UsrUser)
                .FirstOrDefaultAsync(m => m.PerId == id);
            if (perPerson == null)
            {
                return NotFound();
            }

            return View(perPerson);
        }

        // GET: AdminPersons/Create
        public IActionResult Create()
        {
            ViewData["RoRoleId"] = new SelectList(_context.RoRoles, "RoId", "RoName");
            ViewData["UsrUserId"] = new SelectList(_context.UsrUsers, "UsrId", "UsrName");
            return View();
        }

        // POST: AdminPersons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PerId,PerFirstName,PerLastName,PerCode,UsrUserId,RoRoleId")] PerPerson perPerson)
        {
            if (ModelState.IsValid)
            {
                perPerson.PerId = Guid.NewGuid();
                _context.Add(perPerson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoRoleId"] = new SelectList(_context.RoRoles, "RoId", "RoName", perPerson.RoRoleId);
            ViewData["UsrUserId"] = new SelectList(_context.UsrUsers, "UsrId", "UsrName", perPerson.UsrUserId);
            return View(perPerson);
        }

        // GET: AdminPersons/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.PerPersons == null)
            {
                return NotFound();
            }

            var perPerson = await _context.PerPersons.FindAsync(id);
            if (perPerson == null)
            {
                return NotFound();
            }
            ViewData["RoRoleId"] = new SelectList(_context.RoRoles, "RoId", "RoName", perPerson.RoRoleId);
            ViewData["UsrUserId"] = new SelectList(_context.UsrUsers, "UsrId", "UsrName", perPerson.UsrUserId);
            return View(perPerson);
        }

        // POST: AdminPersons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PerId,PerFirstName,PerLastName,PerCode,UsrUserId,RoRoleId")] PerPerson perPerson)
        {
            if (id != perPerson.PerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(perPerson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerPersonExists(perPerson.PerId))
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
            ViewData["RoRoleId"] = new SelectList(_context.RoRoles, "RoId", "RoName", perPerson.RoRoleId);
            ViewData["UsrUserId"] = new SelectList(_context.UsrUsers, "UsrId", "UsrName", perPerson.UsrUserId);
            return View(perPerson);
        }

        // GET: AdminPersons/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.PerPersons == null)
            {
                return NotFound();
            }

            var perPerson = await _context.PerPersons
                .Include(p => p.RoRole)
                .Include(p => p.UsrUser)
                .FirstOrDefaultAsync(m => m.PerId == id);
            if (perPerson == null)
            {
                return NotFound();
            }

            return View(perPerson);
        }

        // POST: AdminPersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.PerPersons == null)
            {
                return Problem("Entity set 'OrderSystemDbContext.PerPersons'  is null.");
            }
            var perPerson = await _context.PerPersons.FindAsync(id);
            if (perPerson != null)
            {
                _context.PerPersons.Remove(perPerson);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerPersonExists(Guid id)
        {
          return (_context.PerPersons?.Any(e => e.PerId == id)).GetValueOrDefault();
        }
    }
}
