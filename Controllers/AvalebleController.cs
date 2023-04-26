using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Example.Models;
using Microsoft.AspNetCore.Identity;
using test_4.Data;
using test_4.Models;

namespace Example.Controllers;

public class AvalebleController : Controller
{
    // Added private field for the application db context
    private readonly ApplicationDbContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    // Constructor with db context as a parameter
    public AvalebleController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
    {
        _userManager = userManager;
        _db = db;
    }

    // GET
    public IActionResult Index()
    {
        // Fetch authors from the database
        var avalebles = _db.Avalebles.ToList();
        // Send the list to the view. The view declares its model as @model IEnumerable<Author> to match.
        return View(avalebles);
    }
    


    [HttpGet]
    public IActionResult Add()
    {
        return View(new Avaleble());
    }
    
    [HttpPost]
    public async Task<IActionResult> Add(Avaleble avaleble)
    {
        if (!ModelState.IsValid)
            return View(avaleble);

        var userName = User.Identity.Name;
        avaleble.User = userName;
        

        _db.Avalebles.Add(avaleble);
        _db.SaveChanges();
    
        return RedirectToAction(nameof(Index));
    }

    
 /*   [HttpPost]
    public async Task<IActionResult> Add(Avaleble avaleble)
    {
        if (!ModelState.IsValid)
            return View(avaleble);

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        avaleble.UserId = userId;

        _db.Avalebles.Add(avaleble);
        _db.SaveChanges();
    
        return RedirectToAction(nameof(Index));
    }*/


    
   /* [HttpPost]
    public IActionResult Add(Avaleble avaleble)
    {
        if (!ModelState.IsValid)
            return View(avaleble);
        
        avaleble.User = User.Identity;


        _db.Avalebles.Add(avaleble);
        _db.SaveChanges();
        
        return RedirectToAction(nameof(Index));
    }*/
}