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

        public async Task AlterarAsync(int id, Categoria categoria)
        {
            Categoria? registroNoBanco = await ObterPorId(id);

            if (registroNoBanco is null) throw new KeyNotFoundException("Registro não existe no Banco");

            _contexto.Entry(registroNoBanco).CurrentValues.SetValues(categoria);

            await _contexto.SaveChangesAsync();
        }

        public async Task<Categoria?> ObterPorId(int id)
        {
            Categoria? retorno = await _contexto.Categorias.FindAsync(id);

            return retorno;
        }

        internal async Task ExcluirAsync(int id)
        {
            Categoria? registroNoBanco = await ObterPorId(id);

            if (registroNoBanco is null) throw new KeyNotFoundException("Registro não existe no Banco");
            
            _contexto.Categorias.Remove(registroNoBanco);

            await _contexto.SaveChangesAsync();
        }
    }
    
}