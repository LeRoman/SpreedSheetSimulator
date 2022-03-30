using System;

namespace SpreedSheet
{
    public class TablePrinter
    {
        public void PrintTable(string header, Table table)
        {
            Console.WriteLine(header);
            Console.WriteLine(table.ToString());
        }
    }
}
