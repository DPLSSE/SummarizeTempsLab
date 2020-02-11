using System;
using System.IO;

namespace SummarizeTempsLab
{
 class Program
    {
        static void Main(string[] args)
        {
            string fileName;

            Console.WriteLine("Enter the File Name");
            fileName = Console.ReadLine();

            if(File.Exists(fileName))
            {
                Console.WriteLine("File Exists");

                Console.WriteLine("Enter Threshold Temperature");
                string input;
                int threshold;
                input = Console.ReadLine();
                threshold = int.Parse(input);

                int sumTemps = 0;
                int numAbove = 0;
                int numBelow = 0;
                int tempCount = 0;

                using (StreamReader sr = File.OpenText(fileName))
                {
                    string line = sr.ReadLine();
                    int temp;

                    while (line != null)
                    {
                        temp = int.Parse(line);
                        sumTemps += temp;
                        tempCount += temp;

                        if (temp >= threshold)
                        {
                            numAbove += 1;
                        }
                        else
                        {
                            numBelow += 1;
                        }
                        line = sr.ReadLine();
                    }
                }
                Console.WriteLine("Temperature Above = " + numAbove);
                Console.WriteLine("Temperature Below =" + numBelow);

                int average = sumTemps / tempCount;
                Console.WriteLine("The Average is " + average);

            }
            else
            {
                Console.WriteLine("The file you are trying to access does not exist");
            }
        }
    }
}
