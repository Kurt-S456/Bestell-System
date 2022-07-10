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
    public class StaffOrder : Controller
    {
        private readonly OrderSystemDbContext _context;

        public StaffOrder(OrderSystemDbContext context)
        {
            _context = context;
        }

        // GET: StaffOrder
        public async Task<IActionResult> Index()
        {
            var orderSystemDbContext = _context.OrdOrders.Include(o => o.Shift);
            return View(await orderSystemDbContext.ToListAsync());
        }

        // GET: StaffOrder/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.OrdOrders == null)
            {
                return NotFound();
            }

            var ordOrder = await _context.OrdOrders
                .Include(o => o.Shift)
                .FirstOrDefaultAsync(m => m.OrdId == id);
            if (ordOrder == null)
            {
                return NotFound();
            }

            return View(ordOrder);
        }

        // GET: StaffOrder/Create
        public IActionResult Create()
        {
            ViewData["ShiftId"] = new SelectList(_context.ShiShifts, "ShiId", "ShiId");
            return View();
        }

        // POST: StaffOrder/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrdId,OrdTimeStamp,ShiftId")] OrdOrder ordOrder)
        {
            if (ModelState.IsValid)
            {
                ordOrder.OrdId = Guid.NewGuid();
                _context.Add(ordOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ShiftId"] = new SelectList(_context.ShiShifts, "ShiId", "ShiId", ordOrder.ShiftId);
            return View(ordOrder);
        }

        // GET: StaffOrder/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.OrdOrders == null)
            {
                return NotFound();
            }

            var ordOrder = await _context.OrdOrders.FindAsync(id);
            if (ordOrder == null)
            {
                return NotFound();
            }
            ViewData["ShiftId"] = new SelectList(_context.ShiShifts, "ShiId", "ShiId", ordOrder.ShiftId);
            return View(ordOrder);
        }

        // POST: StaffOrder/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("OrdId,OrdTimeStamp,ShiftId")] OrdOrder ordOrder)
        {
            if (id != ordOrder.OrdId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdOrderExists(ordOrder.OrdId))
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
            ViewData["ShiftId"] = new SelectList(_context.ShiShifts, "ShiId", "ShiId", ordOrder.ShiftId);
            return View(ordOrder);
        }

        // GET: StaffOrder/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.OrdOrders == null)
            {
                return NotFound();
            }

            var ordOrder = await _context.OrdOrders
                .Include(o => o.Shift)
                .FirstOrDefaultAsync(m => m.OrdId == id);
            if (ordOrder == null)
            {
                return NotFound();
            }

            return View(ordOrder);
        }

        // POST: StaffOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.OrdOrders == null)
            {
                return Problem("Entity set 'OrderSystemDbContext.OrdOrders'  is null.");
            }
            var ordOrder = await _context.OrdOrders.FindAsync(id);
            if (ordOrder != null)
            {
                _context.OrdOrders.Remove(ordOrder);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdOrderExists(Guid id)
        {
          return (_context.OrdOrders?.Any(e => e.OrdId == id)).GetValueOrDefault();
        }
    }
}
