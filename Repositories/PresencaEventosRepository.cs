using Projeto_Event_Plus.Context;
using Projeto_Event_Plus.Domains;
using Projeto_Event_Plus.Interfaces;

namespace Projeto_Event_Plus.Repositories
{
    public class PresencaEventosRepository : IPresencaEventosRepository
    {
        private readonly EventPlus_Context _context;

        public PresencaEventosRepository(EventPlus_Context context)
        {
            _context = context;
        }

        public void Atualizar(Guid id, PresencaEvento presencaEventos)
        {
            try
            {
                PresencaEvento presencaEventoBuscado = _context.PresencaEventos.Find(id)!;

                if (presencaEventoBuscado != null)
                {
                    if (presencaEventoBuscado.Situacao)
                    {
                        presencaEventoBuscado.Situacao = false;
                    }
                    else
                    {
                        presencaEventoBuscado.Situacao = true;
                    }
                }
                _context.PresencaEventos.Update(presencaEventoBuscado!);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public PresencaEvento BuscarPorID(Guid id)
        {
            try
            {
                return _context.PresencaEventos
                    .Select(p => new PresencaEvento
                    {
                        IdPresencaEvento = p.IdPresencaEvento,
                        Situacao = p.Situacao,

                        Eventos = new Evento
                        {
                            IdEvento = p.IdEvento!,
                            NomeEvento = p.Eventos.NomeEvento,
                            DataEvento = p.Eventos!.DataEvento,
                            Descricao = p.Eventos.Descricao,

                            Instituicao = new Instituicao
                            {
                                IdInstituicao = p.Eventos.Instituicao!.IdInstituicao,
                                NomeFantasia = p.Eventos.Instituicao!.NomeFantasia
                            }
                        }

                    }).FirstOrDefault(p => p.IdPresencaEvento == id)!;
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
                PresencaEvento presencaEventoBuscado = _context.PresencaEventos.Find(id)!;

                if (presencaEventoBuscado != null)
                {
                    _context.PresencaEventos.Remove(presencaEventoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Inscrever(PresencaEvento inscricao)
        {
            try
            {
                inscricao.IdPresencaEvento = Guid.NewGuid();

                _context.PresencaEventos.Add(inscricao);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PresencaEvento> Listar()
        {
            try
            {
                return _context.PresencaEventos
                    .Select(p => new PresencaEvento
                    {
                        IdPresencaEvento = p.IdPresencaEvento,
                        Situacao = p.Situacao,

                        Eventos = new Evento
                        {
                            IdEvento = p.IdEvento,
                            NomeEvento = p.Eventos.NomeEvento,
                            DataEvento = p.Eventos!.DataEvento,
                            Descricao = p.Eventos.Descricao,

                            Instituicao = new Instituicao
                            {
                                IdInstituicao = p.Eventos.Instituicao!.IdInstituicao,
                                NomeFantasia = p.Eventos.Instituicao!.NomeFantasia
                            }
                        }

                    }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PresencaEvento> ListarMinhas(Guid id)
        {
            return _context.PresencaEventos
                .Select(p => new PresencaEvento
                {
                    IdPresencaEvento = p.IdPresencaEvento,
                    Situacao = p.Situacao,
                    IdUsuario = p.IdUsuario,
                    IdEvento = p.IdEvento,

                    Eventos = new Evento
                    {
                        IdEvento = p.IdEvento,
                        NomeEvento = p.Eventos!.NomeEvento,
                        DataEvento = p.Eventos!.DataEvento,
                        Descricao = p.Eventos!.Descricao,

                        Instituicao = new Instituicao
                        {
                            IdInstituicao = p.Eventos!.IdInstituicao,
                        }
                    }
                })
            .Where(p => p.IdUsuario == id)
            .ToList();
        }
    }
}
