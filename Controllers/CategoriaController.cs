using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TarefasAPI.Repositories;
using TarefasAPI.Services;

namespace TarefasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaService _categoriaService;

        public CategoriaController(CategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> Listar()
        {
            try
            {
                List<Categoria> retorno = await _categoriaService.ListarAsync();
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> IncluirAsync([FromBody]Categoria categoria)
        {
            try
            {
                Categoria retorno = await _categoriaService.IncluirAsync(categoria);
                return Created(String.Empty,retorno);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
            
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> AlterarAsync(int id, [FromBody] Categoria categoria)
        {
            try
            {
                await _categoriaService.AlterarAsync(id,categoria);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> ExcluirAsync (int id)
        {
            try
            {
                await _categoriaService.ExcluirAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            
        }
    }
}