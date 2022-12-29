using ListaTarefas.Models;

namespace ListaTarefas.Repositorio
{
    public interface ITaskRepositorio
    {
        TaskModel RetornaId(int id);
        List<TaskModel> GetTasks();
        TaskModel Adicionar(TaskModel task);
        TaskModel Editar(TaskModel task);
        bool Delete(int id);
    }
}
