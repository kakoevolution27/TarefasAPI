using Microsoft.EntityFrameworkCore;
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
    }
    
}