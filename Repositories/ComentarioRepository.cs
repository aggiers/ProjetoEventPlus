using Projeto_Event_Plus.Context;
using Projeto_Event_Plus.Domains;
using Projeto_Event_Plus.Interfaces;

namespace Projeto_Event_Plus.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly EventPlus_Context _context;

        public ComentarioRepository(EventPlus_Context context)
        {
            _context = context;
        }

        public void Cadastrar(ComentarioEvento comentarioEvento)
        {
            try
            {
                _context.ComentarioEventos.Add(comentarioEvento);

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
                ComentarioEvento comentarioEventoBuscado = _context.ComentarioEventos.Find(id)!;

                if (comentarioEventoBuscado != null)
                {
                    _context.ComentarioEventos.Remove(comentarioEventoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        ComentarioEvento IComentarioRepository.BuscarPorIdUsuario(Guid idUsuario, Guid idEvento)
        {
            try
            {
                return _context.ComentarioEventos
                    .Select(c => new ComentarioEvento
                    {
                        IdComentarioEvento = c.IdComentarioEvento,
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        IdUsuario = c.IdUsuario,
                        IdEvento = c.IdEvento,

                        Usuarios = new Usuario
                        {
                            Nome = c.Usuarios!.Nome
                        },

                        Eventos = new Evento
                        {
                            NomeEvento = c.Eventos!.NomeEvento,
                        }

                    }).FirstOrDefault(c => c.IdUsuario == idUsuario && c.IdUsuario == idEvento)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        List<ComentarioEvento> IComentarioRepository.Listar(Guid id)
        {
            try
            {
                return _context.ComentarioEventos
                    .Select(c => new ComentarioEvento
                    {
                        IdComentarioEvento = c.IdComentarioEvento,
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        IdUsuario = c.IdUsuario,
                        IdEvento = c.IdEvento,

                        Usuarios = new Usuario
                        {
                            Nome = c.Usuarios!.Nome
                        },

                        Eventos = new Evento
                        {
                            NomeEvento = c.Eventos!.NomeEvento,
                        }

                    }).Where(c => c.IdEvento == id).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ComentarioEvento> ListarSomenteExibe(Guid id)
        {
            try
            {
                return _context.ComentarioEventos
                    .Select(c => new ComentarioEvento
                    {
                        IdComentarioEvento = c.IdComentarioEvento,
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        IdUsuario = c.IdUsuario,
                        IdEvento = c.IdEvento,

                        Usuarios = new Usuario
                        {
                            Nome = c.Usuarios!.Nome
                        },

                        Eventos = new Evento
                        {
                            NomeEvento = c.Eventos!.NomeEvento,
                        }

                    }).Where(c => c.Exibe == true && c.IdEvento == id).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
