using BikesByBDEGLR.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NTTBikes.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public virtual DbSet<Bike> Bikes { get; set; }
        public virtual DbSet<BikeStation> BikeStations { get; set; }

    }
}
