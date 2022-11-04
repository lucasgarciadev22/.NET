# BOOTCAMP 'POTTENCIAL .NET DEVELOPER' FINAL TEST

## USE INSTRUCTIONS
- Make sure you have `.NET6.0` SDK installed:

  - ``dotnet --version``
- Install Entity Framework package:
  - ``dotnet add package Microsoft.EntityFrameworkCore.Design``

  - ``dotnet add package Microsoft.EntityFrameworkCore.SqlServer``
- Remove my migrations and create your own:
  - ``dotnet-ef migrations remove``
  
  - ``dotnet-ef migrations add OrderTable``
- Update your localDB:
  - ``dotnet ef database update``

## THE TEST
- Build a REST API using .Net Core, Java or NodeJs (with Typescript);
- The API must expose a route with swagger documentation (http://.../api-docs).
- The API must have 3 operations:
  1) Register sale: Receives the seller's data + items sold. Registers sale with status "Awaiting payment";
  2) Search for sale: Search for the Id of the sale;
  3) Update sale: Allows the status of the sale to be updated.
     * NOTE: Possible status: `Payment approved` | `Sent to carrier` | `Delivered` | `Cancelled`.
- A sale contains information about the seller who made it, date, order identifier and the items that were sold;
- The seller must have id, cpf, name, e-mail and telephone;
- The inclusion of a sale must have at least 1 item;
- The status update should only allow the following transitions:
  - From: `Awaiting Payment` To: `Payment Approved`
  - From: `Awaiting payment` To: `Cancelled`
  - From: `Payment Approved` To: `Sent to Carrier`
  - From: `Payment Approved` To: `Canceled`
  - From: `Sent to Carrier`. To: `Delivered`
- The API does not need to have authentication/authorization mechanisms;
- The application does not need to implement the persistence mechanisms in a database, they can be persisted "in memory".
