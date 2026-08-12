using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TarefasAPI.Repositories;
using TarefasAPI.Services;

namespace TarefasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController(CategoriaService categoriaService): ControllerBase
    {
        
        private readonly CategoriaService categoriaService = categoriaService;


        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> Listar()
        {
            List<Categoria> retorno = await categoriaService.ListarAsync();
            return retorno;
        }

        [HttpPost]
        public async Task<Categoria> IncluirAsync([FromBody]Categoria categoria)
        {
            Categoria retorno = await categoriaService.IncluirAsync(categoria);
            return retorno;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> AlterarAsync(int id, [FromBody] Categoria categoria)
        {
            await categoriaService.AlterarAsync(id,categoria);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> ExcluirAsync (int id)
        {
            await categoriaService.ExcluirAsync(id);
            return NoContent();
        }
    }
}