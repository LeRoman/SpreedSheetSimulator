using System;
using System.Collections.Generic;
using System.Text;

namespace SpreedSheet
{
    public class Table
    {
        readonly IDictionary<String, Cell> cells = new Dictionary<String, Cell>();
        int rows = 0;
        char currentColumn = 'A';

        public int MaxColumnsAmount { get; set; } = 0;

        public void AddRow()
        {
            rows++;
            currentColumn = 'A';
        }

        public void AddCell(Cell cell)
        {
            string cellAddress = new StringBuilder().Append(currentColumn).Append(rows).ToString();
            cells.Add(cellAddress, cell);
            currentColumn++;
        }

        public Cell GetCell(string address)
        {
            if (cells.ContainsKey(address))
            {
                return cells[address];
            }

            throw new NonExistentCellException("Table is not contained cell with this address ");
        }

        public void ResolveExpressions()
        {
            foreach (Cell cell in cells.Values)
            {
                if (cell is ExpressionCell expressionCell)
                {
                    expressionCell.Resolve();
                }
            }
        }

        public void ComputeTable()
        {
            foreach (Cell cell in cells.Values)
            {
                cell.Compute();
            }
        }

       

        public override string ToString()
        {

            StringBuilder builder = new StringBuilder();
            StringBuilder rowDelimiter = GetRowDelimiter();
            StringBuilder tableHeader = GetTableHeader();
            builder.Append(tableHeader);
            builder.Append(rowDelimiter);

            for (int i = 1; i <= rows; i++)
            {
                string rowContent = GetRow(i);
                builder.Append(rowContent);
                builder.Append(rowDelimiter);
            }
            return builder.ToString();

        }

        private StringBuilder GetTableHeader()
        {
            var result = new StringBuilder();
            char currentIndex = 'A';
            for (int i = 0; i <= MaxColumnsAmount; i++)
            {
                result.Append($"        {currentIndex++}        ");
            }
            return result;
        }

        private StringBuilder GetRowDelimiter()
        {
            var result = new StringBuilder();
            result.Append("\n");
            for (int i = 0; i <= MaxColumnsAmount; i++)
            {
                result.Append("-----------------");
            }
            result.Append("\n");
            return result;
        }

        string GetRow(int rowAddress)
        {
            StringBuilder row = new StringBuilder();
            char column = 'A';
            string cellAddress = new StringBuilder().Append(column).Append(rowAddress).ToString();
            Cell cell;
            while (cells.ContainsKey(cellAddress))
            {
                cell = cells[cellAddress];
                
                row.Append($" {cell.Value,-15}|");
                column++;
                cellAddress = new StringBuilder().Append(column).Append(rowAddress).ToString();
            }
            
            return row.ToString();
        }
    }
}
