using ListaTarefas.Data;
using ListaTarefas.Models;

namespace ListaTarefas.Repositorio
{
    public class TaskRepositorio : ITaskRepositorio
    {
        private BancoContext _bancoContext;
        public TaskRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<TaskModel> GetTasks()
        {
            return _bancoContext.Tasks.ToList();
        }

        public TaskModel Adicionar(TaskModel task)
        {
            _bancoContext.Add(task);
            _bancoContext.SaveChanges();

            return task;
        }
    }
}
