using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TarefasApi.Data;

namespace TarefasAPI.Repositories
{
    public class CategoriaRepository
    {
        private readonly TarefasApiContext _contexto;
        public  CategoriaRepository(TarefasApiContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Categoria>> ListarAsync()
        {
            List<Categoria>  retorno = await _contexto.Categorias.ToListAsync();

            return retorno;
        }

        public async Task<Categoria> IncluirAsync(Categoria categoria)
        {
            EntityEntry<Categoria> retorno = await _contexto.Categorias.AddAsync(categoria);
            await _contexto.SaveChangesAsync();

            return retorno.Entity;
        }
    }
    
}