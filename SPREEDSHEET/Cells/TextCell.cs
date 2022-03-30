using System;

namespace SpreedSheet
{
    public class TextCell : Cell
    {
        public TextCell(string value, Table table) : base(table)
        {
            this.Value = value;
        }

        static char textChar = '\'';

        internal override void Compute()
        {
            if (!IsComputed())
            {
                base.Compute();
                String textValue = Value;
                textValue = textValue.Substring(1);
                Value=textValue;
            }
        }

        public static bool IsText(String value)
        {
            return value[0] == textChar;
        }
    }
}
