using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioIntermediario
{
    class DesafioIntermediario
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] num = new int[n];

            // TODO: Crie as outras condições necessárias para a resolução do desafio:
            for (int i = 0; i < n; i++)
            {
                num[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine(MajorityElement(num));

            double salario = 0.00;
            double reajuste = 0.00;
            double novoSalario = 0.00;
            double percentual = 0.00;

            salario = Convert.ToDouble(Console.ReadLine());

            //TODO: Complete os espaços em branco com uma possível solução para o problema:

            if (salario <= 400.00)
            {
                percentual = 0.15;
                reajuste = salario * percentual;
                novoSalario = reajuste + salario;
            }

            else if (salario <= 800.00)
            {
                percentual = 0.12;
                reajuste = salario * percentual;
                novoSalario = reajuste + salario;
            }

            else if (salario <= 1200.00)
            {
                percentual = 0.10;
                reajuste = salario * percentual;
                novoSalario = reajuste + salario;

            }
            else if (salario <= 2000.00)
            {
                percentual = 0.07;
                reajuste = salario * percentual;
                novoSalario = reajuste + salario;

            }
            else if (salario > 2000.00)
            {
                percentual = 0.04;
                reajuste = salario * percentual;
                novoSalario = reajuste + salario;

            }

            Console.WriteLine($"Novo salario: {novoSalario.ToString("N2")}");
            Console.WriteLine($"Reajuste ganho: {reajuste.ToString("N2")}");
            Console.WriteLine($"Em percentual: {percentual * 100} %");

            int quantidadeEntradas = 3;
            var tartaruga = 0;

            while (quantidadeEntradas > 0)
            {
                var numeroQuantidade = Int32.Parse(Console.ReadLine());
                string[] tartarugas = Console.ReadLine().ToString().Split(' ');
                var maiorVelocidade = Int32.Parse(tartarugas[0]);
                if (numeroQuantidade >= 1 && numeroQuantidade <= 500)
                {

                    // TODO: Crie as outras condições necessárias para a resolução do desafio:
                    for (int i = 0; i < tartarugas.Length; i++)
                    {
                        tartaruga = Int32.Parse(tartarugas[i]);

                        if (tartaruga >= maiorVelocidade)
                        {
                            maiorVelocidade = tartaruga;
                        }
                    }

                    if (maiorVelocidade < 10)
                    {
                        Console.WriteLine(1);
                    }
                    else if (maiorVelocidade >= 10 && maiorVelocidade < 20)
                    {
                        Console.WriteLine(2);
                    }
                    else if (maiorVelocidade >= 20)
                    {
                        Console.WriteLine(3);
                    }
                    quantidadeEntradas--;
                }
                else
                {
                    Console.WriteLine("Insira um número entre 1 e 500");
                }
            }
        }

        public static int MajorityElement(int[] nums)
        {
            int majorA = nums[0];
            int majorB = nums[1];
            int countA = 1;
            int countB = 1;
            int major;

            for (int i = 0; i < nums.Length; i++)
            {
                if (majorA != majorB && nums[i] == majorA)
                {
                    countA++;
                }

                else
                {
                    if (majorA != majorB && nums[i] == majorB)
                    {
                        countB++;
                    }
                }
            }

            if (countA > countB)
            {
                major = majorA;
            }
            else
            {
                major = majorB;
            }
            return major;
        }
    }
}
