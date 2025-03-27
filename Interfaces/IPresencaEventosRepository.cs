using Projeto_Event_Plus.Domains;

namespace Projeto_Event_Plus.Interfaces
{
    public interface IPresencaEventosRepository
    {
        void Deletar(Guid id);

        List<PresencaEvento> Listar();

        PresencaEvento BuscarPorID(Guid id);

        void Atualizar(Guid id, PresencaEvento presencaEventos);

        List<PresencaEvento> ListarMinhas(Guid id);

        void Inscrever(PresencaEvento evento);
    }
}
