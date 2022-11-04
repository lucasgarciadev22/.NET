using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETMVC.Context;
using ASPNETMVC.Models;

namespace ASPNETMVC.Controllers
{
  public class ContactController : Controller
  {
    private readonly AgendaContext _context;

    public ContactController(AgendaContext context)
    {
      _context = context;
    }
    public IActionResult Index()
    {
      var contacts = _context.Contacts.ToList();
      return View(contacts);
    }
    //[HttpGet] Create
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create(Contact contact)
    {
      if (ModelState.IsValid)
      {
        _context.Contacts.Add(contact);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));

      }
      return View(contact);
    }

    //[HttpGet] Edit
    public IActionResult Edit(int id)
    {
      var contact = _context.Contacts.Find(id);
      if (contact == null)
      {
        return RedirectToAction(nameof(Index));
      }
      return View(contact);
    }

    [HttpPost]
    public IActionResult Edit(Contact contact)
    {
      var contactToEdit = _context.Contacts.Find(contact.Id);

      contactToEdit.Name = contact.Name;
      contactToEdit.Phone = contact.Phone;
      contactToEdit.Active = contact.Active;

      _context.Contacts.Update(contactToEdit);
      _context.SaveChanges();

      return RedirectToAction(nameof(Index));

    }

    //[HttpGet] Delete
    public IActionResult Details(int id)
    {
      var contact = _context.Contacts.Find(id);

      if (contact==null)
      {
        return RedirectToAction(nameof(Index));
      }

      return View(contact);
    }

    public IActionResult Delete(int id)
    {
      var contact =_context.Contacts.Find(id);

      if (contact==null)
      {
        return RedirectToAction(nameof(Index));
      }
      
      return View(contact);
    }

    [HttpPost]
    public IActionResult Delete(Contact contact)
    {
      var contactToRemove = _context.Contacts.Find(contact.Id);

      _context.Contacts.Remove(contactToRemove);
      _context.SaveChanges();

      return RedirectToAction(nameof(Index));
    }
  }
}