using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day2_Dive_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<Tuple<string, int>> commands = new List<Tuple<string, int>>();
            string[] input = File.ReadAllLines("input.txt");
            foreach (string line in input)
            {
                string[] temp = line.Split(" ");
                commands.Add(new Tuple<string, int>(temp[0], int.Parse(temp[1])));
            }


            //Submarine xmasSubmarine = new Submarine();
            Submarine2 xmasSubmarine2 = new Submarine2();

            //commands.ForEach(x => xmasSubmarine.ExecuteCommand(x.Item1, x.Item2));
            commands.ForEach(x => xmasSubmarine2.ExecuteCommand(x.Item1, x.Item2));

            //Console.WriteLine(xmasSubmarine.GetResult());
            Console.WriteLine(xmasSubmarine2.GetResult());
        }
    }

    class Submarine
    {
        int x, y;


        public void ExecuteCommand(string direction, int power)
        {
            switch (direction)
            {
                case "forward":
                    x += power;
                    break;
                case "up":
                    y -= power;
                    break;
                case "down":
                    y += power;
                    break;
                default:
                    //tbd
                    break;
            }

            Console.WriteLine(String.Format("Submarine went {0} {1}!", power, direction));
        }

        public int GetResult()
        {
            return x * y;
        }
    }

    class Submarine2
    {
        int x, y, aim;


        public void ExecuteCommand(string direction, int power)
        {
            switch (direction)
            {
                case "forward":
                    x += power;
                    //depth += aim * power
                    y += aim * power;
                    break;
                case "up":
                    aim -= power;
                    break;
                case "down":
                    aim += power;
                    break;
                default:
                    //tbd
                    break;
            }

            Console.WriteLine(String.Format("Submarine went {0} {1}!", power, direction));
        }

        public int GetResult()
        {
            return x * y;
        }
    }
}
