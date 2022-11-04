using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingSimulator.Models
{
  public class ParkingModel
  {
    private decimal FixedPrice = 0;
    private decimal PricePerHour = 0;
    private List<string> Vehicles = new List<string>();

    public ParkingModel(decimal fixedPrice, decimal pricePerHour)
    {
      this.FixedPrice = fixedPrice;
      this.PricePerHour = pricePerHour;
    }

    public void AddVehicle()
    {
      Console.WriteLine("Digite a placa do veículo para estacionar:");
      string plate = Console.ReadLine();
      Vehicles.Add(plate);
    }

    public void RemoveVehicle()
    {
      Console.WriteLine("Digite a placa do veículo para remover:");

      // Pedir para o usuário digitar a placa e armazenar na variável placa
      // *IMPLEMENTE AQUI*
      string plate = Console.ReadLine();


      // Verifica se o veículo existe
      if (Vehicles.Any(x => x.ToUpper() == plate.ToUpper()))
      {
        Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

        // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
        // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
        // *IMPLEMENTE AQUI*
        int hours = int.Parse(Console.ReadLine());
        decimal totalPrice = FixedPrice + PricePerHour * hours;

        // TODO: Remover a placa digitada da lista de veículos
        // *IMPLEMENTE AQUI*
        Vehicles.RemoveAt(plate.IndexOf(plate));

        Console.WriteLine($"O veículo {plate} foi removido e o preço total foi de: R$ {totalPrice}");
      }
      else
      {
        Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
      }
    }

    public void ListarVeiculos()
    {
      // Verifica se há veículos no estacionamento
      if (Vehicles.Any())
      {
        Console.WriteLine("Os veículos estacionados são:");
        // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
        // *IMPLEMENTE AQUI*
        foreach (var vehicle in Vehicles)
        {
          Console.WriteLine(vehicle);
        }
      }
      else
      {
        Console.WriteLine("Não há veículos estacionados.");
      }
    }
  }
}