using Microsoft.EntityFrameworkCore;
using PrjAPILembretes.Entities;


namespace PrjAPILembretes.Context

{
    public class AppLembretesContext : DbContext //Herdar de DBContext para informar que esta classe representará o DB
    {
        public AppLembretesContext(DbContextOptions<AppLembretesContext> options) : base(options)
        {
        }
        public DbSet<Lembrete> Lembretes { get; set; } //rerpesentando uma tabela no BD
        //DbSet - o tipo do banco
        //<Lembrete> - É a classe/objeto criado no Entities
    }
}
