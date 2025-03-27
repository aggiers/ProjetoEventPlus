using Projeto_Event_Plus.Domains;
using Projeto_Event_Plus.Interfaces;
using Projeto_Event_Plus.Utils;
using Projeto_Event_Plus.Context;

namespace Projeto_Event_Plus.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EventPlus_Context _context;

        public UsuarioRepository(EventPlus_Context context)
        {
            _context = context;
        }

        public Usuario BuscarPorEmailESenha(string Email, string Senha)
        {
            try
            {
                Usuario usuarioBuscado = _context.Usuarios.FirstOrDefault(u => u.Email == Email)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(Senha, usuarioBuscado.Senha!);

                    if (confere)
                    {
                        return usuarioBuscado;
                    }
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario BuscarPorID(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _context.Usuarios.Find(id)!;

                if (usuarioBuscado != null)
                {
                    return usuarioBuscado;
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            try
            {
                novoUsuario.Senha = Criptografia.GerarHash(novoUsuario.Senha!);

                _context.Usuarios.Add(novoUsuario);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Usuario> Listar()
        {
            List<Usuario> listaUsuario = _context.Usuarios.ToList();
            return listaUsuario;
        }
    }
}
