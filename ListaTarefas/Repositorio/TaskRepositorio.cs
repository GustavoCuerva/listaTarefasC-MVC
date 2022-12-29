using ListaTarefas.Data;
using ListaTarefas.Models;
using Microsoft.EntityFrameworkCore;

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

        public TaskModel RetornaId(int id)
        {
            TaskModel task = _bancoContext.Tasks.FirstOrDefault(t => t.Id == id);
            return task;
        }

        public TaskModel Editar(TaskModel task)
        {
            TaskModel taskDB = RetornaId(task.Id);

            if (taskDB == null) throw new Exception("Tarefa não encontrada");

            taskDB.Title = task.Title;
            taskDB.Description = task.Description;
            taskDB.Date = task.Date;

            _bancoContext.Tasks.Update(taskDB);
            _bancoContext.SaveChanges();

            return taskDB;
        }

        public bool Delete(int id)
        {
            TaskModel taskDB = RetornaId(id);

            if (taskDB == null) throw new Exception("Tarefa não encontrada");

            _bancoContext.Tasks.Remove(taskDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
