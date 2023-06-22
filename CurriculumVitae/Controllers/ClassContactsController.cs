using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CurriculumVitae.Data;
using CurriculumVitae.Models;

namespace CurriculumVitae.Controllers
{
    public class ClassContactsController : Controller
    {
        private readonly CurriculumVitaeContext _context;

        public ClassContactsController(CurriculumVitaeContext context)
        {
            _context = context;
        }

        // GET: ClassContacts
        public async Task<IActionResult> Index()
        {
              return _context.ClassContact != null ? 
                          View(await _context.ClassContact.ToListAsync()) :
                          Problem("Entity set 'CurriculumVitaeContext.ClassContact'  is null.");
        }

        // GET: ClassContacts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ClassContact == null)
            {
                return NotFound();
            }

            var classContact = await _context.ClassContact
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classContact == null)
            {
                return NotFound();
            }

            return View(classContact);
        }

        // GET: ClassContacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClassContacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Message")] ClassContact classContact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classContact);
        }

        // GET: ClassContacts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ClassContact == null)
            {
                return NotFound();
            }

            var classContact = await _context.ClassContact.FindAsync(id);
            if (classContact == null)
            {
                return NotFound();
            }
            return View(classContact);
        }

        // POST: ClassContacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Email,Message")] ClassContact classContact)
        {
            if (id != classContact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassContactExists(classContact.Id))
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
            return View(classContact);
        }

        // GET: ClassContacts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ClassContact == null)
            {
                return NotFound();
            }

            var classContact = await _context.ClassContact
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classContact == null)
            {
                return NotFound();
            }

            return View(classContact);
        }

        // POST: ClassContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ClassContact == null)
            {
                return Problem("Entity set 'CurriculumVitaeContext.ClassContact'  is null.");
            }
            var classContact = await _context.ClassContact.FindAsync(id);
            if (classContact != null)
            {
                _context.ClassContact.Remove(classContact);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassContactExists(string id)
        {
          return (_context.ClassContact?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
