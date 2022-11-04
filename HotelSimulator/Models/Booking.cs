using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSimulator.Models
{
  public class Booking
  {
    public List<Person> Hospedes { get; set; }
    public Suite Suite { get; set; }
    public int DiasReservados { get; set; }

    public Booking() { }

    public Booking(int diasReservados)
    {
      DiasReservados = diasReservados;
    }

    public void CadastrarHospedes(List<Person> hospedes)
    {
      // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
      // *IMPLEMENTE AQUI*
      if (Suite.Capacidade >= hospedes.Count)
      {
        Hospedes = hospedes;
      }
      else
      {
        // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
        // *IMPLEMENTE AQUI*
        throw new Exception("A quantidade de hóspedes excedeu a capacidade do quarto!");
      }
    }

    public void CadastrarSuite(Suite suite)
    {
      Suite = suite;
    }

    public int ObterQuantidadeHospedes()
    {
      // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
      // *IMPLEMENTE AQUI*
      return Hospedes.Count;
    }

    public decimal CalcularValorDiaria()
    {
      // TODO: Retorna o valor da diária
      // Cálculo: DiasReservados X Suite.ValorDiaria
      // *IMPLEMENTE AQUI*
      decimal value = DiasReservados * Suite.ValorDiaria;

      // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
      // *IMPLEMENTE AQUI*
      if (DiasReservados >= 10)
      {
        decimal desconto = value * 10 / 100;
        value = value - desconto;
      }

      return value;
    }
  }
}