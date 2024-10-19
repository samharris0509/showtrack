using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShowTracker.Models;
using System.Threading.Tasks;

public class ShowsController : Controller
{
    private readonly ShowTrackerContext _context;

    public ShowsController(ShowTrackerContext context)
    {
        _context = context;
    }

    // GET: Shows/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Shows/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Show show)
    {
        if (ModelState.IsValid)
        {
            _context.Add(show);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));  // Redirect to Index action
        }
        return View(show);  // Return form if validation fails
    }

    // GET: Shows/Index
    public async Task<IActionResult> Index()
    {
        var shows = await _context.Shows.ToListAsync();
        return View(shows);
    }
}
