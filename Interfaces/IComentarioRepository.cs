using Projeto_Event_Plus.Domains;

namespace Projeto_Event_Plus.Interfaces
{
    public interface IComentarioRepository
    {
        void Cadastrar(ComentarioEvento comentario);

        void Deletar(Guid id);

        List<ComentarioEvento> Listar(Guid id);

        ComentarioEvento BuscarPorIdUsuario(Guid idUsuario, Guid idEvento);
    }
}
