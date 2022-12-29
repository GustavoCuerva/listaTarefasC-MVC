using ListaTarefas.Models;
using ListaTarefas.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ListaTarefas.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepositorio _taskRepositorio;
        public TaskController(ITaskRepositorio taskRepositorio)
        {
            _taskRepositorio= taskRepositorio;
        }
        public IActionResult Index()
        {
            List<TaskModel> task = _taskRepositorio.GetTasks();
            return View(task);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            TaskModel task = _taskRepositorio.RetornaId(id);
            ViewBag.task = task;
            return View(task);
        }

        [HttpPost]
        public IActionResult Create(TaskModel task)
        {
            _taskRepositorio.Adicionar(task);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(TaskModel task)
        {
            _taskRepositorio.Editar(task);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Deletar(int id)
        {
            _taskRepositorio.Delete(id);
            return RedirectToAction("Index");
        }
    }
}