using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MVC_APP.Models;


namespace MVC_APP.Data
{
    public class MVCAppDbContext : IdentityDbContext<MVCAppUser>
    {
        public MVCAppDbContext(DbContextOptions<MVCAppDbContext> options) : base(options) 
        {
        }
        public DbSet<MVC_APP.Models.ProductViewModel> ProductViewModel { get; set; } = default!;
    }
}
