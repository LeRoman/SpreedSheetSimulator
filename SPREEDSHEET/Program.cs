using System;
using System.Collections.Generic;
using System.IO;

namespace SpreedSheet
{
    class Program
    {
        static void Main(string[] args)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            string fileDirectory = projectDirectory + "\\textSample.txt";

            List<string> lines = new List<string>();
         
            using (var text= new StreamReader(fileDirectory))
            {
                while(!text.EndOfStream)
                    lines.Add(text.ReadLine());
            }
         
            InputParser intputParser = new InputParser();

            Table table = intputParser.Parse(lines);
                     
            table.ResolveExpressions();

            table.ComputeTable();

            TablePrinter printer = new TablePrinter();

            printer.PrintTable("Resulting table is:\n", table);
            
            Console.ReadKey();
        }
    }

   

   
}


