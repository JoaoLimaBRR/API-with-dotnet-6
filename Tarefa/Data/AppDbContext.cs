using Microsoft.EntityFrameworkCore;
using Tarefa.Model;

namespace Tarefa.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TarefaModel> Tarefas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Datasource=app.db;Cache=Shared");


    }
}
