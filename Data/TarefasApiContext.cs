using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace TarefasApi.Data
{
    public class TarefasApiContext: DbContext
    {
        public TarefasApiContext(DbContextOptions<TarefasApiContext> options): base (options)
        {
            
        }

        public DbSet<Categoria> Categorias{get;set;}

        public DbSet<Tarefa> Tarefas {get;set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}