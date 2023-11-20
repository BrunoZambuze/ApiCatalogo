using APICatalogo.Domain;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Context
{
    public class ApiCatalogoContext : DbContext
    {
        public ApiCatalogoContext(DbContextOptions<ApiCatalogoContext> options) : base(options)
        {
        }

        //Definir o mapeamento das entidades  nas tabelas
        public DbSet<Categoria>? Categorias { get; set; }
        public DbSet<Produto>? Produtos { get; set; }
    }
}
