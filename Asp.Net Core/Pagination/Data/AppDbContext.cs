using Microsoft.EntityFrameworkCore;
using Pagination.Properties.Models;

namespace Pagination.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
            => optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
    }
}