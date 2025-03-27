using Projeto_Event_Plus.Context;
using Projeto_Event_Plus.Domains;
using Projeto_Event_Plus.Interfaces;

namespace Projeto_Event_Plus.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly EventPlus_Context _context;

        public EventoRepository(EventPlus_Context context)
        {
            _context = context;
        }

        public void Atualizar(Guid id, Evento evento)
        {
            try
            {
                Evento eventoBuscado = _context.Eventos.Find(id)!;

                if (eventoBuscado != null)
                {
                    eventoBuscado.NomeEvento = evento.NomeEvento;
                    eventoBuscado.DataEvento = evento.DataEvento;
                    eventoBuscado.Descricao = evento.Descricao;
                    eventoBuscado.IdTipoEvento = evento.IdTipoEvento;
                }

                _context.Eventos.Update(eventoBuscado!);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Evento novoEvento)
        {
            try
            {
                // Verifica se a data do evento é maior que a data atual
                if (novoEvento.DataEvento < DateTime.Now)
                {
                    throw new ArgumentException("A data do evento deve ser maior ou igual a data atual.");
                }

                novoEvento.IdEvento = Guid.NewGuid();

                _context.Eventos.Add(novoEvento);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Evento eventoBuscado = _context.Eventos.Find(id)!;

                if (eventoBuscado != null)
                {
                    _context.Eventos.Remove(eventoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Evento> Listar()
        {
            try
            {
                return _context.Eventos
                    .Select(e => new Evento
                    {
                        IdEvento = e.IdEvento,
                        NomeEvento = e.NomeEvento,
                        DataEvento = e.DataEvento,
                        Descricao = e.Descricao,
                        IdTipoEvento = e.IdTipoEvento,
                        TiposEvento = new TipoEvento
                        {
                            IdTipoEvento = e.IdTipoEvento,
                            TituloTipoEvento = e.TiposEvento!.TituloTipoEvento
                        },
                        IdInstituicao = e.IdInstituicao,
                        Instituicao = new Instituicao
                        {
                            IdInstituicao = e.IdInstituicao,
                            NomeFantasia = e.Instituicao!.NomeFantasia
                        }
                    }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Evento> ListarPorID(Guid id)
        {
            try
            {
                List<Evento> listaEvento = _context.Eventos.Where(p => p.IdEvento == id).ToList();
                return listaEvento;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Evento> ListarProximosEventos()
        {
            try
            {
                return _context.Eventos
                    .Select(e => new Evento
                    {
                        IdEvento = e.IdEvento,
                        NomeEvento = e.NomeEvento,
                        Descricao = e.Descricao,
                        DataEvento = e.DataEvento,
                        IdTipoEvento = e.IdTipoEvento,
                        TiposEvento = new TipoEvento
                        {
                            IdTipoEvento = e.IdTipoEvento,
                            TituloTipoEvento = e.TiposEvento!.TituloTipoEvento
                        },
                        IdInstituicao = e.IdInstituicao,
                        Instituicao = new Instituicao
                        {
                            IdInstituicao = e.IdInstituicao,
                            NomeFantasia = e.Instituicao!.NomeFantasia
                        }

                    })
                    .Where(e => e.DataEvento >= DateTime.Now)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}