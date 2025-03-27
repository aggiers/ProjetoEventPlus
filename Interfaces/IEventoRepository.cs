using Projeto_Event_Plus.Domains;

namespace Projeto_Event_Plus.Interfaces
{
    public interface IEventoRepository
    {
        void Atualizar(Guid id, Evento evento);

        void Cadastrar(Evento novoEvento);

        void Deletar(Guid id);

        List<Evento> Listar();

        List<Evento> ListarPorID(Guid id);

        List<Evento> ListarProximosEventos();
    }
}
