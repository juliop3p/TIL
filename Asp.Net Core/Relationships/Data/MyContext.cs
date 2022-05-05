using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace Relationships.Data
{
    public class MyContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }
    }
}