using Microsoft.EntityFrameworkCore;
using ProdutosApi.Model;

namespace ProdutosApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Produtos> Produtos { set; get; }
        public DbSet<Compra> Categories { set; get; }
        public DbSet<Cartao> Cartoes { set; get; }
    }
}