using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFramework.Context;
using EntityFramework.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EntityFramework.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ContactController : ControllerBase
  {
    private readonly AgendaContext _context;
    public ContactController(AgendaContext context)
    {
      _context = context;
    }
    [HttpPost]
    public IActionResult Create(Contact contact)
    {
      _context.Add(contact);
      _context.SaveChanges();
      return CreatedAtAction(nameof(GetById), new {id=contact.Id},contact);
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
      var contact = _context.Contacts.Find(id);
      if (contact == null)
      {
        return NotFound();
      }
      return Ok(contact);
    }

     [HttpGet("GetByName")]
    public IActionResult GetByName(string name)
    {
      var contact = _context.Contacts.Where(x => x.Name.Contains(name));
      if (contact == null)
      {
        return NotFound();
      }
      return Ok(contact);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Contact contact)
    {
      var bankContact = _context.Contacts.Find(id);

      if (bankContact == null)
      {
        return NotFound();
      }

      bankContact.Name = contact.Name;
      bankContact.Phone = contact.Phone;
      bankContact.Active = contact.Active;

      _context.Contacts.Update(bankContact);
      _context.SaveChanges();

      return Ok(bankContact);

    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var bankContact = _context.Contacts.Find(id);

        if (bankContact==null)
        {
            return NotFound();
        }

        _context.Contacts.Remove(bankContact);
        _context.SaveChanges();

        return NoContent();
    }
  }
}