using System;
using System.Text.RegularExpressions;

namespace SpreedSheet
{
    public class NumberCell : Cell
    {
        private double numberValue;
        public NumberCell(string value, Table table) : base(table)
        {
            this.Value = value;
        }

        internal override void Compute()
        {
            if (!(IsComputed()))
            {
                base.Compute();
                numberValue = Convert.ToDouble(Value);
            }
        }
        public static bool IsNumber(String value)
        {
            Regex Nums = new Regex(@"^\-?\d+$");
            if (Nums.IsMatch(value))
                return true;
            return false;

        }
    }
}
