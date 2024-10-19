using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShowTracker.Models;  // Ensure this matches your project namespace
using System.Threading.Tasks;
using System.Linq;

namespace ShowTracker.Controllers  // Make sure this matches your project namespace
{
    public class ShowsController : Controller
    {
        private readonly ShowTrackerContext _context;

        // Constructor to inject the DbContext
        public ShowsController(ShowTrackerContext context)
        {
            _context = context;
        }

        // GET: Shows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var show = await _context.Shows.FindAsync(id);
            if (show == null) return NotFound();

            return View(show);
        }

        // POST: Shows/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Show show)
        {
            if (id != show.ShowId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(show);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Shows.Any(e => e.ShowId == id)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(show);
        }

        // GET: Shows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var show = await _context.Shows.FirstOrDefaultAsync(m => m.ShowId == id);
            if (show == null) return NotFound();

            return View(show);
        }

        // POST: Shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var show = await _context.Shows.FindAsync(id);
            if (show == null) return NotFound();

            _context.Shows.Remove(show);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Shows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var show = await _context.Shows.FirstOrDefaultAsync(m => m.ShowId == id);
            if (show == null) return NotFound();

            return View(show);
        }

        // GET: Shows/Index
        public async Task<IActionResult> Index()
        {
            return View(await _context.Shows.ToListAsync());
        }
    }
}
