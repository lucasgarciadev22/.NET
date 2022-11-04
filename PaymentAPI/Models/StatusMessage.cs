namespace tech_test_payment_api.Models
{
  public static class StatusMessage
    {
        public static string ShowStatusMessage(OrderStatus status)
        {
            switch (status)
            {
                case OrderStatus.Awaiting:
                return "Aguardando pagamento";
                case OrderStatus.Approved:
                    return "Pagamento aprovado";
                case OrderStatus.Transporting:
                    return "Enviado para transportadora";
                case OrderStatus.Delivered:
                    return "Entregue";
                case OrderStatus.Canceled:
                    return "Cancelada";
                default:
                    return "Status desconhecdo";
            }
        }
    }
}