using Projeto_Event_Plus.Domains;
using Microsoft.EntityFrameworkCore;

namespace Projeto_Event_Plus.Context
{
    public class EventPlus_Context : DbContext
    {
        public EventPlus_Context()
        {
        }

        public EventPlus_Context(DbContextOptions<EventPlus_Context> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<PresencaEvento> PresencaEventos { get; set; }
        public DbSet<ComentarioEvento> ComentarioEventos { get; set; }
        public DbSet<Instituicao> Instituicao { get; set; }
        public DbSet<TipoUsuario> TiposUsuario { get; set; }
        public DbSet<TipoEvento> TiposEvento {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-U8LA1O3\\SQLEXPRESS ; Database=EventPlus ; User ID=sa ; Password=Senai@134 ; TrustServerCertificate=true");
            }
        }
    }
}
