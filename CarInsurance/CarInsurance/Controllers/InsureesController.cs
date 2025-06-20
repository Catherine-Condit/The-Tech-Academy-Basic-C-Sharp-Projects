using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarInsurance.Data;
using CarInsurance.Models;

namespace CarInsurance.Controllers
{
    public class InsureesController : Controller
    {
        private readonly InsuranceDbContext _context;

        public InsureesController(InsuranceDbContext context)
        {
            _context = context;
        }

        // GET: Insurees
        public async Task<IActionResult> Index()
        {
            return View(await _context.Insurees.ToListAsync());
        }

        // GET: Insurees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuree = await _context.Insurees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insuree == null)
            {
                return NotFound();
            }

            return View(insuree);
        }

        // GET: Insurees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Insurees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,HasDui,SpeedingTickets,FullCoverage")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                insuree.Quote = CalculateQuote(insuree); // 👈 Add this line to calculate the quote
                _context.Add(insuree);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(insuree);
        }


        // GET: Insurees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuree = await _context.Insurees.FindAsync(id);
            if (insuree == null)
            {
                return NotFound();
            }
            return View(insuree);
        }

        // POST: Insurees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,HasDui,SpeedingTickets,FullCoverage")] Insuree insuree)
        {
            if (id != insuree.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    insuree.Quote = CalculateQuote(insuree); // 👈 Recalculate the quote here
                    _context.Update(insuree);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsureeExists(insuree.Id))
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
            return View(insuree);
        }


        // GET: Insurees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuree = await _context.Insurees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insuree == null)
            {
                return NotFound();
            }

            return View(insuree);
        }

        // POST: Insurees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var insuree = await _context.Insurees.FindAsync(id);
            if (insuree != null)
            {
                _context.Insurees.Remove(insuree);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsureeExists(int id)
        {
            return _context.Insurees.Any(e => e.Id == id);
        }

        private decimal CalculateQuote(Insuree insuree)
        {
            decimal quote = 50m;

            var dob = insuree.DateOfBirth;
            int age = DateTime.Now.Year - dob.Year;
            if (dob > DateTime.Now.AddYears(-age)) age--;

            if (age <= 18)
                quote += 100;
            else if (age <= 25)
                quote += 50;
            else 
                quote += 25;


            if (insuree.CarYear < 2000 || insuree.CarYear > 2015)
                quote += 25;

            if (!string.IsNullOrEmpty(insuree.CarMake) && insuree.CarMake.ToLower() == "porsche")
            {
                quote += 25;
                if (!string.IsNullOrEmpty(insuree.CarModel) && insuree.CarModel.ToLower() == "911 carrera")
                    quote += 25;
            }

            quote += insuree.SpeedingTickets * 10;

            if (insuree.HasDui)
                quote *= 1.25m;

            if (insuree.FullCoverage)
                quote *= 1.5m;

            return quote;
        }

        // GET: Insurees/Admin
        public async Task<IActionResult> Admin()
        {
            var insurees = await _context.Insurees
                .Select(i => new InsureeQuoteViewModel
                {
                    FirstName = i.FirstName,
                    LastName = i.LastName,
                    EmailAddress = i.EmailAddress,
                    Quote = i.Quote
                })
                .ToListAsync();

            return View(insurees);
        }


    }
}
