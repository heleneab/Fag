using Example.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using test_4.Models;

namespace test_4.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Avaleble> Avalebles=> Set<Avaleble>();

    public DbSet<UserSubject> UserSubjects => Set<UserSubject>();

}
