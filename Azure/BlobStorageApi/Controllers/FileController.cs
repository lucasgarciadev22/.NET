using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlobStorageApi.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class FileController : ControllerBase
  {
    private readonly string _connectionString;
    private readonly string _connectionName;

    public FileController(IConfiguration configuration)
    {
      _connectionString = configuration.GetValue<string>("BlobConnectionString");
      _connectionName = configuration.GetValue<string>("BlobContainerName");
    }

    [HttpPost("Upload")]
    public IActionResult UploadFile(IFormFile file)
    {
      BlobContainerClient blobContainer = new BlobContainerClient(_connectionString, _connectionName);//get container object from azure
      BlobClient blobClient = blobContainer.GetBlobClient(file.FileName);//get file object from user file

      using var data = file.OpenReadStream();
      blobClient.Upload(data, new BlobUploadOptions
      {
        HttpHeaders = new BlobHttpHeaders { ContentType = file.ContentType }
      }); // upload file to blob container passing file info and type

      return Ok(blobClient.Uri.ToString());//return uploaded file url
    }

    [HttpGet("Download/{name}")]
    public IActionResult DownloadFile(string name)
    {
      BlobContainerClient blobContainer = new BlobContainerClient(_connectionString, _connectionName);//get container object from azure
      BlobClient blobClient = blobContainer.GetBlobClient(name);//get file object from name

      if (!blobClient.Exists())//if blob file object doesn't exists...
      {
        return BadRequest("Ops... this file doesn't exists");
      }

      var result = blobClient.DownloadContent();
      return File(result.Value.Content.ToArray(), result.Value.Details.ContentType, blobClient.Name);// return new file with file infos and name from azure
    }

    [HttpDelete("Delete/{name}")]
    public IActionResult DeleteFile(string name)
    {
      BlobContainerClient blobContainer = new BlobContainerClient(_connectionString, _connectionName);//get container object from azure
      BlobClient blobClient = blobContainer.GetBlobClient(name);//get file object from name

      var result = blobClient.DeleteIfExists();
      return NoContent();//return empty if file was deleted 
    }

    [HttpGet]
    public IActionResult GetFiles()
    {
      List<BlobDto> blobDtos = new List<BlobDto>();
      BlobContainerClient blobContainer = new BlobContainerClient(_connectionString, _connectionName);

      foreach (var blob in blobContainer.GetBlobs())//getting blobs from container in azure
      {
        blobDtos.Add(new BlobDto
        {
          Name = blob.Name,
          Type = blob.Properties.ContentType,
          Uri = blobContainer.Uri.AbsoluteUri + "/" + blob.Name,
        });
      }

      return Ok(blobDtos);// return blob list
    }
  }
}