using System;
using System.IO;

namespace SummarizeTempsLab
{
    class Program
    {
        static void Main(string[] args)

        {
            
            string fileName;
            // write out prompt to the console
            Console.WriteLine("enter fileName");
            //read the file name from the console
            fileName = Console.ReadLine();




            if (File.Exists(fileName))

            {//test whether file exsists
                Console.WriteLine("file exists");

                //if the file exists
                // ask the user for a temp threshold
                Console.WriteLine("Enter a temperature");
                string input;
                input = Console.ReadLine();

                int threshold;
                threshold = int.Parse(input);

                int sumTemps = 0;
                int numAbove = 0;
                int numBelow = 0;
                int tempCount = 0;
                
                    //open the file and create streamreader
                    //read a line into the string variable
                    using (StreamReader sr = File.OpenText(fileName))
                {
                    string line = sr.ReadLine();
                    int temp = 0;
                    //while the line is not null
                    while (line != null)
                    {
                        //convert(parse) into an interger variable
                        temp = int.Parse(line);
                        //add the tempature to my stringing variable

                        sumTemps += temp;
                        //if the current temp value >= threshold 
                        if (temp >= threshold)
                        {
                            //increment above by 1
                            numAbove += 1;
                            // else (tempature is below)

                            //increameant the below counter by one
                            //print out temps above the threshold

                        }
                        else
                        {
                            numBelow += 1;
                        }
                        tempCount = tempCount + 1;
                        // read the next line in the file
                        line = sr.ReadLine();
                    }
                    Console.WriteLine("temps above = " + numAbove);
                    //print out temps below the threshold
                    Console.WriteLine("temps below = " + numBelow);
                    // caslculate and print results
                    //calaculate the average
                    int average = sumTemps / tempCount;
                    //print the average
                    Console.WriteLine("The average temp is = " + average);

                    using(StreamWriter sw = new StreamWriter("output.txt"))
                    {
                        sw.WriteLine(System.DateTime.Now.ToString());
                        sw.WriteLine("Temperatures above = " + numAbove);
                        sw.WriteLine("Temps below = " + numBelow);
                        sw.WriteLine("Average temp = " + average);
                    }
                }

            }
            else
            {
                //
                // temperature data is in temps.txt
                //else file doesnt exist
                //tell the user the file doesnt exist
                Console.WriteLine("The file does not exist");
            }
        }
    }
}
