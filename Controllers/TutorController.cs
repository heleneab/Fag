using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using test_4.Models;

namespace test_4.Controllers;

[Authorize(Roles = "Admin")]
public class TutorController : Controller
{
   
    private readonly RoleManager<IdentityRole> roleManager;

    public TutorController(RoleManager<IdentityRole> roleManager)
    {
        this.roleManager = roleManager;
    }    
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult AddHours()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Index(ProjectRole role)
    {
        var roleExist = await roleManager.RoleExistsAsync(role.RoleName);
        if (!roleExist)
        {
            var result = await roleManager.CreateAsync(new IdentityRole(role.RoleName));
        }
        return View();
    }
}