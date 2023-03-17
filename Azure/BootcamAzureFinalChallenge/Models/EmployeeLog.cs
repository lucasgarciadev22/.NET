using System.Text.Json;
using Azure;
using Azure.Data.Tables;

namespace AzChallengeDio.Models
{
    public class EmployeeLog : Employee, ITableEntity
    {
        public EmployeeLog() { }

        public EmployeeLog(Employee employee, ActionType actionType, string partitionKey, string rowKey)
        {
            base.Id = employee.Id;
            base.Name = employee.Name;
            base.Address = employee.Address;
            base.Extension = employee.Extension;
            base.ProfessionalEmail = employee.ProfessionalEmail;
            base.Department = employee.Department;
            base.Salary = employee.Salary;
            base.AdmissionDate = employee.AdmissionDate;
            ActionType = actionType;
            JSON = JsonSerializer.Serialize(employee);
            PartitionKey = partitionKey;
            RowKey = rowKey;
        }

        public ActionType ActionType { get; set; }
        public string JSON { get; set; }
        //Azure Tables Props
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}