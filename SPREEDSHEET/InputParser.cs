using System.Collections.Generic;

namespace SpreedSheet
{
    public class InputParser
    {
        const char cellDelimiter = ' ';

        public Table Parse(List<string> lines)
        {
            Table resultTable = new Table();
             
            for (int i = 0; i < lines.Count; i++)
            {
                resultTable.AddRow();
                string line = lines[i];
                string[] columns = line.Split(new char[] { cellDelimiter });
                for (int y = 0; y < columns.Length; y++)
                {
                    Cell cell = Cell.NewCell(columns[y], resultTable);
                    resultTable.AddCell(cell);
                }
                if (columns.Length - 1 > resultTable.MaxColumnsAmount) resultTable.MaxColumnsAmount = columns.Length - 1;
             
            }

            return resultTable;
        }
    }
}
