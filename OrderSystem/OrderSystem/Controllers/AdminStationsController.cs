using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrderSystem;
using OrderSystem.Models;
//https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/update-related-data?view=aspnetcore-6.0
namespace OrderSystem.Controllers
{
    public class AdminStationsController : Controller
    {
        private readonly OrderSystemDbContext _context;

        public AdminStationsController(OrderSystemDbContext context)
        {
            _context = context;
        }

        // GET: AdminStations
        public async Task<IActionResult> Index()
        {
            var orderSystemDbContext = _context.StaStations.Include(s => s.StaEve);
            return View(await orderSystemDbContext.ToListAsync());
        }

        // GET: AdminStations/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.StaStations == null)
            {
                return NotFound();
            }

            var staStation = await _context.StaStations
                .Include(s => s.StaEve)
                .Include(s => s.ProProducts)
                .Include(s => s.ShiShifts)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.StaId == id);
            if (staStation == null)
            {
                return NotFound();
            }

            return View(staStation);
        }

        // GET: AdminStations/Create
        public IActionResult Create()
        {
            PopulateProductDropDownList();
            ViewData["StaEveId"] = new SelectList(_context.EveEvents, "EveId", "EveName");
            return View();
        }

        // POST: AdminStations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StaId,StaName,StaDescription,StaEveId,ProProducts")] StaStation staStation)
        {
            if (ModelState.IsValid)
            {
                staStation.StaId = Guid.NewGuid();
                _context.Add(staStation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StaEveId"] = new SelectList(_context.EveEvents, "EveId", "EveName", staStation.StaEveId);
            return View(staStation);
        }

        // GET: AdminStations/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.StaStations == null)
            {
                return NotFound();
            }

            var staStation = await _context.StaStations.Include(s => s.ProProducts).FirstAsync(s => s.StaId == id);
            if (staStation == null)
            {
                return NotFound();
            }
            ViewData["StaEveId"] = new SelectList(_context.EveEvents, "EveId", "EveName", staStation.StaEveId);
            PopulateProductDropDownList(staStation.ProProducts);
            return View(staStation);
        }

        // POST: AdminStations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("StaId,StaName,StaDescription,StaEveId")] StaStation staStation)
        {
            if (id != staStation.StaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staStation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaStationExists(staStation.StaId))
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
            ViewData["StaEveId"] = new SelectList(_context.EveEvents, "EveId", "EveName", staStation.StaEveId);
            return View(staStation);
        }

        // GET: AdminStations/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.StaStations == null)
            {
                return NotFound();
            }

            var staStation = await _context.StaStations
                .Include(s => s.StaEve)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.StaId == id);
            if (staStation == null)
            {
                return NotFound();
            }

            return View(staStation);
        }

        // POST: AdminStations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.StaStations == null)
            {
                return Problem("Entity set 'OrderSystemDbContext.StaStations'  is null.");
            }
            var staStation = await _context.StaStations.FindAsync(id);
            if (staStation != null)
            {
                _context.StaStations.Remove(staStation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaStationExists(Guid id)
        {
          return (_context.StaStations?.Any(e => e.StaId == id)).GetValueOrDefault();
        }
        public void PopulateProductDropDownList(object selectedProduct = null)
        {
            var productQuery = from p in _context.ProProducts
                                   orderby p.ProName
                                   select p;
            ViewBag.ProProducts = new SelectList(productQuery.AsNoTracking(), "ProId", "ProName", selectedProduct);
        }
    }
}
