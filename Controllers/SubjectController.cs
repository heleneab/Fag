using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test_4.Data;
using test_4.Models;

namespace test_4.Controllers;

public class SubjectController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ApplicationDbContext _db;

    public SubjectController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, ApplicationDbContext db)
    {
        _context = context;
        _userManager = userManager;
        _db = db;
    }
    
    public IActionResult Index()
    {
        // Fetch authors from the database
        var userSubjects = _db.UserSubjects.ToList();
        // Send the list to the view. The view declares its model as @model IEnumerable<Author> to match.
        return View(userSubjects);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View(new UserSubject());
    }
   
    [HttpPost]
    public async Task<IActionResult> Add(UserSubject userSubject)
    {
        if (!ModelState.IsValid)
            return View(userSubject);

        var userName = User.Identity.Name;
        userSubject.UserName = userName;
        

        _db.UserSubjects.Add(userSubject);
        _db.SaveChanges();
    
        return RedirectToAction(nameof(Index));
    }
}
