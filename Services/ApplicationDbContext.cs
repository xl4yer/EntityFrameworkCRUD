using EFCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCrud.Services
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Clients> Clients { get; set; }
    }
}
