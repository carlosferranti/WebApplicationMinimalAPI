using Microsoft.EntityFrameworkCore;
using WebApplicationMinimalAPI.Model;

namespace WebApplicationMinimalAPI.Contexto
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) => Database.EnsureCreated();

        public DbSet<Categoria> Categoria { get; set; }

    }
}
