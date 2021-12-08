using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day3_Binary_Diagnostic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder gammaResult = new StringBuilder();
            Console.WriteLine("Hello World!");
            string[] input = File.ReadAllLines("input.txt");
            int lineLength = input[0].Length;
            int zero = 0;
            int one =0;

            for(int i = 0; i < lineLength; i++)
            {
                for(int j = 0; j < input.Length; j++)
                {
                    if (input[j][i].Equals('0'))
                        zero++;
                    else
                        one++;
                }
                // check which one was the most
                if (zero > one)
                    gammaResult = gammaResult.Append(0);
                else
                    gammaResult = gammaResult.Append(1);
                zero = 0;
                one = 0;
            }
            int gammaFinal = Convert.ToInt32(gammaResult.ToString(), 2);
            Console.WriteLine("Gamme ray binary: " + gammaResult.ToString());
            Console.WriteLine("Gamme ray number: " +  gammaFinal);

            for(int i = 0;i < gammaResult.Length; i++)
            {
                if (gammaResult[i].Equals('0'))
                    gammaResult[i] = '1';
                else
                {
                    gammaResult[i] = '0';
                }
            }
            int epsilonFinal = Convert.ToInt32(gammaResult.ToString(), 2);
            Console.WriteLine("Epsilon ray binary: " + gammaResult.ToString());
            Console.WriteLine("Epsilon ray number: " + Convert.ToInt32(gammaResult.ToString(), 2));

            Console.WriteLine("Epsilon * Gamma = " + (epsilonFinal * gammaFinal));
        }
    }
}
