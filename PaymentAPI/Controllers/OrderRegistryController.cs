using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Context;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  [Produces("application/json")]
  [Consumes("application/json")]
  public class OrderRegistryController : ControllerBase
  {
    private readonly OrderContext _context;

    public OrderRegistryController(OrderContext context)
    {
      _context = context;
    }

    /// <summary>
    /// Registra a ordem de compra se o vendedor estiver registrado.
    /// </summary>
    /// <param nameof="Order to Register"></param>
    /// <returns>Uma nova ordem de compra gerada</returns>
    /// <remarks>
    ///   Exemplo de requisição (parâmetros obrigatórios):         
    ///
    ///     POST /OrderRegistry
    ///     {
    ///        "sellerId": 0,
    ///        "sellerCpf": "888558496-88",
    ///        "orderNumber": "89844898",
    ///        "orderProducts": "#Item 1 (min. 1 item)",
    ///     }
    /// </remarks>
    /// <response code="201">Se a ordem foi criada com sucesso</response>
    /// <response code="400">Se as credenciais estiverem erradas</response>
    /// <response code="404">Se a ordem não for encontrada</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult CreateOrderRegistry(OrderRegistry orderRegistry)
    {
      var registeredSeller = _context.Sellers.Find(orderRegistry.SellerId);
      if (registeredSeller == null)
      {
        return NotFound("O vendedor não existe, registre-o primeiro.");
      }
      if (registeredSeller.Cpf != orderRegistry.SellerCpf)
      {
        return BadRequest("O CPF do vendedor está errado, verifique e tente novamente.");
      }
      orderRegistry.StatusMessage = StatusMessage.ShowStatusMessage(OrderStatus.Awaiting);
      if (orderRegistry.OrderProducts == "" || orderRegistry.OrderProducts == string.Empty)
      {
        return BadRequest("Uma ordem de compra deve possuir pelo menos 1 produto");
      }
      _context.Add(orderRegistry);
      _context.SaveChanges();

      return CreatedAtAction(nameof(GetOrderRegistryById), new { id = orderRegistry.Id }, orderRegistry);
    }

    /// <summary>
    /// Busca uma ordem de compra de acordo com o Id fornecido.
    /// </summary>
    /// <param nameof="Order Id to Find"></param>
    /// <returns>Uma ordem de compra encontrada</returns>
    /// <remarks>
    ///   Exemplo de requisição (parâmetros obrigatórios):         
    ///
    ///     GET /OrderRegistry
    ///     {
    ///        "id": 1,
    ///     }
    /// </remarks>
    /// <response code="200">Se a requisição retornar uma ordem</response>
    /// <response code="404">Se a ordem não for encontrada</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetOrderRegistryById(int id)
    {
      var orderRegistry = _context.OrderRegistries.Find(id);
      if (orderRegistry == null)
      {
        return NotFound("Ordem de compra não encontrada, verifique os dados e tente novamente.");
      }
      return Ok(orderRegistry);
    }

    /// <summary>
    /// Atualiza o status da ordem de compra de acordo com o fluxo de operação.
    /// </summary>
    /// <param nameof="Order Id to Update"></param>
    /// <returns>A ordem de compra atualizada</returns>
    /// <remarks>
    ///   Exemplo de requisição (parâmetros obrigatórios):
    ///   OrderStatus -> 0: Aguardando pagamento, 1: Pagamento aprovado, 2: Enviado para transportadora, 3: Entregue, 4: Cancelada, 5: Não permitido              
    ///
    ///     PUT /OrderRegistry
    ///     {
    ///        "id": 0,
    ///        "orderStatus": 0  (de acordo com enum),
    ///     }
    /// </remarks>
    /// <response code="200">Se a ordem for atualizada com sucesso</response>
    /// <response code="400">Se as credenciais estiverem erradas</response>
    /// <response code="404">Se a ordem não for encontrada</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult EditOrderRegistry(int id, OrderStatus newStatus)
    {
      var orderRegistryToEdit = _context.OrderRegistries.Find(id);
      if (orderRegistryToEdit == null)
      {
        return NotFound();
      }
      OrderStatus oldStatus = orderRegistryToEdit.OrderStatus;

      if (orderRegistryToEdit.OrderStatus == OrderStatus.Canceled)
      {
        return BadRequest("A ordem já foi cancelada");
      }

      orderRegistryToEdit.OrderStatus = VerifyNewStatus(orderRegistryToEdit.OrderStatus, newStatus);

      if (orderRegistryToEdit.OrderStatus == OrderStatus.NotAllowed)
      {
        return BadRequest("Não foi possível alterar o status dessa ordem, verifique as regras de alteração de status.");
      }
      orderRegistryToEdit.StatusMessage = StatusMessage.ShowStatusMessage(orderRegistryToEdit.OrderStatus);

      _context.OrderRegistries.Update(orderRegistryToEdit);
      _context.SaveChanges();

      return Ok($"O status da ordem {orderRegistryToEdit.Id} foi alterado para {orderRegistryToEdit.StatusMessage}");
    }

    OrderStatus VerifyNewStatus(OrderStatus oldStatus, OrderStatus newStatus)
    {
      OrderStatus resultStatus = new OrderStatus();

      switch (newStatus)
      {
        case OrderStatus.Awaiting:
          resultStatus = oldStatus == OrderStatus.Awaiting ? newStatus : OrderStatus.NotAllowed;
          break;
        case OrderStatus.Approved:
          resultStatus = oldStatus == OrderStatus.Awaiting ? newStatus : OrderStatus.NotAllowed;
          break;
        case OrderStatus.Transporting:
          resultStatus = oldStatus == OrderStatus.Approved ? newStatus : OrderStatus.NotAllowed;
          break;
        case OrderStatus.Delivered:
          resultStatus = oldStatus == OrderStatus.Transporting ? newStatus : OrderStatus.NotAllowed;
          break;
        case OrderStatus.Canceled:
          resultStatus = oldStatus == OrderStatus.Transporting || oldStatus == OrderStatus.Delivered ? OrderStatus.NotAllowed : newStatus;
          break;
        default:
          resultStatus = oldStatus;
          break;
      }
      return resultStatus;
    }
  }
}
