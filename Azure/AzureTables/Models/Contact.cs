using Azure;
using Azure.Data.Tables;

namespace AzureTables.Models
{
  public class Contact : ITableEntity
  {
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    //Azure Properties
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }

    public Contact()
    {
        PartitionKey = Guid.NewGuid().ToString();
        RowKey = Guid.NewGuid().ToString();
    }
  }
}
