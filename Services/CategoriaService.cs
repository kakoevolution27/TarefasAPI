using TarefasAPI.Repositories;

namespace TarefasAPI.Services
{
    public class CategoriaService
    {
        private readonly CategoriaRepository _categoriaRepository;
        public CategoriaService(CategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<List<Categoria>> ListarAsync()
        {
            List<Categoria>  retorno = await _categoriaRepository.ListarAsync();

            return retorno;
        }

        public async Task<Categoria> IncluirAsync(Categoria categoria)
        {
            Categoria retorno = await _categoriaRepository.IncluirAsync(categoria);

            return retorno;
        }

        public async Task AlterarAsync(int id, Categoria categoria)
        {
            Categoria? registroNoBanco = await _categoriaRepository.ObterPorId(id);

            if (registroNoBanco is null) throw new KeyNotFoundException("Registro não existe no Banco");

            await _categoriaRepository.AlterarAsync(registroNoBanco, categoria);
        }

        public async Task ExcluirAsync(int id)
        {
            Categoria? registroNoBanco = await _categoriaRepository.ObterPorId(id);

            if (registroNoBanco is null) throw new KeyNotFoundException("Registro não existe no Banco");
            await _categoriaRepository.ExcluirAsync(registroNoBanco);
        }
    }
}