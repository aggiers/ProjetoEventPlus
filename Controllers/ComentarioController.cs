using Projeto_Event_Plus.Domains;
using Projeto_Event_Plus.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Projeto_Event_Plus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentarioController : Controller
    {
        private readonly IComentarioRepository _comentarioRepository;

        public ComentarioController(IComentarioRepository comentarioRepository)
        {
            _comentarioRepository = comentarioRepository;

        }

        /// <summary>
        /// Endpoint para cadastrar Comentarios
        /// </summary>
        /// <param name="novoComentario"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(ComentarioEvento novoComentario)
        {
            try
            {
                _comentarioRepository.Cadastrar(novoComentario);
                return Created();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Endpoint para listar Comentarios
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                List<ComentarioEvento> listaDeComentarios = _comentarioRepository.Listar(id);

                return Ok(listaDeComentarios);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint para deletar Comentarios
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _comentarioRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Endpoint para buscar Comentarios por Id dos usuarios
        /// </summary>
        /// <param name="UsuarioId"></param>
        /// <param name="EventoId"></param>
        /// <returns></returns>
        [HttpGet("BuscarPorIdUsuario/{UsuarioId},{EventoId}")]
        public IActionResult GetById(Guid UsuarioId, Guid EventoId)
        {
            try
            {
                ComentarioEvento novoFeedback = _comentarioRepository.BuscarPorIdUsuario(UsuarioId, EventoId);
                return Ok(novoFeedback);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }
    }
}
