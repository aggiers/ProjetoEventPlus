using Microsoft.AspNetCore.Mvc;
using Projeto_Event_Plus.Domains;
using Projeto_Event_Plus.Interfaces;

namespace Projeto_Event_Plus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TipoEventoController : Controller
    {
        private readonly ITipoEventoRepository _tipoEventoRepository;

        public TipoEventoController(ITipoEventoRepository tipoEventoRepository)
        {
            _tipoEventoRepository = tipoEventoRepository;
        }

        /// <summary>
        /// Endpoint  para Listar Todos os TiposEventos no Banco de Dados
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<TipoEvento> listaDeTipos = _tipoEventoRepository.Listar();

                return Ok(listaDeTipos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint  para Adicionar um TipoEvento no Banco de Dados
        /// </summary>
        /// <param name="novoTipoEvento"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(TipoEvento novoTipoEvento)
        {
            try
            {
                _tipoEventoRepository.Cadastrar(novoTipoEvento);

                return Created();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint  para Deletar um TipoEvento no Banco de Dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Deletar(Guid id)
        {
            try
            {
                _tipoEventoRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Endpoint  para Atualizar Um TipoEvento Pelo Seu Id
        /// </summary>
        /// <param name="tipoEvento"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, TipoEvento tipoEvento)
        {
            try
            {
                _tipoEventoRepository.Atualizar(id, tipoEvento);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint  para Buscar um TipoEvento Pelo Seu Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                TipoEvento tipoEventoBuscado = _tipoEventoRepository.BuscarPorId(id);

                return Ok(tipoEventoBuscado);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
