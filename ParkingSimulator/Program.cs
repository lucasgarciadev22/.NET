// Coloca o encoding para UTF8 para exibir acentuação
using ParkingSimulator.Models;

Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal fixedPrice = 0;
decimal pricePerHour = 0;

Console.WriteLine("Seja bem vindo ao sistema de estacionamento!\n" +
                  "Digite o preço inicial:");
fixedPrice = Convert.ToDecimal(Console.ReadLine());

Console.WriteLine("Agora digite o preço por hora:");
pricePerHour = Convert.ToDecimal(Console.ReadLine());

// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
ParkingModel es = new ParkingModel(fixedPrice, pricePerHour);

bool showMenu = true;

// Realiza o loop do menu
while (showMenu)
{
  Console.Clear();
  Console.WriteLine("Digite a sua opção:");
  Console.WriteLine("1 - Cadastrar veículo");
  Console.WriteLine("2 - Remover veículo");
  Console.WriteLine("3 - Listar veículos");
  Console.WriteLine("4 - Encerrar");

  string opcao = Console.ReadLine();

  switch (opcao)
  {
    case "1":
      es.AddVehicle();
      break;

    case "2":
      es.RemoveVehicle();
      break;

    case "3":
      es.ListarVeiculos();
      break;

    case "4":
      showMenu = false;
      break;

    default:
      Console.WriteLine("Opção inválida");
      break;
  }

  Console.WriteLine("Pressione uma tecla para continuar");
  Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");