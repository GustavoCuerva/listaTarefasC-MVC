using ListaTarefas.Models;

namespace ListaTarefas.Repositorio
{
    public interface ITaskRepositorio
    {
        List<TaskModel> GetTasks();
        TaskModel Adicionar(TaskModel task);
    }
}
