using Microsoft.AspNetCore.Mvc;
using Projeto_Event_Plus.Interfaces;
using Projeto_Event_Plus.Domains;

namespace Projeto_Event_Plus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Endpoint  para Listar Todos os Usuario Presentes no Banco de Dados
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Usuario> listaDeUsuarios = _usuarioRepository.Listar();

                return Ok(listaDeUsuarios);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint  para Adicionar Usuario no Banco de Dados
        /// </summary>
        /// <param name="novoUsuario"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post(Usuario novoUsuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(novoUsuario);

                return Created();

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint  para Buscar Usuario um Pelo ID no Banco de Dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                Usuario tipoUsuarioBuscado = _usuarioRepository.BuscarPorID(id);

                return Ok(tipoUsuarioBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        /// <summary>
        /// Endpoint  para Buscar Usuario por Email e Senha no Banco de Dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BuscarPorEmailESenha")]
        public IActionResult Get([FromQuery] string Email, [FromQuery] string Senha)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(Email, Senha);

                return Ok(usuarioBuscado);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
