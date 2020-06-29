using Microsoft.EntityFrameworkCore;
using ProAgil.WebApi.Model;

namespace ProAgil.WebApi.Data
{
    public class ProAgilContext: DbContext
    {
        public ProAgilContext(DbContextOptions<ProAgilContext> options) : base(options) { }

        public DbSet<Evento> Eventos { get; set; }
    }
}
