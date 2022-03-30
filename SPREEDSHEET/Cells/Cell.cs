using System;

namespace SpreedSheet
{
    public abstract class Cell
    {
        readonly Table table;
        bool computed = false;
      
        public string Value { get; set; }

        protected Cell(Table table)
        {
            this.table = table;
        }

        internal virtual void Compute()
        {
            computed = true;
        }

        public bool IsComputed()
        {
            return computed;
        }

        protected Table GetTable()
        {
            return table;
        }

        public static Cell NewCell(String value, Table table)
        {
            if (String.IsNullOrEmpty(value))
            {
                return new EmptyCell(table);
            }

            if (TextCell.IsText(value))
            {
                return new TextCell(value, table);
            }

            if (NumberCell.IsNumber(value))
            {
                return new NumberCell(value, table);
            }

            if (ExpressionCell.IsExpression(value))
            {
                return new ExpressionCell(value, table);
            }

            return new ErrorCell(table);
            
        }
    }
}
