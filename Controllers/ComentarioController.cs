using Projeto_Event_Plus.Domains;
using Projeto_Event_Plus.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Azure.AI.ContentSafety;
using Azure;

namespace Projeto_Event_Plus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentarioController : Controller
    {
        private readonly IComentarioRepository _comentarioRepository;
        private readonly ContentSafetyClient _contentSafetyClient;

        public ComentarioController(ContentSafetyClient contentSafetyClient,IComentarioRepository comentarioRepository)
        {
            _comentarioRepository = comentarioRepository;
            _contentSafetyClient = contentSafetyClient;

        }

        [HttpPost]
        public async Task<IActionResult> Post(ComentarioEvento comentario)
        {
            try
            {
                if (string.IsNullOrEmpty(comentario.Descricao))
                {
                    return BadRequest("O texto a ser moderado não pode estar vazio!");
                }

                // criar objeto de análise do content safety
                var request = new AnalyzeTextOptions(comentario.Descricao);

                // chamar a api do content safety
                Response<AnalyzeTextResult> response = await _contentSafetyClient.AnalyzeTextAsync(request);

                // verificar se o texto analisado tem alguma severidade
                bool temConteudoImproprio = response.Value.CategoriesAnalysis.Any(c => c.Severity > 0);

                comentario.Exibe = !temConteudoImproprio;

                _comentarioRepository.Cadastrar(comentario);

                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        } 

        
    }
}
