using Azure.Data.Tables;
using AzureTables.Models;
using Microsoft.AspNetCore.Mvc;

namespace AzureTables.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ContactsController : ControllerBase
  {
    private readonly string _connectionString;
    private readonly string _tableName;

    public ContactsController(IConfiguration configuration)
    {
      _connectionString = configuration.GetValue<string>("SAConnectionString");
      _tableName = configuration.GetValue<string>("AzureTableName");
    }

    private TableClient GetTableClient()
    {
      var serviceClient = new TableServiceClient(_connectionString);
      var tableClient = serviceClient.GetTableClient(_tableName);

      tableClient.CreateIfNotExists();
      return tableClient;
    }

    [HttpPost("Create")]
    public IActionResult Create(Contact contact)
    {
      var tableClient = GetTableClient();

      contact.RowKey = Guid.NewGuid().ToString();//global unique identifier
      contact.PartitionKey = contact.RowKey;

      tableClient.UpsertEntity(contact);//update if exists or insert new

      return Ok(contact);
    }

    [HttpPut("Update/{id}")]
    public IActionResult Update(string id, Contact contact)
    {
      var tableClient = GetTableClient();//get table ref from azure
      var contactFromTable = tableClient.GetEntity<Contact>(id, id).Value;//get entity from table

      contactFromTable.Name = contact.Name;
      contactFromTable.Email = contact.Email;
      contactFromTable.Phone = contact.Phone;

      tableClient.UpsertEntity(contactFromTable);//update with new entity values

      return Ok();
    }

    [HttpGet("List")]
    public IActionResult GetAll()
    {
      var tableClient = GetTableClient();//get table ref from azure
      var contacts = tableClient.Query<Contact>().ToList();//querry to return entities from azure table
      return Ok(contacts);
    }

    [HttpGet("GetById/{id}")]
    public IActionResult GetById(string id)
    {
      var tableClient = GetTableClient();//get table ref from azure
      var contactFromTable = tableClient.GetEntity<Contact>(id, id).Value;//get entity from table

      return Ok(contactFromTable);
    }

    [HttpGet("GetByName/{name}")]
    public IActionResult GetByName(string name)
    {
      var tableClient = GetTableClient();//get table ref from azure
      var contactFromTable = tableClient.Query<Contact>(x => x.Name == name).ToList();//querry to return entities from azure table

      return Ok(contactFromTable);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
      var tableClient = GetTableClient();//get table ref from azure
      tableClient.DeleteEntity(id,id);

      return NoContent();
    }
  }
}