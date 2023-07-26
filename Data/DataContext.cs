using Microsoft.EntityFrameworkCore;
using RazorPagesToDo.Models;

namespace RazorPagesToDo.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>().ToTable("Tickets");
        }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketFile> TicketFiles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
