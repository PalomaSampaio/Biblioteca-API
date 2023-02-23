using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Livros> CadastroLivros { get; set; }
    }
}
