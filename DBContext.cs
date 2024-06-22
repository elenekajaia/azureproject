using ApiProjekt.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiProjekt.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProstyModel> ProstyModels { get; set; }
    }
}