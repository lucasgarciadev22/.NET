using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskAgendaWithEntity.Context;
using TaskAgendaWithEntity.Models;

namespace TaskAgendaWithEntity.Controllers
{
  public class TaskController : Controller
  {
    private readonly TaskAgendaContext _context;

    public TaskController(TaskAgendaContext context)
    {
      _context = context;
    }
    public IActionResult Index()
    {
      var tasks = _context.Tasks.ToList();
      return View(tasks);
    }
    //[HttpGet] Create
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create(TaskModel task)
    {
      if (ModelState.IsValid)
      {
        _context.Tasks.Add(task);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));

      }
      return View(task);
    }

    //[HttpGet] Edit
    public IActionResult Edit(int id)
    {
      var task = _context.Tasks.Find(id);
      if (task == null)
      {
        return RedirectToAction(nameof(Index));
      }
      return View(task);
    }

    [HttpPost]
    public IActionResult Edit(TaskModel task)
    {
      var taskToEdit = _context.Tasks.Find(task.Id);

      taskToEdit.Title = task.Title;
      taskToEdit.Description = task.Description;
      taskToEdit.Date = task.Date;
      taskToEdit.Status = task.Status;

      _context.Tasks.Update(taskToEdit);
      _context.SaveChanges();

      return RedirectToAction(nameof(Index));
    }

    //[HttpGet] Delete
    public IActionResult Details(int id)
    {
      var task = _context.Tasks.Find(id);

      if (task == null)
      {
        return RedirectToAction(nameof(Index));
      }

      return View(task);
    }

    public IActionResult Delete(int id)
    {
      var task = _context.Tasks.Find(id);

      if (task == null)
      {
        return RedirectToAction(nameof(Index));
      }

      return View(task);
    }

    [HttpPost]
    public IActionResult Delete(TaskModel task)
    {
      var taskToDelete = _context.Tasks.Find(task.Id);

      _context.Tasks.Remove(taskToDelete);
      _context.SaveChanges();

      return RedirectToAction(nameof(Index));
    }
  }
}