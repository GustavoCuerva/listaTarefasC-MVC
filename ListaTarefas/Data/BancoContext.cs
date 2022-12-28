using ListaTarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace ListaTarefas.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options) 
        {
        }
        public DbSet<TaskModel> Tasks { get; set; }
    }
}
