using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Context;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Controllers
{
  [ApiController]
  [Produces("application/json")]
  [Consumes("application/json")]
  [Route("[controller]")]
  public class SellerController : ControllerBase
  {
    private readonly OrderContext _context;

    public SellerController(OrderContext context)
    {
      _context = context;
    }
    /// <summary>
    /// Registra um novo vendedor no banco de dados.
    /// </summary>
    /// <param nameof="Seller to Register"></param>
    /// <returns>Um novo vendedor registrado</returns>
    /// <remarks>
    ///   Exemplo de requisição (parâmetros obrigatórios):                                                                                 
    ///   Id -> auto incrementado pelo SQL.                                                                                  
    ///
    ///     POST /Seller
    ///     {
    ///        "cpf": "555555888-88", 
    ///     }
    /// </remarks>
    /// <response code="201">Se o vendedor foi registrado com sucesso</response>
    /// <response code="400">Se as credenciais estiverem erradas</response>
    /// <response code="404">Se o vendedor não for encontrado</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult RegisterSeller(Seller seller)
    {
      _context.Add(seller);
      _context.SaveChanges();

      return CreatedAtAction(nameof(GetSellerById), new { id = seller.Id }, seller);
    }
    /// <summary>
    /// Busca um vendedor de acordo com o Id fornecido.
    /// </summary>
    /// <param nameof="Seller to Find"></param>
    /// <returns></returns>
    /// <remarks>
    ///   Exemplo de requisição (parâmetros obrigatórios):         
    ///
    ///     GET /Seller
    ///     {
    ///        "id": 1,
    ///     }
    /// </remarks>
    /// <response code="200">Se a requisição retornar um vendedor</response>
    /// <response code="404">Se a ordem não for encontrada</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetSellerById(int id)
    {
      var seller = _context.Sellers.Find(id);
      if (seller == null)
      {
        return NotFound();
      }
      return Ok(seller);
    }
    /// <summary>
    /// Atualiza as informações de um vendedor previamente registrado.
    /// </summary>
    /// <param nameof="Seller to Update"></param>
    /// <returns>Informações do vendedor atualizadas</returns>
    /// <remarks>
    ///   Exemplo de requisição (parâmetros obrigatórios):         
    ///
    ///     PUT /Seller
    ///     {
    ///        "id": 1,
    ///     }
    /// </remarks>
    /// <response code="200">Se a requisição atualizar o vendedor com sucesso</response>
    /// <response code="404">Se o vendedor não for encontrado</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult EditSellerInfo(int id, Seller seller)
    {
      var sellerToEdit = _context.Sellers.Find(id);

      if (sellerToEdit == null)
      {
        return NotFound("Vendedor não encontrado, registre-o primeiro.");
      }

      sellerToEdit.Cpf = seller.Cpf;
      sellerToEdit.Name = seller.Name;
      sellerToEdit.Email = seller.Email;
      sellerToEdit.Phone = seller.Phone;

      _context.Sellers.Update(sellerToEdit);
      _context.SaveChanges();

      return Ok($"Dados do vendedor {sellerToEdit.Name} foram alterados.");
    }
    /// <summary>
    /// Remove um vendedor do banco de dados de acordo com o Id fornecido.
    /// </summary>
    /// <param nameof="Seller to Delete"></param>
    /// <returns>Informa qual vendedor foi removido</returns>
    /// <remarks>
    ///   Exemplo de requisição (parâmetros obrigatórios):         
    ///
    ///     PUT /Seller
    ///     {
    ///        "id": 1,
    ///     }
    /// </remarks>
    /// <response code="200">Se a requisição remover o vendedor com sucesso</response>
    /// <response code="404">Se o vendedor não for encontrado</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteSellerInfo(int id, Seller seller)
    {
      var sellerToDelete = _context.Sellers.Find(id);

      if (sellerToDelete == null)
      {
        return NotFound("Vendedor não encontrado, registre-o primeiro.");
      }

      _context.Sellers.Remove(sellerToDelete);
      _context.SaveChanges();

      return Ok($"Dados do vendedor {sellerToDelete.Name} foram removidos.");
    }
  }
}