using Microsoft.EntityFrameworkCore;
using ServidorAPI.Modelo;

namespace ServidorAPI.Contenido
{
    public class AppDbContext :DbContext
    {
        public DbSet<Plato> Platos => Set<Plato>();
        public AppDbContext(DbContextOptions<AppDbContext> optiones) : base(optiones)
        {
        
        }
    }
}
