using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.DataAccessLayer
{
    public class WebApiDbContext : DbContext
    {
        public WebApiDbContext(DbContextOptions options) : base(options)
            {

            }
    public DbSet<Product> Products { get; set; }
    }
}
