using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioPottencial
{
    class DesafioInicial
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p = 1, s = 0;

            while (n > 0)
            {
                int l = n % 10;
                // TODO: Crie as outras condições necessárias para a resolução do desafio:
                n = (n - l) / 10;
                p *= l;
                s += l;
            };

            Console.WriteLine(p - s);

            int qt = int.Parse(Console.ReadLine());
            string[] v = new string[2];

            for (int i = 0; i < qt; ++i)
            {
                v = Console.ReadLine().Split();
                string a = v[0];
                string b = v[1];

                if (b.Length > a.Length)
                    Console.WriteLine("nao encaixa");
                else if (a.EndsWith(b))
                    Console.WriteLine("encaixa");
                else
                    Console.WriteLine("nao encaixa");
            }

            n = int.Parse(Console.ReadLine());
            int count = 0;

            for (int i = 1; i <= n; i++)
            {
                // TODO: Crie as outras condições necessárias para a resolução do desafio:
                if (n % i == 0)
                {
                    count++;
                }
            }
            if (count == 3)
            {
                Console.WriteLine(true);
            }
            else
            {

                Console.WriteLine(false);
            }



        }
            
    }
}

