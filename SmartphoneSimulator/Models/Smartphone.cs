using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartphoneSimulator.Models
{
  public abstract class Smartphone
  {
    public string Number { get; set; }
    public string Model { get; set; }
    public string IMEI { get; set; }
    public int Memory { get; set; }

    public Smartphone(string number, string model, string imei, int memory)
    {
      Number = number;
      Model = model;
      IMEI = imei;
      Memory = memory;
    }

    public void Call()
    {
      Console.WriteLine("Calling...");
    }

    public void ReceiveCall()
    {
      Console.WriteLine("Receiving call...");
    }

    public abstract void InstallApp(string appName);

  }
}