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
    public class AdminEventsController : Controller
    {
        private readonly OrderSystemDbContext _context;

        public AdminEventsController(OrderSystemDbContext context)
        {
            _context = context;
        }

        // GET: AdminEvents
        public async Task<IActionResult> Index()
        {
            return _context.EveEvents != null ? 
                          View(await _context.EveEvents.ToListAsync()) :
                          Problem("Entity set 'OrderSystemDbContext.EveEvents'  is null.");
        }

        // GET: AdminEvents/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.EveEvents == null)
            {
                return NotFound();
            }

            var eveEvent = await _context.EveEvents
                .Include(e => e.StaStations)
                .FirstOrDefaultAsync(m => m.EveId == id);
            if (eveEvent == null)
            {
                return NotFound();
            }

            return View(eveEvent);
        }

        // GET: AdminEvents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EveId,EveName,EveStartDate,EveEndDate")] EveEvent eveEvent)
        {
            if (ModelState.IsValid)
            {
                eveEvent.EveId = Guid.NewGuid();
                _context.Add(eveEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eveEvent);
        }

        // GET: AdminEvents/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.EveEvents == null)
            {
                return NotFound();
            }

            var eveEvent = await _context.EveEvents.Include(e => e.StaStations).FirstAsync(e => e.EveId == id);
            if (eveEvent == null)
            {
                return NotFound();
            }
            return View(eveEvent);
        }

        // POST: AdminEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("EveId,EveName,EveStartDate,EveEndDate,StaStations")] EveEvent eveEvent)
        {
            if (id != eveEvent.EveId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eveEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EveEventExists(eveEvent.EveId))
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
            return View(eveEvent);
        }
        public async Task<IActionResult> RemoveStaion(Guid eveId ,Guid staId)
        {
            if (_context.StaStations.Find(staId) == null || _context.EveEvents.Find(eveId) == null)
            {
                return NotFound();
            }
            var eveEvent = _context.EveEvents.Include(e => e.StaStations).First(e => e.EveId == eveId);
            var sta = _context.StaStations.Find(staId);
            if (eveEvent.StaStations.Contains(sta))
            {
                eveEvent.StaStations.Remove(sta);
            }
            _context.Update(eveEvent);
            _context.SaveChanges();
            return RedirectToAction("Details",new {id = eveId});
        }
        // GET: AdminEvents/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.EveEvents == null)
            {
                return NotFound();
            }

            var eveEvent = await _context.EveEvents
                .FirstOrDefaultAsync(m => m.EveId == id);
            if (eveEvent == null)
            {
                return NotFound();
            }

            return View(eveEvent);
        }

        // POST: AdminEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.EveEvents == null)
            {
                return Problem("Entity set 'OrderSystemDbContext.EveEvents'  is null.");
            }
            var eveEvent = await _context.EveEvents.FindAsync(id);
            if (eveEvent != null)
            {
                _context.EveEvents.Remove(eveEvent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EveEventExists(Guid id)
        {
          return (_context.EveEvents?.Any(e => e.EveId == id)).GetValueOrDefault();
        }
    }
}
