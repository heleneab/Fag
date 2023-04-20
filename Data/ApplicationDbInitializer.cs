using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Identity;
using test_4.Models;

namespace test_4.Data
{
    public class ApplicationDbInitializer
    {
        public static void Initialize(ApplicationDbContext db, UserManager<ApplicationUser> um, RoleManager<IdentityRole> rm)
        {
            // Delete the database before we initialize it. This is common to do during development.
            db.Database.EnsureDeleted();

            // Recreate the database and tables according to our models
            db.Database.EnsureCreated();


            // Lag roller
            var adminRole = new IdentityRole("Admin");
            rm.CreateAsync(adminRole).Wait(); //venter til den er ferdig med å opprette rollen før den kjører

            // Add standard users
            var admin = new ApplicationUser
                { UserName = "admin@uia.no", Email = "admin@uia.no", Name = "Admin User",  EmailConfirmed = true};
            
            var user = new ApplicationUser
                { UserName = "user@uia.no", Email = "user@uia.no", Name = "user", EmailConfirmed = true };
            
            // sett passord
            um.CreateAsync(admin, "Password1.").Wait();
            um.CreateAsync(user, "Password1.").Wait();
            
            // gi bruker rolle admin
            um.AddToRoleAsync(admin, "Admin").Wait();


            db.SaveChanges();
            
            //hvis comments enabled:
            //publicKey ApplicationUser User { get; set; }
        }
    }
}