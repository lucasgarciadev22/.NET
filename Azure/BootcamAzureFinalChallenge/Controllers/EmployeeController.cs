using Azure.Data.Tables;
using Microsoft.AspNetCore.Mvc;
using AzChallengeDio.Context;
using AzChallengeDio.Models;

namespace AzChallengeDio.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly RHContext _context;
    private readonly string _connectionString;
    private readonly string _tableName;

    public EmployeeController(RHContext context, IConfiguration configuration)
    {
        _context = context;
        _connectionString = configuration.GetValue<string>("ConnectionStrings:SAConnectionString");
        _tableName = configuration.GetValue<string>("ConnectionStrings:AzureTableName");
    }

    private TableClient GetTableClient()
    {
        var serviceClient = new TableServiceClient(_connectionString);
        var tableClient = serviceClient.GetTableClient(_tableName);

        tableClient.CreateIfNotExists();
        return tableClient;
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var employee = _context.Employees.Find(id);

        if (employee == null)
            return NotFound();

        return Ok(employee);
    }

    [HttpPost]
    public IActionResult Create(Employee employee)
    {
        _context.Employees.Add(employee);
        // TODO: Chamar o método SaveChanges do _context para salvar no Banco SQL
        _context.SaveChanges();
        
        var tableClient = GetTableClient();
        var employeeLog = new EmployeeLog(employee, ActionType.Insert, employee.Department, Guid.NewGuid().ToString());

        // TODO: Chamar o método UpsertEntity para salvar no Azure Table
        tableClient.UpsertEntity(employeeLog);
        return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Employee employee)
    {
        var employeeFromDb = _context.Employees.Find(id);

        if (employeeFromDb == null)
            return NotFound();

        employeeFromDb.Name = employee.Name;
        employeeFromDb.Address = employee.Address;
        // TODO: As propriedades estão incompletas
        employeeFromDb.AdmissionDate = employee.AdmissionDate;
        employeeFromDb.Department = employee.Department;
        employeeFromDb.Extension = employee.Extension;
        employeeFromDb.ProfessionalEmail = employee.ProfessionalEmail;
        employeeFromDb.Salary = employee.Salary;
        // TODO: Chamar o método de Update do _context.Funcionarios para salvar no Banco SQL
        _context.Update(employeeFromDb);
        _context.SaveChanges();

        var tableClient = GetTableClient();
        var employeeLog = new EmployeeLog(employeeFromDb, ActionType.Update, employeeFromDb.Department, Guid.NewGuid().ToString());

        // TODO: Chamar o método UpsertEntity para salvar no Azure Table
        tableClient.UpsertEntity(employeeLog);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Deletar(int id)
    {
        var employeeFromDb = _context.Employees.Find(id);

        if (employeeFromDb == null)
            return NotFound();

        // TODO: Chamar o método de Remove do _context.Funcionarios para salvar no Banco SQL
        _context.Remove(employeeFromDb);
        _context.SaveChanges();

        var tableClient = GetTableClient();
        var employeeLog = new EmployeeLog(employeeFromDb, ActionType.Remove, employeeFromDb.Department, Guid.NewGuid().ToString());

        // TODO: Chamar o método UpsertEntity para salvar no Azure Table
        tableClient.UpsertEntity(employeeLog);
        return NoContent();
    }
}
