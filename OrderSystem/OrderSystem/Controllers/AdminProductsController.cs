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
    public class AdminProductsController : Controller
    {
        private readonly OrderSystemDbContext _context;

        public AdminProductsController(OrderSystemDbContext context)
        {
            _context = context;
        }

        // GET: AdminProducts
        public async Task<IActionResult> Index()
        {
              return _context.ProProducts != null ? 
                          View(await _context.ProProducts.ToListAsync()) :
                          Problem("Entity set 'OrderSystemDbContext.ProProducts'  is null.");
        }

        // GET: AdminProducts/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.ProProducts == null)
            {
                return NotFound();
            }

            var proProduct = await _context.ProProducts
                .FirstOrDefaultAsync(m => m.ProId == id);
            if (proProduct == null)
            {
                return NotFound();
            }

            return View(proProduct);
        }

        // GET: AdminProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProId,ProName,ProDescription,ProColor,ProPrice,ProPriceBuy")] ProProduct proProduct)
        {
            if (ModelState.IsValid)
            {
                proProduct.ProId = Guid.NewGuid();
                _context.Add(proProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proProduct);
        }

        // GET: AdminProducts/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.ProProducts == null)
            {
                return NotFound();
            }

            var proProduct = await _context.ProProducts.FindAsync(id);
            if (proProduct == null)
            {
                return NotFound();
            }
            return View(proProduct);
        }

        // POST: AdminProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ProId,ProName,ProDescription,ProColor,ProPrice,ProPriceBuy")] ProProduct proProduct)
        {
            if (id != proProduct.ProId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProProductExists(proProduct.ProId))
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
            return View(proProduct);
        }

        // GET: AdminProducts/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.ProProducts == null)
            {
                return NotFound();
            }

            var proProduct = await _context.ProProducts
                .FirstOrDefaultAsync(m => m.ProId == id);
            if (proProduct == null)
            {
                return NotFound();
            }

            return View(proProduct);
        }

        // POST: AdminProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.ProProducts == null)
            {
                return Problem("Entity set 'OrderSystemDbContext.ProProducts'  is null.");
            }
            var proProduct = await _context.ProProducts.FindAsync(id);
            if (proProduct != null)
            {
                _context.ProProducts.Remove(proProduct);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProProductExists(Guid id)
        {
          return (_context.ProProducts?.Any(e => e.ProId == id)).GetValueOrDefault();
        }
    }
}
