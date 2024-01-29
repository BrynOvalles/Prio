using Microsoft.EntityFrameworkCore;
using Prio.Models;

namespace Prio.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Prioridades> Prioridades { get; set; }
        public DbSet<Sistema> Sistema{ get; set; }
        public DbSet<Tickets> Tickets { get; set; }
    }
}
