using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\u2191");
            Console.WriteLine("\u2193");
            //Part1();
            //Part2();
            Part3();
            

        }

        public static void Part1() {
            int speed = 0;
            int groupSize = 3;
            int lastValue = 0, currentValue = 0;
            List<int> list = new List<int>();
            string[] depthMeasurements = File.ReadAllLines("input.txt");
            foreach (string depthMeasurement in depthMeasurements)
            {
                if (depthMeasurements[0] == depthMeasurement)
                {
                    Console.WriteLine(depthMeasurement);
                    continue;
                }

                int.TryParse(depthMeasurement, out currentValue);

                if (currentValue > lastValue)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    list.Add(currentValue);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.WriteLine(depthMeasurement);
                Thread.Sleep(speed);
                lastValue = currentValue;
            }

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(String.Format("We went up a total of {0} times!", list.Count));
        }

        static void Part2()
        {
            int counter = 0;
            int batchSize = 3;
            int[] depthMeasurements = Array.ConvertAll( File.ReadAllLines("input.txt"), int.Parse);
            for (int i = 0; i < depthMeasurements.Length; i++)
            {
                int batchAverage = 0;
                for(int j = i; j < i + batchSize; j++)
                {
                    try{
                        batchAverage += depthMeasurements[j];
                    }
                    catch(Exception ex)
                    {
                        Console.Write("END of tha ride");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("TOTAL: " + counter);
                        return;
                    }
                    
                }

                batchAverage = batchAverage / batchSize;


                int batchAverage2 = 0;
                for (int k = i+1; k < i+1 + batchSize; k++)
                {
                    try
                    {
                        batchAverage2 += depthMeasurements[k];
                    }
                    catch(Exception e)
                    {
                        Console.Write("END of tha ride");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("TOTAL: " + counter);
                        return;
                    }
                    
                }
                batchAverage2 = batchAverage2 / batchSize;

                //Going up
                if (batchAverage2 > batchAverage)
                {
                    counter++;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("\u2193 " + batchAverage2);
                }
                //or down
                else if(batchAverage2 < batchAverage)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\u2191 " + batchAverage2);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("-" + batchAverage2);
                }          
            }
        }

        static void Part3()
        {
            int counter = 0;
            int batchSize = 3;
            int[] depthMeasurements = Array.ConvertAll(File.ReadAllLines("input.txt"), int.Parse);
            //Console.WriteLine(depthMeasurements.Length);
            List<int> batches = new List<int>();
            for (int i = 0; i < depthMeasurements.Length; i++)
            {
                if(i+3 > depthMeasurements.Length){
                    break; ;
                }
                int batchTotal = 0;
                for (int j = i; j < i + batchSize; j++)
                {

                    try
                    {
                        batchTotal += depthMeasurements[j];
                    }
                    catch (Exception ex)
                    {
                        //Console.Write("END of tha ride");
                        //Console.ForegroundColor = ConsoleColor.Red;
                        //Console.WriteLine("TOTAL: " + counter);
                    }
                }

                batches.Add(batchTotal);
            }
            
            bool first = true;
            int previousBatch= 0;
            foreach (int batch in batches)
            {
                if (first)
                {
                    first = false;
                    Console.WriteLine(batch);
                    continue;
                }
                //We went up
                if(batch > previousBatch)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    counter++;
                }
                else // we went down or remained at the same height
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                Console.WriteLine(batch);

                previousBatch = batch;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(counter);
        }
    }
}
