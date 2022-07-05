﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderSystem.Models;

namespace OrderSystem.Controllers
{
    public class StaffController : Controller
    {
        public StaffController(OrderSystemDbContext context)
        {
            _context = context; 
        }
        private readonly OrderSystemDbContext _context;
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string code)
        {

            if (_context.PerPersons.Any(p => p.PerCode == code))
            {
                PerPerson perPerson = await _context.PerPersons.SingleAsync(p => p.PerCode == code);
                if (!string.IsNullOrEmpty(perPerson.PerLastName) && !string.IsNullOrEmpty(perPerson.PerFirstName))
                {
                    return RedirectToAction("Order");
                }
                else if (string.IsNullOrEmpty(perPerson.PerLastName) || string.IsNullOrEmpty(perPerson.PerFirstName))
                {
                    return RedirectToAction("Reigister");
                }


            }
            return Redirect(nameof(Index));
        }
        public async Task<IActionResult> Register(string code)
        {
            if (String.IsNullOrEmpty(code))
            {
                return BadRequest();
            }
            PerPerson person = await _context.PerPersons.FirstAsync(p => p.PerCode == code);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(PerPerson person)
        {
            if (!ModelState.IsValid)
            {

            }
            return Redirect(nameof(Index));
        }
    }
}
