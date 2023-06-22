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
    public class ExamScoresController : Controller
    {
        private readonly CurriculumVitaeContext _context;

        public ExamScoresController(CurriculumVitaeContext context)
        {
            _context = context;
        }
       
       

        // GET: ExamScores
        public async Task<IActionResult> Index(string searchString)
        {
            var examScores= from m in _context.ExamScore
                           select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                examScores = examScores.Where(s => s.Id!.Contains(searchString));
            }
            return View(await examScores.ToListAsync());
        }

        // GET: ExamScores/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ExamScore == null)
            {
                return NotFound();
            }

            var examScore = await _context.ExamScore
                .FirstOrDefaultAsync(m => m.Id == id);
            if (examScore == null)
            {
                return NotFound();
            }

            return View(examScore);
        }

        // GET: ExamScores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExamScores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Subject,TeacherName,OralExam,FifteenMinScore,MidtermExam,FinalExam,ToltalScore,ReviewAndEvaluation,AcademicReview,ConductComments")] ExamScore examScore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(examScore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(examScore);
        }

        // GET: ExamScores/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ExamScore == null)
            {
                return NotFound();
            }

            var examScore = await _context.ExamScore.FindAsync(id);
            if (examScore == null)
            {
                return NotFound();
            }
            return View(examScore);
        }

        // POST: ExamScores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Subject,TeacherName,OralExam,FifteenMinScore,MidtermExam,FinalExam,ToltalScore,ReviewAndEvaluation,AcademicReview,ConductComments")] ExamScore examScore)
        {
            if (id != examScore.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(examScore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamScoreExists(examScore.Id))
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
            return View(examScore);
        }


        // GET: ExamScores/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ExamScore == null)
            {
                return NotFound();
            }

            var examScore = await _context.ExamScore
                .FirstOrDefaultAsync(m => m.Id == id);
            if (examScore == null)
            {
                return NotFound();
            }

            return View(examScore);
        }

        // POST: ExamScores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ExamScore == null)
            {
                return Problem("Entity set 'CurriculumVitaeContext.ExamScore'  is null.");
            }
            var examScore = await _context.ExamScore.FindAsync(id);
            if (examScore != null)
            {
                _context.ExamScore.Remove(examScore);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExamScoreExists(string id)
        {
          return (_context.ExamScore?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
